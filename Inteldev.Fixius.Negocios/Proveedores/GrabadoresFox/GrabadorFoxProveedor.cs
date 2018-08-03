using Inteldev.Core.Datos;
using Inteldev.Core.Estructuras;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.GrabadoresFox
{
    public class GrabadorFoxProveedor : GrabadorFox<Proveedor>
    {
        public GrabadorFoxProveedor(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(Proveedor entidad)
        {
            this.Tabla = "Proveedo";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(5, '0');
        }
        public override void ConfigurarCamposValores(Proveedor entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", (entidad.RazonSocial == null) ? string.Empty : entidad.RazonSocial);
            //this.CamposValores.Add("domicilio", entidad.Domicilio.ToString());
            this.CamposValores.Add("domicilio", entidad.Domicilio == null ? string.Empty : entidad.Domicilio);

            this.CamposValores.Add("copostal", entidad.Localidad == null ? string.Empty : entidad.Localidad.Codigo);
            this.CamposValores.Add("localidad", entidad.Localidad == null ? string.Empty : entidad.Localidad.Nombre);


            //this.CamposValores.Add("telefono", entidad.Telefonos != null && entidad.Telefonos.FirstOrDefault() != null ? entidad.Telefonos.FirstOrDefault().Numero : string.Empty);

            var telefonos = string.Empty;
            foreach (var tel in entidad.Telefonos)
            {
                if (!tel.Numero.Trim().Equals(string.Empty))
                    telefonos += tel.Numero.Trim() + " + ";
            }
            this.SetearValores("telefono", telefonos, string.Empty); //09/02/15 - NUEVO UPDATE 11.11.15

            this.CamposValores.Add("cuit", entidad.Cuit != null ? entidad.Cuit : string.Empty);
            this.CamposValores.Add("condiva", CondicionAnteIva(entidad.CondicionAnteIva));
            //this.CamposValores.Add("saldo", entidad.DatosOld.saldo);
            //this.CamposValores.Add("porcomis", entidad.DatosOld.porcomis);
            this.CamposValores.Add("calcula", Iif.Condicion(entidad.DatosOld.CalculoBodegas).Entonces(1).Sino(0));
            this.CamposValores.Add("logistica", Iif.Condicion(entidad.DatosOld.ComisionLogistica).Entonces(1).Sino(0));
            this.CamposValores.Add("agperiibb", Iif.Condicion(entidad.EsAgentePercepcionIIBB).Entonces(1).Sino(0));
            this.CamposValores.Add("agperiva", Iif.Condicion(entidad.EsAgentePercepcionIVA).Entonces(1).Sino(0));
            //this.CamposValores.Add("cliente", entidad.DatosOld.cliente);
            this.CamposValores.Add("cjarubro", entidad.ConceptoDeMovimiento != null && entidad.ConceptoDeMovimiento.FirstOrDefault() != null ? entidad.ConceptoDeMovimiento.FirstOrDefault().Codigo : string.Empty);
            //this.CamposValores.Add("saldo_ini", entidad.DatosOld.saldoinicial);
            //this.CamposValores.Add("menos_sald", entidad.DatosOld.menosSaldo);
            this.CamposValores.Add("asociado", (entidad.DatosOld.Fletero != null) ? entidad.DatosOld.Fletero.Codigo : string.Empty); //este falta -> YA NO! Check, pocho
            this.CamposValores.Add("empresa", Iif.Condicion(entidad.DatosOld.EsSubempresa).Entonces(1).Sino(0));
            //this.CamposValores.Add("obs", entidad.Observaciones != null && entidad.Observaciones.FirstOrDefault() != null ? entidad.Observaciones.FirstOrDefault().Nombre : string.Empty);
            string obs = string.Empty;
            foreach (var obser in entidad.Observaciones)
            {
                if (obser.Nombre != null)
                    obs += "- " + obser.FechaHora.ToString() + ": " + obser.Nombre.Trim() + " + "; //.Replace(System.Environment.NewLine, " ");
            }
            for (int i = 0; i < obs.Count(); )
            {
                if (i != 0)
                    obs = obs.Insert(i, "'+'");
                i += 254;
            }
            this.SetearValores("obs", obs, "");

            this.CamposValores.Add("factura", Iif.Condicion(entidad.DatosOld.EmiteComprobantes).Entonces(1).Sino(0));
            this.CamposValores.Add("deposito", entidad.DatosOld != null && entidad.DatosOld.Deposito != null ? entidad.DatosOld.Deposito.Codigo : string.Empty);
            this.CamposValores.Add("sucursal", entidad.DatosOld != null && entidad.DatosOld.PuntoDeVenta != null ? entidad.DatosOld.PuntoDeVenta.ToString() : string.Empty);
            this.CamposValores.Add("preventa", Iif.Condicion(entidad.DatosOld.CargaPedidos).Entonces(1).Sino(0));
            //this.CamposValores.Add("tercero",Iif.Condicion
            //this.CamposValores.Add("habilitado",
            //this.CamposValores.Add("frio"
            //this.CamposValores.Add("reinspc_san"
            //this.CamposValores.Add("kiosko"
            this.CamposValores.Add("exento_iibb", Iif.Condicion(entidad.CondicionAnteIIBB == CondicionAnteIIBB.NoCorrespondeExento || entidad.CondicionAnteIIBB == CondicionAnteIIBB.NoAsignado).Entonces(1).Sino(0));
            this.CamposValores.Add("iibb", entidad.Iibb != null ? entidad.Iibb.ToString() : string.Empty);
            this.CamposValores.Add("plazo_entrega", entidad.DatosOld.PlazoEntregaDias);
            this.CamposValores.Add("condicion", entidad.VencimientoPagos);
            //this.CamposValores.Add("estado",
            //this.CamposValores.Add("empresa_rel")
            this.CamposValores.Add("inactivo", Iif.Condicion(entidad.EstadoProveedor == EstadoProveedor.Suspendido).Entonces(1).Sino(0));
            this.CamposValores.Add("tipoprov", entidad.TipoProveedor == null ? string.Empty : entidad.TipoProveedor.Codigo);
            var ppago = entidad.ProntoPago.FirstOrDefault();
            if (ppago != null)
            {
                this.CamposValores.Add("ppago_dias", ppago.ProntoPagoDias);
                this.CamposValores.Add("ppago_desc", ppago.ProntoPagoDesc);
            }
            else
            {
                this.CamposValores.Add("ppago_dias", 0);
                this.CamposValores.Add("ppago_desc", 0);
            }
            this.CamposValores.Add("banco", entidad.Bancos != null && entidad.Bancos.FirstOrDefault() != null ? entidad.Bancos.FirstOrDefault().Codigo : string.Empty);
            this.CamposValores.Add("requieredatos", Iif.Condicion(entidad.RequiereDatosDeAutorizacion).Entonces(1).Sino(0));
        }

        public static string CondicionAnteIva(CondicionAnteIVA condicion)
        {
            string valor = string.Empty;
            switch (condicion)
            {
                case CondicionAnteIVA.ConsumidorFinal:
                    valor = "1";
                    break;
                case CondicionAnteIVA.ResponsableInscripto:
                    valor = "2";
                    break;
                case CondicionAnteIVA.Monotributo:
                    valor = "5";
                    break;
                case CondicionAnteIVA.Exento:
                    valor = "4";
                    break;
                default:
                    valor = "1";
                    break;
            }
            return valor;
        }
    }
}
