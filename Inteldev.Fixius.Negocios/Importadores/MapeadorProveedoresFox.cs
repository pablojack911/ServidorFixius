using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo.Financiero;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Tesoreria;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Core.Datos;
using System.Diagnostics;
using Microsoft.Practices.Unity;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorProveedoresFox : MapeadorFox<Proveedor>
    {
        ContextoGenerico contexto;

        public MapeadorProveedoresFox(IDao con, String empresa, string entidad)
            //: base("proveedo", "select * from Proveedo WHERE (inactivo=0 and fletero<>1) order by codigo", "codigo", con, empresa, entidad)
            : base("proveedo", "select * from Proveedo WHERE fletero<>1 order by codigo", "codigo", con, empresa, entidad)
        {
            //this.contexto = contexto;
        }

        protected override Proveedor Mapear(Proveedor entidad, System.Data.DataRow registro)
        {
            if (entidad.DatosOld == null)
                entidad.DatosOld = new DatosOldProveedor();

            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.RazonSocial = registro["nombre"].ToString().Trim(); //SEGUN ACORDADO CON SILVINA, NOMBRE QUEDA VACIO PARA SU RELLENO

            string codpostal = registro["Copostal"].ToString().Trim();
            entidad.Localidad = BuscarEntidadPorCodigo<Localidad>(codpostal);

            var prov = this.BuscarEntidadPorCodigo<Provincia>("01");
            if (prov == null)
                prov = this.AgregarProvincia();

            entidad.Provincia = prov;

            // Tipo de proveedor
            string tipoProveedor = registro["tipoprov"].ToString().Trim();

            entidad.TipoProveedor = BuscarEntidadPorCodigo<TipoProveedor>(tipoProveedor);
            //entidad.TipoProveedorId = BuscarIdPorCodigo<TipoProveedor>(tipoProveedor);

            int hab = Convert.ToInt32(registro["Inactivo"]);
            entidad.EstadoProveedor = (EstadoProveedor)Enum.ToObject(typeof(EstadoProveedor), hab);

            entidad.RequiereDatosDeAutorizacion = Convert.ToBoolean(registro["requieredatos"]);

            entidad.EsAgentePercepcionIIBB = this.ObtenerBoolDeString(registro["agperiibb"].ToString());

            entidad.EsAgentePercepcionIVA = this.ObtenerBoolDeString(registro["agperiva"].ToString());

            #region DatosOldProveedor

            entidad.DatosOld.CalculoBodegas = Convert.ToBoolean(registro["calcula"]);

            entidad.DatosOld.CargaPedidos = Convert.ToBoolean(registro["preventa"]);

            entidad.DatosOld.ComisionLogistica = Convert.ToBoolean(registro["logistica"]);

            entidad.DatosOld.Deposito = BuscarEntidadPorCodigo<Deposito>(registro["deposito"].ToString().Trim()); // Deposito asociado

            entidad.Domicilio = registro["domicilio"].ToString().Trim();

            entidad.DatosOld.EmiteComprobantes = Convert.ToBoolean(registro["factura"]);

            entidad.DatosOld.EsSubempresa = Convert.ToBoolean(registro["empresa"]);

            entidad.DatosOld.Fletero = BuscarEntidadPorCodigo<Transportista>(registro["asociado"].ToString().Trim());// Fletero asociado

            entidad.DatosOld.PuntoDeVenta = registro["sucursal"].ToString().Trim();

            entidad.DatosOld.PlazoEntregaDias = Int32.Parse(registro["plazo_entrega"].ToString().Trim());

            #endregion

            if (registro["Condiva"].ToString().Trim().Length != 0)
            {
                int condicion = int.Parse(registro["Condiva"].ToString());
                int condicionAnteIva = 0;

                switch (condicion)
                {
                    case 1: //Consumidor Final
                        condicionAnteIva = 3;
                        break;
                    case 2: //Responsable Inscripto
                        condicionAnteIva = 0;
                        break;
                    case 5: //Monotributo
                        condicionAnteIva = 1;
                        break;
                    case 4: //Exento
                        condicionAnteIva = 2;
                        break;

                }

                entidad.CondicionAnteIva = (Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA)Enum.ToObject(typeof(Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA), condicionAnteIva);
            }

            entidad.Cuit = registro["cuit"].ToString().Trim();

            entidad.Iibb = registro["iibb"].ToString().Trim();

            //CondicionAnteIIBB:
            //RegimenGeneral = 0,
            //Exento = 1

            int exento = Convert.ToInt32(registro["exento_iibb"]);
            int condicionAnteIIBB = 0;

            if (exento == 1)
            {
                condicionAnteIIBB = exento;
            }

            entidad.CondicionAnteIIBB = (Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB)Enum.ToObject(typeof(Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB), condicionAnteIIBB);

            //entidad.Telefonos.Clear();
            //entidad.Telefonos.Add(new Telefono() { TipoTelefono = Core.Modelo.Locacion.TipoTelefono.Fijo, Numero = registro["telefono"].ToString().Trim() });

            //string fijo = registro["telefono"].ToString().Trim();
            //if (entidad.Telefonos.Count > 0)
            //    foreach (var tel in entidad.Telefonos)
            //    {
            //        if (tel.TipoTelefono == TipoTelefono.Fijo)
            //        {
            //            if (tel.Numero != fijo)
            //                tel.Numero = fijo;
            //        }
            //    }
            //else
            //{
            //    if (fijo != string.Empty)
            //        entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Fijo, Numero = fijo });
            //}
            #region Mapeo tel fijo


            string fijo = registro["telefono"].ToString().Trim();
            var fijosProcesados = fijo.Split('+');

            var telefonosParaQuitar = new List<Telefono>();

            foreach (var tel in entidad.Telefonos) //elimina los telefonos que no estén mas. los telefonos que se quitaron desde fox
            {
                if (!fijosProcesados.Any(t => t == tel.Numero)) //no esta en fijos
                    telefonosParaQuitar.Add(tel);
            }

            telefonosParaQuitar.ForEach(t => entidad.Telefonos.Remove(t));

            foreach (var telFijo in fijosProcesados) //agrega los telefonos fijos
            {
                if (telFijo != string.Empty)
                    if (!entidad.Telefonos.Any(t => t.Numero == telFijo)) //si no estan existen en la entidad
                        entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Fijo, Numero = telFijo });
            }

            #endregion

            //entidad.Observaciones.Clear();
            //entidad.Observaciones.Add(new ObservacionProveedor() { Nombre = registro["obs"].ToString().Trim(), FechaHora = DateTime.Today });
            var observacionFox = registro["obs"].ToString().Trim();
            if (observacionFox != "")
            {
                var observacionesProcesadas = observacionFox.Split('+');

                if (entidad.Observaciones.Count > 0)
                {
                    for (int i = 0; i < observacionesProcesadas.Count(); i++)
                    {
                        if (!entidad.Observaciones.Any(p => p.Nombre == observacionesProcesadas[i]))
                            entidad.Observaciones.Add(new ObservacionProveedor() { Nombre = observacionesProcesadas[i], FechaHora = DateTime.Now });
                    }
                }
                else
                {
                    for (int i = 0; i < observacionesProcesadas.Count(); i++)
                    {
                        entidad.Observaciones.Add(new ObservacionProveedor() { Nombre = observacionesProcesadas[i], FechaHora = DateTime.Now });
                    }
                }
            }
            var conceptoDeMovimiento = BuscarEntidadPorCodigo<ConceptoDeMovimiento>(registro["rubro"].ToString().Trim());
            if (conceptoDeMovimiento != null)
            {
                if (entidad.ConceptoDeMovimiento == null)
                {
                    entidad.ConceptoDeMovimiento = new List<ConceptoDeMovimiento>();
                }
                else
                {
                    entidad.ConceptoDeMovimiento.Clear();
                    entidad.ConceptoDeMovimiento.Add(conceptoDeMovimiento);
                }
            }

            if (entidad.ProntoPago == null)
                entidad.ProntoPago = new List<ProntoPago>();
            else
            {
                if (entidad.ProntoPago.Count == 0)
                {
                    entidad.ProntoPago.Add(new ProntoPago()
                    {
                        ProntoPagoDesc = (decimal)registro["ppago_desc"],
                        ProntoPagoDias = int.Parse(registro["ppago_dias"].ToString())
                    });
                }
                else
                {
                    entidad.ProntoPago.FirstOrDefault().ProntoPagoDesc = (decimal)registro["ppago_desc"];

                    entidad.ProntoPago.FirstOrDefault().ProntoPagoDias = int.Parse(registro["ppago_dias"].ToString());
                }
            }


            Banco banco = BuscarEntidadPorCodigo<Banco>(registro["banco"].ToString().Trim());
            if (banco != null)
                entidad.Bancos.Add(banco);
            else
                Debug.Write("El banco " + registro["banco"].ToString().Trim() + " no existe en la base de datos local (POCHO)");

            entidad.VencimientoPagos = int.Parse(registro["condicion"].ToString());



            return entidad;

        }

        private Provincia AgregarProvincia()
        {
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", "01");
            parameters[1] = new ParameterOverride("entidad", "Provincia");


            var tipograbador = typeof(IGrabador<>);
            var tipoGrabadorGenerico = tipograbador.MakeGenericType(typeof(Provincia));

            LogManager.Instancia.AgregarMensaje(string.Format("Creado el Grabador de la entidad {0}", typeof(Provincia).ToString()));
            dynamic grabador = FabricaNegocios.Instancia.Resolver(tipoGrabadorGenerico, parameters);
            var grabadorCarrier = grabador.Grabar(new Provincia() { Nombre = "Buenos Aires", Codigo = "01" });//necesitamos ingresar una provincia BsAs para todas las localidades

            return this.BuscarEntidadPorCodigo<Provincia>("01");
        }

    }
}
///agregar mapeo para las columnas:
///domicilio -> datosold.domicilio Check!
///rubro -> buscar por codigo conceptodemovimiento => fijarse como hace condicion de pago Check!
///plazo_entrega -> en datosold. algun campo que reciba esto
///