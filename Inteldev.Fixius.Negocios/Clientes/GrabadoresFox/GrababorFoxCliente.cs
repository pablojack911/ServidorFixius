using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos.Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    public class GrabadorFoxCliente : GrabadorFox<Cliente>
    {
        public GrabadorFoxCliente(IDao dao)
            : base(dao)
        {

            dao.EjecutarComando("SET NULL OFF");

            if (dao.Connection.ConnectionString.ToLower().Contains("mayorista"))
                preventa = false;
            else
                preventa = true;

        }
        bool preventa;
        public override void Configurar(Cliente entidad)
        {
            this.Tabla = "clientes";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(5, '0');
        }

        # region Metodos Creditos
        void CreditoPreventa(ConfiguraCredito conf)
        {
            if (conf != null)
            {

                //string codigoCondicionDePago = this.
                this.SetearValores("condpago", (conf.CondicionDePago == null) ? string.Empty : conf.CondicionDePago.Codigo, string.Empty);
                var modofac = 0;
                if (conf.CondicionDePago != null)
                    modofac = conf.CondicionDePago.ModoDePago == ModoDePago.Contado ? 1 : 2;
                this.SetearValores("modofac", modofac, 0);
                this.SetearValores("condpagop", (conf.CondicionDePago2 == null) ? string.Empty : conf.CondicionDePago2.Codigo, "");
                this.SetearValores("respcond", BoolToInt(conf.RespetarCondicionDePago2), 0);
                this.SetearValores("limite", conf.Limite, 0);
                this.SetearValores("vendedor", (conf.Vendedor == null) ? string.Empty : conf.Vendedor.Codigo, "");
                this.SetearValores("cobrador", (conf.Cobrador == null) ? string.Empty : conf.Cobrador.Codigo, "");
                this.SetearValores("vendespecial", (conf.VendedorEspecial == null) ? string.Empty : conf.VendedorEspecial.Codigo, "");
            }
        }

        void CreditoMayorista(ConfiguraCredito conf)
        {
            if (conf != null)
            {
                this.SetearValores("condpagom", (conf.CondicionDePago == null) ? string.Empty : conf.CondicionDePago.Codigo, "");
                this.SetearValores("limite_may", conf.Limite, 0);
                this.SetearValores("cobradorm", (conf.Cobrador == null) ? string.Empty : conf.Cobrador.Codigo, "");
                if (!preventa)
                {
                    this.SetearValores("vendespecial", (conf.VendedorEspecial == null) ? string.Empty : conf.VendedorEspecial.Codigo, "");
                    this.SetearValores("condpago", string.Empty, string.Empty);
                }
            }
        }

        void CreditoRepresentacion(ConfiguraCredito conf)
        {
            if (conf != null)
            {
                this.SetearValores("condpagob", (conf.CondicionDePago == null) ? string.Empty : conf.CondicionDePago.Codigo, "");
                this.SetearValores("vendrep", (conf.Vendedor == null) ? string.Empty : conf.Vendedor.Codigo, "");
                this.SetearValores("cobrarep", (conf.Cobrador == null) ? string.Empty : conf.Cobrador.Codigo, "");
            }
        }
        # endregion


        int CondicionIngresosBrutos(CondicionAnteIIBB condicion)
        {
            int valor = 0;
            switch (condicion)
            {
                case CondicionAnteIIBB.DNBTreintaYOcho:
                    valor = 4;
                    break;
                case CondicionAnteIIBB.DNBOcho:
                    valor = 3;
                    break;
                case CondicionAnteIIBB.DMOnceVeitiseis:
                    valor = 2;
                    break;
                case CondicionAnteIIBB.NoCorrespondeExento:
                    valor = 1;
                    break;
                default:
                    valor = 0;
                    break;
            }
            return valor;
        }

        int CondicionAnteIva(CondicionAnteIVA condicion)
        {
            int valor = 0;
            switch (condicion)
            {
                case CondicionAnteIVA.ConsumidorFinal:
                    valor = 1;
                    break;
                case CondicionAnteIVA.ResponsableInscripto:
                    valor = 2;
                    break;
                case CondicionAnteIVA.Monotributo:
                    valor = 5;
                    break;
                case CondicionAnteIVA.Exento:
                    valor = 4;
                    break;
                default:
                    valor = 1;
                    break;
            }
            return valor;
        }

        string TipoDeDocumento(TipoDocumentoCliente tipo)
        {
            string valor;

            switch (tipo)
            {
                case TipoDocumentoCliente.DNI:
                    valor = "DNI";
                    break;
                case TipoDocumentoCliente.LC:
                    valor = "LC";
                    break;
                case TipoDocumentoCliente.LE:
                    valor = "LE";
                    break;
                case TipoDocumentoCliente.OTRO:
                    valor = "OTR";
                    break;
                default:
                    valor = "DNI";
                    break;
            }

            return valor;
        }

        public virtual void CamposDiferentes(Cliente entidad)
        {

        }

        void ConfigurarAdicional(Cliente entidad)
        {

        }

        public override void ConfigurarCamposValores(Cliente entidad)
        {
            # region Basicos

            this.SetearValores("codigo", this.ValorClavePrimaria, "");
            this.SetearValores("nombre", entidad.RazonSocial, "");
            this.SetearValores("nomfant", entidad.NombreFantasia, "");
            if (this.Dao.Connection.ConnectionString.Contains("release"))
                this.SetearValores("ctapadre", (entidad.CuentaPadre != null) ? entidad.CuentaPadre.Codigo : "", "");

            this.SetearValores("nombre2", entidad.Nombre, "");
            this.SetearValores("apellido", entidad.Apellido, "");
            if (entidad.Domicilio != null)
            {
                if (entidad.Domicilio.Calle != null)
                {
                    //setea valor en DatosOld.Domicilio
                    //this.SetearValores("Domicilio", string.Format("{0} {1}", entidad.Domicilio.Calle.Nombre, entidad.Domicilio.Numero), "");
                    //this.SetearValores("Domicilio", entidad.Domicilio.ToString(), "");
                    this.SetearValores("Street", entidad.Domicilio.Calle.Nombre.ToUpper(), "");
                    this.SetearValores("Number", entidad.Domicilio.Numero, "");
                }
            }
            if (entidad.Localidad != null)
            {
                this.SetearValores("Copostal", entidad.Localidad.Codigo, "");
                this.SetearValores("localidad", entidad.Localidad.Nombre, "");
            }

            #region EstadoCliente
            this.SetearValores("suspendido", BoolToInt(entidad.Suspendido), 0);
            this.SetearValores("legales", BoolToInt(entidad.Legales), 0);
            this.SetearValores("Inactivo", BoolToInt(entidad.Inactivo), 0);
            #endregion

            var telefonos = string.Empty;
            var celulares = string.Empty;
            foreach (var tel in entidad.Telefonos)
            {
                if (!tel.Numero.Trim().Equals(string.Empty))
                    if (tel.TipoTelefono == TipoTelefono.Fijo)
                        telefonos += tel.Numero.Trim() + " + ";
                    else
                        celulares += tel.Numero.Trim() + " + ";
            }
            this.SetearValores("telefono", telefonos, "");
            this.SetearValores("celular", celulares, "");
            //this.SetearValores("telefono", entidad.Telefonos.Count == 0 ? "" : entidad.Telefonos.FirstOrDefault().Numero, "");
            //podriamos modificar el grabador para que haga lo mismo que con las observaciones, pasarle una bandera y partir la cadena

            this.SetearValores("email", entidad.Email, "");
            this.SetearValores("hentrega", entidad.HoraEntrega, "");

            # endregion

            # region Grupos

            this.SetearValores("ramo", entidad.Ramo == null ? "" : entidad.Ramo.Codigo, "");
            this.SetearValores("grupo", entidad.GrupoDinamico.FirstOrDefault() != null ? entidad.GrupoDinamico.FirstOrDefault().Codigo : "", "");

            # endregion

            #region Fiscal

            this.SetearValores("condiva", this.CondicionAnteIva(entidad.CondicionAnteIva), 0);
            this.SetearValores("cuit", entidad.Cuit, "");
            this.SetearValores("condbrut", this.CondicionIngresosBrutos(entidad.CondicionAnteIibb), 0);
            //this.SetearValores("Fec_ing", string.Format("date({0},{1},{2})", entidad.FechaAlta.Year, entidad.FechaAlta.Month, entidad.FechaAlta.Day), "date()");
            //this.SetearValores("fec_reba", string.Format("date({0},{1},{2})", entidad.VencimientoReba.Year, entidad.VencimientoReba.Month, entidad.VencimientoReba.Day), "date()");

            this.SetearValores("Fec_ing", entidad.FechaAlta, DateTime.Today);

            if (entidad.NumeroReba != string.Empty)
                this.SetearValores("fec_reba", entidad.VencimientoReba, DateTime.Today);

            this.SetearValores("tipodoc", TipoDeDocumento(entidad.TipoDocumentoCliente), 0);
            this.SetearValores("numdoc", entidad.NumeroDocumentoCliente, "");

            if (preventa)
            {
                this.SetearValores("lic_alcohol", entidad.NumeroReba, "");
                this.SetearValores("numeroiibb", entidad.NumeroIibb, "");
            }
            this.SetearValores("percep_gen", entidad.PorcentajePercepcionManual, 0);


            #endregion

            #region Preventa

            #endregion

            #region Logisticos
            if (preventa)
                this.GrabarZonaLogistica(entidad.Codigo, entidad.ZonaLogistica);
            #endregion

            # region Creditos

            if (preventa)
            {
                this.CreditoPreventa(entidad.ConfiguraCreditos.FirstOrDefault(p => p.UnidadDeNegocio == Core.Modelo.Organizacion.UnidadeDeNegocio.Preventa));
                this.CreditoRepresentacion(entidad.ConfiguraCreditos.FirstOrDefault(p => p.UnidadDeNegocio == Core.Modelo.Organizacion.UnidadeDeNegocio.Representaciones));
                this.CreditoMayorista(entidad.ConfiguraCreditos.FirstOrDefault(p => p.UnidadDeNegocio == Core.Modelo.Organizacion.UnidadeDeNegocio.Mayorista));
            }
            else
            {
                this.CreditoMayorista(entidad.ConfiguraCreditos.FirstOrDefault(p => p.UnidadDeNegocio == Core.Modelo.Organizacion.UnidadeDeNegocio.Mayorista));
            }

            this.SetearValores("control", BoolToInt(entidad.NoControlaCredito), 0);

            #endregion

            #region TarjetasHergo

            //realizado en AntesDeGrabar. Modo no se setea hasta despues de pasado el ConfigurarCamposValores.
            var tipo_tarje = entidad.TarjetasCliente.Where(p => p.Habilitada == true).Select(p => p.TipoTarjeta.Codigo).FirstOrDefault();
            if (tipo_tarje != null)
                this.SetearValores("tipo_tarjeta", tipo_tarje, "00");

            #endregion

            # region DatosOld

            if (entidad.DatosOld != null)
            {
                var datosold = entidad.DatosOld;
                this.SetearValores("cod_cia", datosold.CodigoCIA, "");
                this.SetearValores("suc_cia", datosold.SucursalCIA, "");
                this.SetearValores("cod_aguas", datosold.CodigoCDA, "");
                this.SetearValores("aplidesc", BoolToInt(datosold.AplicaDescRango), 0);
                this.SetearValores("prevsalon", BoolToInt(datosold.PreventaSalon), 0);
                this.SetearValores("Temporal", BoolToInt(datosold.Temporal), 0);
                this.SetearValores("potencial", BoolToInt(datosold.Potencial), 0);
                this.SetearValores("prov", BoolToInt(datosold.EsProveedor), 0);
                this.SetearValores("novisitar", BoolToInt(datosold.NoVisitar), 0);
                this.SetearValores("siguecheq", BoolToInt(datosold.ControlaCheques), 0);
                this.SetearValores("lentrega", datosold.DomicilioDeEntrega, string.Empty);
                this.SetearValores("cpentreg", entidad.LocalidadDeEntrega == null ? string.Empty : entidad.LocalidadDeEntrega.Codigo, string.Empty);
                this.SetearValores("domicilio", entidad.DatosOld.Domicilio, "");

                if (preventa)
                {
                    this.SetearValores("vendealc", BoolToInt(datosold.VendeAlcohol), 0);
                    this.SetearValores("arti_todos", BoolToInt(datosold.TodosLosArticulo), 0);
                    this.SetearValores("norelalog", BoolToInt(datosold.NoRelacionarLogistica), 0);
                    this.SetearValores("norecargo", BoolToInt(datosold.NoTomarRecargoLogistica), 0);
                    this.SetearValores("listaprec", (datosold.ListaDePreciosDeVenta == null) ? string.Empty : datosold.ListaDePreciosDeVenta.Codigo, "");
                    this.SetearValores("temp", BoolToInt(entidad.DatosOld.Temporal), 0);
                }
                else
                {
                    this.SetearValores("cortamost", BoolToInt(entidad.DatosOld.CortaTicketPorImporte), 0);
                    this.SetearValores("cheques", BoolToInt(entidad.DatosOld.PermitePagoConCheques), 0);
                    this.SetearValores("requiere_enc", BoolToInt(entidad.DatosOld.RequiereTarjetaEncargado), 0);
                    this.SetearValores("noinfdoc", BoolToInt(entidad.DatosOld.NoInformaDatosEnTicket), 0);
                }

                this.SetearValores("zona", (entidad.ZonaGeografica == null) ? string.Empty : entidad.ZonaGeografica.Codigo, "");
                //if (preventa)
                //    this.GrabarZonaLogistica(entidad.Codigo, entidad.DatosOld.ZonaLogistica);
            }

            # endregion

            string obser = string.Empty;
            foreach (var obs in entidad.ObservacionCliente)
            {
                if (obs.Nombre != null)
                    obser += "- " + obs.FechaHora.ToString() + ": " + obs.Nombre.Trim() + " + "; //.Replace(System.Environment.NewLine, " ");
            }
            for (int i = 0; i < obser.Count(); )
            {
                if (i != 0)
                    obser = obser.Insert(i, "'+'");
                i += 254;
            }
            this.SetearValores("observ", obser, "");

            if (preventa)
            {
                string observ_log = string.Empty;
                foreach (var obs in entidad.ObservacionClienteLogistica)
                {
                    if (obs.Nombre != null)
                        observ_log += "- " + obs.FechaHora.ToString() + ": " + obs.Nombre.Trim().ToString() + " + "; //.Replace(System.Environment.NewLine, " ");
                }
                for (int i = 0; i < observ_log.Count(); )
                {
                    if (i != 0)
                        observ_log = observ_log.Insert(i, "'+'");
                    i += 254;
                }
                this.SetearValores("observ_log", observ_log, "");
            }

            #region RutasDeVenta

            if (entidad.RutasDeVenta != null)
            {
                this.GrabarRuta(entidad.RutasDeVenta, entidad.Codigo);
            }
            #endregion
        }

        //private void GrabarZonaLogistica(string codigoCliente, string codigoZonaLogistica)
        //{
        //    var rows = this.Dao.EjecutarConsulta(string.Format(@"select zona,cliente from config_logis where cliente='{0}'", codigoCliente));
        //    if (rows.Read())
        //    {
        //        var zona = rows.GetString(0);
        //        if (!codigoZonaLogistica.Equals(zona))
        //        {
        //            this.Dao.EjecutarComando(string.Format("UPDATE config_logis SET zona='{0}' WHERE cliente='{1}'", codigoZonaLogistica, codigoCliente));
        //        }
        //    }
        //    else
        //    {
        //        this.Dao.EjecutarComando(string.Format(@"insert into config_logis (zona,cliente) values ('{0}','{1}')", codigoZonaLogistica, codigoCliente));
        //    }
        //    rows.Close();
        //    rows.Dispose();
        //}
        private void GrabarZonaLogistica(string codigoCliente, ZonaLogistica zonaLog)
        {
            string codigoZonaLogistica;
            if (zonaLog == null)
                this.Dao.EjecutarComando(string.Format(@"delete from config_logis where cliente='{0}'", codigoCliente));
            else
            {
                codigoZonaLogistica = zonaLog.Codigo;

                var rows = this.Dao.EjecutarConsulta(string.Format(@"select zona,cliente from config_logis where cliente='{0}'", codigoCliente));
                if (rows.Read())
                {
                    var zona = rows.GetString(0);
                    if (!codigoZonaLogistica.Equals(zona))
                    {
                        this.Dao.EjecutarComando(string.Format("UPDATE config_logis SET zona='{0}' WHERE cliente='{1}'", codigoZonaLogistica, codigoCliente));
                    }
                }
                else
                {
                    this.Dao.EjecutarComando(string.Format(@"insert into config_logis (zona,cliente) values ('{0}','{1}')", codigoZonaLogistica, codigoCliente));
                }
                rows.Close();
                rows.Dispose();
            }
        }

        private void GrabarTarjetasMayorista(ICollection<TarjetaMayoristaItem> tarjetas, string codigo) //insert y update. falta delete
        {
            var cargadopor = this.DateTimeActual() + " - " + this.Usuario;
            var inhabpor = this.DateTimeActual() + " - " + this.Usuario;
            foreach (var tarj in tarjetas)
            {
                string insert = "";
                if (tarj.Habilitada)
                    insert = string.Format(@"insert into codtarje (cliente,codigo,tipotarje,inhabilitado,fecha,cargadopor,inhabpor) values ('{0}','{1}','{2}',{3},{4},'{5}','')", codigo, tarj.Codigo, tarj.TipoTarjeta.Codigo, 0, DateTimeToDateFox(tarj.Fecha), cargadopor);
                else
                    insert = string.Format(@"insert into codtarje (cliente,codigo,tipotarje,inhabilitado,fecha,cargadopor,inhabpor) values ('{0}','{1}','{2}',{3},{4},'{5}','{6}')", codigo, tarj.Codigo, tarj.TipoTarjeta.Codigo, 1, DateTimeToDateFox(tarj.Fecha), cargadopor, inhabpor);
                if (this.Modo == Core.Negocios.Modo.Update)
                {
                    var cmdUpdate = this.Dao.CrearDbCommand();
                    //hago una consulta para ver si existe el cliente con una tarjeta 
                    cmdUpdate.CommandText = string.Format(@"select inhabilitado from codtarje where cliente='{0}' and codigo='{1}'", codigo, tarj.Codigo);
                    cmdUpdate.CommandType = System.Data.CommandType.Text;

                    var dr = cmdUpdate.ExecuteReader();
                    if (dr.Read())
                    {
                        var inhabDecimal = dr.GetDecimal(0);
                        var inhab = inhabDecimal == 1 ? true : false;
                        if (inhab != tarj.Habilitada) //es igual... comparo el valor del campo inhabilitado con el campo habilitado de la tarjeta.
                        {
                            //si es igual no debería cambiar nada. solo actualizo los campos cuando sean distintas
                            //sino estoy actualizando todas las tarjetas de los clientes al guardarlos sin modificarlos desde fixius
                        }
                        else
                        {
                            if (tarj.Habilitada)
                            {
                                this.Dao.EjecutarComando(string.Format(@"update codtarje set inhabilitado=0 where cliente='{0}' and codigo='{1}'", codigo, tarj.Codigo));
                            }
                            else
                            {
                                this.Dao.EjecutarComando(string.Format(@"update codtarje set inhabilitado=1, inhabpor='{0}' where cliente='{1}' and codigo='{2}'", inhabpor, codigo, tarj.Codigo));
                            }
                        }
                    }
                    else
                    {
                        this.Dao.EjecutarComando(insert);
                    }

                    dr.Close();
                    dr.Dispose();
                }
                else
                {
                    this.Dao.EjecutarComando(insert);
                }
            }

            List<String> tarjetasABorrar = new List<string>();
            var cmdSelect = this.Dao.CrearDbCommand();
            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = string.Format(@"select codigo from codtarje where cliente='{0}'", codigo);

            var drSelect = cmdSelect.ExecuteReader();

            while (drSelect.Read())
            {
                var codTar = drSelect.GetString(0).Trim();
                if (!tarjetas.Any(x => x.Codigo.Equals(codTar)))
                    tarjetasABorrar.Add(codTar);
            }
            drSelect.Close();
            drSelect.Dispose();

            if (tarjetasABorrar.Count > 0)
            {
                IDbCommand cmdDelete;
                foreach (var item in tarjetasABorrar)
                {
                    cmdDelete = this.Dao.CrearDbCommand();
                    cmdDelete.CommandType = CommandType.Text;
                    cmdDelete.CommandText = string.Format(@"delete from codtarje where codigo = '{0}' and cliente = '{1}'", item, codigo);
                    cmdDelete.ExecuteNonQuery();
                }
            }
            //this.Dao.Desconectar();
        }

        public override void AntesDeGrabar(Cliente entidad)
        {
            if (this.Modo == Core.Negocios.Modo.Insert)
            {
                this.GrabarCodigoEnIds(entidad.Codigo);
            }
            if (!preventa)
            {
                this.GrabarTarjetasMayorista(entidad.TarjetasCliente, entidad.Codigo);
            }
        }

        private void GrabarCodigoEnIds(string codigo)
        {
            if (this.Dao.Connection.ConnectionString.ToLower().Contains("release"))
            {
                this.Dao.EjecutarComando(@"update s:\appvfp\mayorista\mayorista_release\datos\ids set nextid='" + codigo + "'");
            }
            else
            {
                this.Dao.EjecutarComando(@"update s:\mayorista\datos\ids set nextid='" + codigo + "'");
            }
            //this.Dao.Desconectar();
        }


        private void GrabarRuta(IEnumerable<RutaDeVenta> rutas, string codigoCliente)
        {
            IDataReader dr = null;
            foreach (var ruta in rutas)
            {
                dr = this.Dao.EjecutarConsulta(string.Format(@"select baja from config_zona where cliente='{0}' and empresa='{1}' and subempresa='{2}'", codigoCliente, ruta.Empresa, ruta.Division));

                if (dr.Read()) //significa que encontró una ruta del cliente en esa empresa y subempresa. verificamos: si esta en baja -> delete e insert nueva ruta. sino -> update set ruta=nuevaruta
                {
                    var baja = dr.GetDecimal(0);
                    if (baja == 1)
                    {
                        this.Dao.EjecutarComando(string.Format(@"delete from config_zona where cliente='{0}' and empresa='{1}' and subempresa='{2}'", codigoCliente, ruta.Empresa, ruta.Division));
                        this.Dao.EjecutarComando(string.Format(@"insert into config_zona (zona,empresa,subempresa,cliente,baja) values ('{0}','{1}','{2}','{3}',{4})", ruta.Codigo, ruta.Empresa, ruta.Division, codigoCliente, 0));
                    }
                    else
                        this.Dao.EjecutarComando(string.Format(@"update config_zona set zona='{0}' where cliente='{1}' and empresa='{2}' and subempresa='{3}'", ruta.Codigo, codigoCliente, ruta.Empresa, ruta.Division));
                }
                else
                    this.Dao.EjecutarComando(string.Format(@"insert into config_zona (zona,empresa,subempresa,cliente,baja) values ('{0}','{1}','{2}','{3}',{4})", ruta.Codigo, ruta.Empresa, ruta.Division, codigoCliente, 0));
            }

            dr = this.Dao.EjecutarConsulta(string.Format(@"select zona, empresa, subempresa,baja from config_zona where cliente='{0}'", codigoCliente));
            while (dr.Read())
            {
                var cod = dr.GetString(0);
                var emp = dr.GetString(1);
                var div = dr.GetString(2);
                int baja = 1;
                if (rutas.Any(p => p.Codigo == cod && p.Empresa == emp && p.Division == div))
                {
                    baja = 0;
                }
                this.Dao.EjecutarComando(string.Format("UPDATE config_zona SET baja={4} WHERE zona='{0}' AND empresa='{1}' AND subempresa='{2}' and cliente='{3}'", cod, emp, div, codigoCliente, baja));
            }
            dr.Close();
            dr.Dispose();
        }
    }
}
