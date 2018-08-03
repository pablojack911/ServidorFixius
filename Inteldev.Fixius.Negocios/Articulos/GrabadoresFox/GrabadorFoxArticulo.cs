using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.GrabadoresFox
{
    public class GrabadorFoxArticulo : GrabadorFox<Articulo>
    {
        public GrabadorFoxArticulo(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(Articulo entidad)
        {
            this.Tabla = "articulo";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(13, '0');
        }
        public override void ConfigurarCamposValores(Articulo entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("descrip", entidad.Nombre);
            this.CamposValores.Add("descrip_ticket", entidad.NombreBreve);
            this.CamposValores.Add("codigoorig", entidad.CodigoDelProveedor == null ? "" : entidad.CodigoDelProveedor);
            this.CamposValores.Add("proveedor", entidad.Proveedor == null ? "" : entidad.Proveedor.Codigo);
            this.CamposValores.Add("marca", entidad.Marca == null ? "" : entidad.Marca.Codigo);
            this.CamposValores.Add("empaque", entidad.Empaque == null ? "" : entidad.Empaque.Codigo);

            var estado = 3;
            switch (entidad.Estado)
            {
                case EstadoArticulo.Activo:
                    estado = 1;
                    break;
                case EstadoArticulo.Suspendido:
                    estado = 2;
                    break;
                case EstadoArticulo.Inactivo:
                    estado = 3;
                    break;
                default:
                    break;
            }
            this.CamposValores.Add("estado", estado);

            this.CamposValores.Add("caracteristica", entidad.Caracteristica == null ? "" : entidad.Caracteristica.Codigo);
            this.CamposValores.Add("ventaporpeso", entidad.VentaPorPeso ? 1 : 0);
            this.CamposValores.Add("esenvase", entidad.EsEnvase ? 1 : 0);
            //
            this.CamposValores.Add("area", entidad.Area == null ? "" : entidad.Area.Codigo);
            this.CamposValores.Add("sector", entidad.Sector == null ? "" : entidad.Sector.Codigo);
            this.CamposValores.Add("subsector", entidad.Subsector == null ? "" : entidad.Subsector.Codigo);
            this.CamposValores.Add("familia", entidad.Familia == null ? "" : entidad.Familia.Codigo);
            this.CamposValores.Add("subfamilia", entidad.Subfamilia == null ? "" : entidad.Subfamilia.Codigo);

            this.CamposValores.Add("vacio", entidad.Envase == null ? "" : entidad.Envase.Codigo);

            var valortasa = 0;
            if (entidad.TasaDeIVA == EnumTasas.General)
                valortasa = 1;
            else
                if (entidad.TasaDeIVA == EnumTasas.Reducida)
                    valortasa = 2;
                else
                    valortasa = 3;
            this.CamposValores.Add("modiva", valortasa);

            //en fox solo hay espacio para 2 articulos en articulo compuesto. por lo tanto recorremos la lista, el primero en primero y el segundo en segundo (aaaah
            for (int i = 0; i < entidad.ArticulosCompuestos.Count; i++)
            {
                if (i == 0)
                {
                    var articuloCompuestoUno = entidad.ArticulosCompuestos.First();
                    this.CamposValores.Add("entero", articuloCompuestoUno.ArticuloComponente.Codigo);
                    this.CamposValores.Add("cantidad1", articuloCompuestoUno.Cantidad);
                }
                if (i == 1)
                {
                    var articuloCompuestoDos = entidad.ArticulosCompuestos.Last();
                    this.CamposValores.Add("entero2", articuloCompuestoDos.ArticuloComponente.Codigo);
                    this.CamposValores.Add("cantidad2", articuloCompuestoDos.Cantidad);
                }
            }

            if (entidad.CodigoEAN.Count > 0)
            {
                this.CamposValores.Add("unidxbult", entidad.CodigoEAN.LastOrDefault().UnidadesPorBulto);
                this.CamposValores.Add("fraccion", entidad.CodigoEAN.LastOrDefault().UnidadesPorPack);
            }
            this.GrabarCodigosEAN(entidad.Codigo, entidad.CodigoEAN);


            if (entidad.CodigoDUN.Count > 0)
            {
                this.CamposValores.Add("cant_palet", entidad.CodigoDUN.LastOrDefault().UnidadesPorPallet);
                this.CamposValores.Add("cant_base", entidad.CodigoDUN.LastOrDefault().UnidadesPorBase);
                this.CamposValores.Add("altura", entidad.CodigoDUN.LastOrDefault().UnidadesPorAltura);
            }
            this.GrabarCodigosDUN(entidad.Codigo, entidad.CodigoDUN);


            if (entidad.DatosOld != null)
            {
                this.CamposValores.Add("linea", entidad.DatosOld.Linea == null ? "" : entidad.DatosOld.Linea.Codigo);
                this.CamposValores.Add("rubro", entidad.DatosOld.Rubro == null ? "" : entidad.DatosOld.Rubro.Codigo);
                this.CamposValores.Add("divunilever", entidad.DatosOld.Division == null ? "" : entidad.DatosOld.Division.Codigo);
                this.CamposValores.Add("clase", entidad.DatosOld.Clase == null ? "" : entidad.DatosOld.Clase.Codigo);
                this.CamposValores.Add("sku", entidad.DatosOld.SKU == null ? "" : entidad.DatosOld.SKU.Codigo);
                this.CamposValores.Add("env_art", entidad.DatosOld.ArticuloEnvase == null ? "" : entidad.DatosOld.ArticuloEnvase.Codigo);
                this.CamposValores.Add("minimovta", entidad.DatosOld.MinimoDeVenta);
                this.CamposValores.Add("contenido", entidad.DatosOld.ContenidoPorUnidad == null ? "" : entidad.DatosOld.ContenidoPorUnidad);
                this.CamposValores.Add("exclu_ciers", entidad.DatosOld.ExcluirConvenioClienteZ ? 1 : 0);
                this.CamposValores.Add("preventa", entidad.DatosOld.NoIncluirEnPreventa ? 1 : 0);
                this.CamposValores.Add("continua", entidad.DatosOld.NoRecibirPedidos ? 1 : 0);
                this.CamposValores.Add("suspcad", entidad.DatosOld.NoRecibirPedidosCadenas ? 1 : 0);
                this.CamposValores.Add("nopediint", entidad.DatosOld.NoRecibirPedidosInterior ? 1 : 0);
                this.CamposValores.Add("exclu_tomadesc", entidad.DatosOld.ExcluirConvenioClienteZ ? 1 : 0);
                this.CamposValores.Add("novalorizar", entidad.DatosOld.NoValorizar ? 1 : 0);
                this.CamposValores.Add("ctrl_stock", entidad.DatosOld.ControlStock ? 1 : 0);
                this.CamposValores.Add("nopreventa", entidad.DatosOld.NoVenderPorPreventa ? 1 : 0);
                this.CamposValores.Add("prec_mpkg", entidad.DatosOld.BultosMasterEnBorrador ? 1 : 0);
                this.CamposValores.Add("compra", entidad.DatosOld.PuedeComprar ? 1 : 0);
                this.CamposValores.Add("cadena", entidad.DatosOld.PuedeVenderEnCadenas ? 1 : 0);
                this.CamposValores.Add("alcohol", entidad.DatosOld.PedirREBA ? 1 : 0);
                this.CamposValores.Add("pesar", entidad.DatosOld.MostrarEnListadoDeCriticos ? 1 : 0);
                this.CamposValores.Add("margen_prev", entidad.DatosOld.MargenPreventa);
                this.CamposValores.Add("margen_may", entidad.DatosOld.MargenMayorista);
            }


        }

        private void GrabarCodigosDUN(string codigoArticulo, ICollection<CodigoDun> codigosDun)
        {
            foreach (var dun in codigosDun)
            {
                var cmdUpdate = this.Dao.CrearDbCommand();
                cmdUpdate.CommandText = string.Format("select codigo from cbarras where articulo='{0}' and codigo='{1}' and tipo = 1", codigoArticulo, dun.CodigoDeBarra);
                cmdUpdate.CommandType = System.Data.CommandType.Text;

                var rows = cmdUpdate.ExecuteNonQuery();
                if (rows == 0)
                {
                    this.Dao.EjecutarComando(string.Format("insert into cbarras (articulo,codigo,tipo) values ('{0}','{1}',{2})", codigoArticulo, dun.CodigoDeBarra, 1));
                }
                //else
                //    this.Dao.EjecutarComando(string.Format("update"));
            }

            var dr = this.Dao.EjecutarConsulta(string.Format("select codigo from cbarras where articulo='{0}' and tipo = 1", codigoArticulo));
            while (dr.Read())
            {
                var cod = dr.GetString(0).Trim();
                if (!codigosDun.Any(p => p.CodigoDeBarra == cod))
                {
                    this.Dao.EjecutarComando(string.Format("delete from cbarras WHERE articulo='{0}' AND codigo='{1}' AND tipo={2}", codigoArticulo, cod, 1));
                }
            }
            dr.Close();
            dr.Dispose();
            //this.Dao.Desconectar();
        }

        private void GrabarCodigosEAN(string codigoArticulo, ICollection<CodigoEan> codigosEan)
        {
            foreach (var ean in codigosEan)
            {
                var cmdUpdate = this.Dao.CrearDbCommand();
                cmdUpdate.CommandText = string.Format("select codigo from cbarras where articulo='{0}' and codigo ='{1}' and tipo = 2", codigoArticulo, ean.CodigoDeBarra);
                cmdUpdate.CommandType = System.Data.CommandType.Text;

                var rows = cmdUpdate.ExecuteNonQuery();
                if (rows == 0)
                {
                    this.Dao.EjecutarComando(string.Format("insert into cbarras (articulo,codigo,tipo) values ('{0}','{1}',{2})", codigoArticulo, ean.CodigoDeBarra, 2));
                }
                //else
                //    this.Dao.EjecutarComando(string.Format("update"));

            }

            var dr = this.Dao.EjecutarConsulta(string.Format("select codigo from cbarras where articulo='{0}' and tipo = 2", codigoArticulo));
            while (dr.Read())
            {
                var cod = dr.GetString(0).Trim();
                if (!codigosEan.Any(p => p.CodigoDeBarra == cod))
                {
                    this.Dao.EjecutarComando(string.Format("delete from cbarras WHERE articulo='{0}' AND codigo='{1}' AND tipo={2}", codigoArticulo, cod, 2));
                }
            }
            dr.Close();
            dr.Dispose();
            //this.Dao.Desconectar();
        }
    }
}
