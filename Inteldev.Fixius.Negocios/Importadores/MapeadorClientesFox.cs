using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Logistica;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Modelo.Preventa;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorClientesFox : MapeadorFox<Cliente>
    {
        public MapeadorClientesFox(IDao con, String empresa, string entidad)
            : base("clientes", "select * from clientes where codigo<>'Z9999' order by codigo desc", "codigo", con, empresa, entidad)
        //: base("clientes", "select top 2000 * from clientes where codigo='CLIE1' or codigo='CLIE2' order by codigo desc", "codigo", con, empresa, entidad)
        {

        }

        protected override Cliente Mapear(Cliente entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            //entidad.NombreFantasia = registro["nomfant"].ToString().Trim();
            //entidad.RazonSocial = registro["nombre"].ToString().Trim();

            //entidad.Nombre = registro["nombre2"].ToString().Trim();
            //entidad.Apellido = registro["apellido"].ToString().Trim();

            //var tipoDocumento = registro["tipodoc"].ToString().Trim();
            //if (tipoDocumento.Contains("DNI"))
            //    entidad.TipoDocumentoCliente = TipoDocumentoCliente.DNI;
            //else
            //    if (tipoDocumento.Contains("LE"))
            //        entidad.TipoDocumentoCliente = TipoDocumentoCliente.LE;
            //    else
            //        if (tipoDocumento.Contains("LC"))
            //            entidad.TipoDocumentoCliente = TipoDocumentoCliente.LC;
            //        else
            //            entidad.TipoDocumentoCliente = TipoDocumentoCliente.OTRO;


            ////if (entidad.NumeroDocumentoCliente == null)
            ////    entidad.NumeroDocumentoCliente = string.Empty;
            //entidad.NumeroDocumentoCliente = registro["numdoc"] != null ? registro["numdoc"].ToString().Trim() : string.Empty;

            //string codpostal = registro["Copostal"].ToString().Trim();
            //entidad.Localidad = BuscarEntidadPorCodigo<Localidad>(codpostal);

            //var prov = this.BuscarEntidadPorCodigo<Provincia>("01");
            //if (prov == null)
            //    prov = this.AgregarProvincia();

            //entidad.Provincia = prov;

            //// Domicilio
            //string nombreCalle = registro["street"].ToString().Trim();

            //if (entidad.Domicilio == null)
            //    entidad.Domicilio = new Domicilio();
            //if (entidad.LugarEntrega == null)
            //    entidad.LugarEntrega = new Domicilio();

            //entidad.Domicilio.Calle = BuscarEntidadPorNombre<Calle>(nombreCalle);

            //entidad.Domicilio.Numero = Convert.ToInt32(registro["number"].ToString().Trim());

            ////entidad.Telefonos.Clear(); //NO! Duplica informacion
            //#region Mapeo Telefono

            //string fijo = registro["telefono"].ToString().Trim();
            //string movil = registro["celular"].ToString().Trim();

            //var fijosProcesados = fijo.Split('+');
            //var movilProcesados = movil.Split('+');

            //var telefonosParaQuitar = new List<Telefono>();

            //foreach (var tel in entidad.Telefonos) //elimina los telefonos que no estén mas. los telefonos que se quitaron desde fox
            //{
            //    if (!fijosProcesados.Any(t => t == tel.Numero)) //no esta en fijos
            //        if (!movilProcesados.Any(m => m == tel.Numero)) //no esta en moviles
            //            telefonosParaQuitar.Add(tel);
            //}

            //telefonosParaQuitar.ForEach(t => entidad.Telefonos.Remove(t));

            //foreach (var telFijo in fijosProcesados) //agrega los telefonos fijos
            //{
            //    if (telFijo != string.Empty)
            //        if (!entidad.Telefonos.Any(t => t.Numero == telFijo)) //si no estan existen en la entidad
            //            entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Fijo, Numero = telFijo });
            //}

            //foreach (var telMovil in movilProcesados) //agrega los telefonos moviles 
            //{
            //    if (telMovil != string.Empty)
            //        if (!entidad.Telefonos.Any(m => m.Numero == telMovil)) //si no existen en la entidad
            //            entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Celular, Numero = movil });
            //}
            //#endregion


            ////if (entidad.Telefonos.Count > 0)
            ////    foreach (var tel in entidad.Telefonos)
            ////    {
            ////        if (tel.TipoTelefono == TipoTelefono.Fijo)
            ////        {
            ////            if (tel.Numero != fijo)
            ////                tel.Numero = fijo;
            ////        }
            ////        else
            ////            if (tel.Numero != movil)
            ////                tel.Numero = movil;
            ////    }
            ////else
            ////{
            ////    if (fijo != string.Empty)
            ////        entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Fijo, Numero = fijo });
            ////    if (movil != string.Empty)
            ////        entidad.Telefonos.Add(new Telefono() { TipoTelefono = TipoTelefono.Celular, Numero = movil });
            ////}

            //entidad.Email = registro["email"].ToString().Trim();

            //string codigoRamo = registro["ramo"].ToString().Trim();
            //entidad.Ramo = BuscarEntidadPorCodigo<Ramo>(codigoRamo);

            var dr = dao.EjecutarConsulta("select * from config_logis where cliente='" + entidad.Codigo + "'");
            if (dr.Read())
            {
                var codigoZonaLogistica = dr.GetString(0).Trim();
                entidad.ZonaLogistica = BuscarEntidadPorCodigo<ZonaLogistica>(codigoZonaLogistica);
            }
            //entidad.DatosOld.ZonaLogisticaId

            //if (this.dao.Connection.ConnectionString.Contains("release"))
            //    entidad.CuentaPadre = BuscarEntidadPorCodigo<Cliente>(registro["ctapadre"].ToString());

            //entidad.LocalidadDeEntrega = BuscarEntidadPorCodigo<Localidad>(registro["cpentreg"].ToString().Trim());
            //entidad.HoraEntrega = registro["hentrega"].ToString().Trim();

            //entidad.Cuit = registro["cuit"].ToString().Trim();
            //if (entidad.Cuit == "-        -")
            //    entidad.Cuit = string.Empty;

            //if (registro["Condiva"].ToString().Trim().Length != 0)
            //{
            //    int condicion = int.Parse(registro["Condiva"].ToString());
            //    int condicionAnteIva = 0;

            //    switch (condicion)
            //    {
            //        case 1: //Consumidor Final
            //            condicionAnteIva = 3;
            //            break;
            //        case 2: //Responsable Inscripto
            //            condicionAnteIva = 0;
            //            break;
            //        case 5: //Monotributo
            //            condicionAnteIva = 1;
            //            break;
            //        case 4: //Exento
            //            condicionAnteIva = 2;
            //            break;

            //    }

            //    entidad.CondicionAnteIva = (Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA)Enum.ToObject(typeof(Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA), condicionAnteIva);
            //}

            //entidad.NumeroReba = registro["lic_alcohol"].ToString().Trim();

            //var ven_reba = registro["fec_reba"].ToString().Trim();
            //if (ven_reba != "" && ven_reba != "30/12/1899 12:00:00 a.m.")
            //    entidad.VencimientoReba = Convert.ToDateTime(ven_reba);

            //int condicionAnteIIBB = Convert.ToInt32(registro["condbrut"]);

            //entidad.CondicionAnteIibb = (Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB)Enum.ToObject(typeof(Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB), condicionAnteIIBB);

            //entidad.NumeroIibb = registro["numeroiibb"].ToString().Trim();

            //entidad.PorcentajePercepcionManual = Convert.ToDecimal(registro["percep_gen"].ToString().Trim());

            ////entidad.ConfiguraCreditos.Clear();
            //if (entidad.ConfiguraCreditos.Count == 0)
            //{
            //    entidad.ConfiguraCreditos.Add(new ConfiguraCredito() { UnidadDeNegocio = UnidadeDeNegocio.Preventa });
            //    entidad.ConfiguraCreditos.Add(new ConfiguraCredito() { UnidadDeNegocio = UnidadeDeNegocio.Representaciones });
            //    entidad.ConfiguraCreditos.Add(new ConfiguraCredito() { UnidadDeNegocio = UnidadeDeNegocio.Mayorista });
            //}
            //foreach (var confCred in entidad.ConfiguraCreditos)
            //{
            //    switch (confCred.UnidadDeNegocio)
            //    {
            //        //case UnidadeDeNegocio.Gestion:
            //        //    break;
            //        //case UnidadeDeNegocio.Logistica:
            //        //    break;
            //        case UnidadeDeNegocio.Mayorista:
            //            string codigoCobradorMayorista = registro["cobradorm"].ToString();
            //            confCred.Cobrador = BuscarEntidadPorCodigo<Cobrador>(codigoCobradorMayorista);

            //            string codigoCondicionDePagoMayorista = registro["condpagom"].ToString();
            //            confCred.CondicionDePago = BuscarEntidadPorCodigo<CondicionDePagoCliente>(codigoCondicionDePagoMayorista);

            //            confCred.Limite = Convert.ToDecimal(registro["limite_may"].ToString());
            //            break;
            //        case UnidadeDeNegocio.Preventa:
            //            string codigoCobrador = registro["cobrador"].ToString().Trim();
            //            confCred.Cobrador = BuscarEntidadPorCodigo<Cobrador>(codigoCobrador);

            //            string codigoVendedorEspecial = registro["vendespecial"].ToString().Trim();
            //            confCred.VendedorEspecial = BuscarEntidadPorCodigo<Vendedor>(codigoVendedorEspecial);

            //            string codigoVendedor = registro["vendedor"].ToString().Trim();
            //            confCred.Vendedor = BuscarEntidadPorCodigo<Vendedor>(codigoVendedor);

            //            string codigoCondicionDePago2 = registro["condpagop"].ToString().Trim();
            //            confCred.CondicionDePago2 = BuscarEntidadPorCodigo<CondicionDePagoCliente>(codigoCondicionDePago2);

            //            string codigoCondicionDePago = registro["condpago"].ToString().Trim();
            //            confCred.CondicionDePago = BuscarEntidadPorCodigo<CondicionDePagoCliente>(codigoCondicionDePago);

            //            confCred.Limite = Convert.ToDecimal(registro["limite"].ToString().Trim());

            //            confCred.RespetarCondicionDePago2 = ObtenerBoolDeString(registro["respcond"].ToString().Trim());
            //            break;
            //        case UnidadeDeNegocio.Representaciones:
            //            string codigoCobradorRepresentaciones = registro["cobrarep"].ToString();
            //            confCred.Cobrador = BuscarEntidadPorCodigo<Cobrador>(codigoCobradorRepresentaciones);

            //            string codigoVendedorRepresentaciones = registro["vendrep"].ToString();
            //            confCred.Vendedor = BuscarEntidadPorCodigo<Vendedor>(codigoVendedorRepresentaciones);

            //            string codigoCondicionDePagoRepresentaciones = registro["condpagob"].ToString();
            //            confCred.CondicionDePago = BuscarEntidadPorCodigo<CondicionDePagoCliente>(codigoCondicionDePagoRepresentaciones);
            //            break;
            //    }
            //}

            //entidad.NoControlaCredito = ObtenerBoolDeString(registro["control"].ToString());

            //if (entidad.DatosOld == null)
            //    entidad.DatosOld = new DatosOldCliente();
            //entidad.DatosOld.DomicilioDeEntrega = registro["lentrega"].ToString().Trim();
            //entidad.DatosOld.CodigoCDA = registro["cod_aguas"].ToString().Trim();
            //entidad.DatosOld.CodigoCIA = registro["cod_cia"].ToString().Trim();
            //entidad.DatosOld.SucursalCIA = registro["suc_cia"].ToString().Trim();
            //entidad.DatosOld.ControlaCheques = ObtenerBoolDeString(registro["siguecheq"].ToString().Trim());
            //entidad.DatosOld.AplicaDescRango = ObtenerBoolDeString(registro["aplidesc"].ToString().Trim());
            //entidad.DatosOld.EsProveedor = ObtenerBoolDeString(registro["prov"].ToString().Trim());

            //entidad.DatosOld.Domicilio = registro["domicilio"].ToString().Trim();

            //entidad.Inactivo = ObtenerBoolDeString(registro["inactivo"].ToString().Trim());
            //entidad.Legales = ObtenerBoolDeString(registro["legales"].ToString().Trim());
            //entidad.Suspendido = ObtenerBoolDeString(registro["suspendido"].ToString().Trim());

            ////if (entidad.DatosOld.Inactivo)
            ////    entidad.EstadoCliente = EstadoCliente.Inactivo;
            ////else
            ////    if (entidad.DatosOld.Legales)
            ////        entidad.EstadoCliente = EstadoCliente.PasarALegales;
            ////    else
            ////        if (entidad.DatosOld.Suspendido)
            ////            entidad.EstadoCliente = EstadoCliente.Suspendido;
            ////        else
            ////            entidad.EstadoCliente = EstadoCliente.Activo;

            //entidad.DatosOld.Temporal = ObtenerBoolDeString(registro["temp"].ToString().Trim());
            //entidad.DatosOld.TodosLosArticulo = ObtenerBoolDeString(registro["arti_todos"].ToString().Trim());
            //entidad.DatosOld.NoRelacionarLogistica = ObtenerBoolDeString(registro["norelalog"].ToString().Trim());
            //entidad.DatosOld.NoTomarRecargoLogistica = ObtenerBoolDeString(registro["norecargo"].ToString().Trim());
            //entidad.DatosOld.NoVisitar = ObtenerBoolDeString(registro["novisitar"].ToString().Trim());
            //entidad.DatosOld.Potencial = ObtenerBoolDeString(registro["potencial"].ToString().Trim());
            //entidad.DatosOld.PreventaSalon = ObtenerBoolDeString(registro["prevsalon"].ToString().Trim());
            //entidad.DatosOld.VendeAlcohol = ObtenerBoolDeString(registro["vendealc"].ToString().Trim());
            //entidad.DatosOld.ListaDePreciosDeVenta = BuscarEntidadPorCodigo<ListaDePreciosDeVenta>(registro["listaprec"].ToString().Trim());
            //entidad.DatosOld.ZonaGeografica = BuscarEntidadPorCodigo<ZonaGeografica>(registro["zona"].ToString().Trim());
            ////entidad.ObservacionCliente.Clear();

            //var observacionFox = registro["Observ"].ToString().Trim();
            //if (observacionFox != "")
            //{
            //    var observacionesProcesadas = observacionFox.Split('+');

            //    if (entidad.ObservacionCliente.Count > 0)
            //    {
            //        for (int i = 0; i < observacionesProcesadas.Count(); i++)
            //        {
            //            if (observacionesProcesadas[i].Trim() != "")
            //                if (!entidad.ObservacionCliente.Any(p => observacionesProcesadas[i].Contains(p.Nombre)))
            //                    entidad.ObservacionCliente.Add(new ObservacionCliente() { Nombre = observacionesProcesadas[i], FechaHora = DateTime.Now });
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < observacionesProcesadas.Count(); i++)
            //        {
            //            if (observacionesProcesadas[i].Trim() != "")
            //                entidad.ObservacionCliente.Add(new ObservacionCliente() { Nombre = observacionesProcesadas[i], FechaHora = DateTime.Now });
            //        }
            //    }
            //}

            //var observacionLogisticaFox = registro["observ_log"].ToString().Trim();
            //if (observacionLogisticaFox != "")
            //{
            //    var observacionesLogisticasProcesadas = observacionLogisticaFox.Split('+');

            //    if (entidad.ObservacionClienteLogistica.Count > 0)
            //    {
            //        for (int i = 0; i < observacionesLogisticasProcesadas.Count(); i++)
            //        {
            //            if (observacionesLogisticasProcesadas[i].Trim() != "")
            //                if (!entidad.ObservacionClienteLogistica.Any(p => observacionesLogisticasProcesadas[i].Contains(p.Nombre)))
            //                    entidad.ObservacionClienteLogistica.Add(new ObservacionCliente() { Nombre = observacionesLogisticasProcesadas[i], FechaHora = DateTime.Now });
            //        }
            //    }
            //    else
            //        for (int i = 0; i < observacionesLogisticasProcesadas.Count(); i++)
            //        {
            //            if (observacionesLogisticasProcesadas[i].Trim() != "")
            //                entidad.ObservacionClienteLogistica.Add(new ObservacionCliente() { Nombre = observacionesLogisticasProcesadas[i], FechaHora = DateTime.Now });
            //        }
            //}

            //entidad.FechaAlta = Convert.ToDateTime(registro["fec_ing"].ToString().Trim());

            ////entidad.TarjetasCliente.Clear();

            //var drTarjetas = dao.EjecutarConsulta("select * from s://mayorista//datos//codtarje where cliente='" + entidad.Codigo + "'");

            //var listaTarjetas = new List<TarjetaMayoristaItem>();

            //while (drTarjetas.Read())
            //{
            //    var tar = new TarjetaMayoristaItem()
            //    {
            //        Codigo = drTarjetas.GetString(1).Trim(),
            //        TipoTarjeta = this.BuscarEntidadPorCodigo<TarjetaClienteMayorista>(drTarjetas.GetString(2).Trim()),
            //        Habilitada = drTarjetas.GetDecimal(3) == 1 ? false : true
            //    };
            //    listaTarjetas.Add(tar);
            //}
            //drTarjetas.Close();
            //drTarjetas.Dispose();

            //listaTarjetas.ForEach(t =>
            //{
            //    if (entidad.TarjetasCliente.Any(tar => tar.Codigo.Trim() == t.Codigo.Trim())) //existe y actualizo la prop Habilitada.
            //    {
            //        entidad.TarjetasCliente.FirstOrDefault(tar => tar.Codigo.Trim() == t.Codigo.Trim()).Habilitada = t.Habilitada;
            //        entidad.TarjetasCliente.FirstOrDefault(tar => tar.Codigo.Trim() == t.Codigo.Trim()).Codigo = t.Codigo.Trim();
            //    }
            //    else
            //        entidad.TarjetasCliente.Add(t);
            //});



            ////while (drTarjetas.Read())
            ////{
            ////    var codigoTarjeta = drTarjetas.GetString(1);
            ////    if (!entidad.TarjetasCliente.Any(t => t.Codigo == codigoTarjeta))
            ////    {
            ////        var mayoristaItem = new TarjetaMayoristaItem() { Codigo = codigoTarjeta };

            ////        mayoristaItem.TipoTarjeta = this.BuscarEntidadPorCodigo<TarjetaClienteMayorista>(drTarjetas.GetString(2));

            ////        if (drTarjetas.GetDecimal(3) == 1)
            ////        {
            ////            mayoristaItem.Habilitada = false;
            ////        }
            ////        else
            ////        {
            ////            mayoristaItem.Habilitada = true;
            ////        }

            ////        entidad.TarjetasCliente.Add(mayoristaItem);
            ////    }
            ////    else
            ////    {
            ////        entidad.TarjetasCliente.FirstOrDefault(t => t.Codigo == codigoTarjeta).Habilitada = drTarjetas.GetDecimal(3) == 1 ? false : true;

            ////        //if (drTarjetas.GetDecimal(3) == 1)
            ////        //{
            ////        //    tarjeta.Habilitada = false;
            ////        //}
            ////        //else
            ////        //{
            ////        //    tarjeta.Habilitada = true;
            ////        //}
            ////    }
            ////}


            //List<TarjetaMayoristaItem> tarjetasBorradas = new List<TarjetaMayoristaItem>();
            ////foreach (var tarClie in entidad.TarjetasCliente)
            ////{
            ////bool encontro = false;
            ////while (drTarjetas.Read())
            ////{
            ////    if (tarClie.Codigo == drTarjetas.GetString(1))
            ////    {
            ////        encontro = true;
            ////        break;
            ////    }
            ////}
            ////if (!encontro)
            ////    tarjetasBorradas.Add(tarClie);
            ////}
            //entidad.TarjetasCliente.ToList().ForEach(tar =>
            //{
            //    if (!listaTarjetas.Any(t => t.Codigo.Trim() == tar.Codigo.Trim()))
            //        tarjetasBorradas.Add(tar);
            //});

            //tarjetasBorradas.ForEach(tb => entidad.TarjetasCliente.Remove(tb));



            //String codigoCliente = entidad.Codigo;

            //var drDatosOldMayorista = dao.EjecutarConsulta("select * from s://mayorista//datos//clientes where codigo='" + codigoCliente + "'");
            //while (drDatosOldMayorista.Read())
            //{
            //    entidad.DatosOld.CortaTicketPorImporte = ObtenerBoolDeString(drDatosOldMayorista.GetDecimal(95).ToString());
            //    entidad.DatosOld.NoInformaDatosEnTicket = ObtenerBoolDeString(drDatosOldMayorista.GetDecimal(94).ToString());
            //    entidad.DatosOld.PermitePagoConCheques = ObtenerBoolDeString(drDatosOldMayorista.GetDecimal(85).ToString());
            //    entidad.DatosOld.RequiereTarjetaEncargado = ObtenerBoolDeString(drDatosOldMayorista.GetDecimal(88).ToString());
            //}
            //drDatosOldMayorista.Close();
            //drDatosOldMayorista.Dispose();

            //dao.Desconectar();
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
