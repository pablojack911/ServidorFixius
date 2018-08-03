using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorEnvasesFox : MapeadorFox<Envase>
    {
        public MapeadorEnvasesFox(IDao con, string empresa, string entidad)
            : base("vacios", "codigo", con, empresa, entidad)
        {
        }

        protected override Envase Mapear(Envase entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.EsCerveza = this.ObtenerBoolDeString(registro["cerveza"].ToString().Trim());
            this.MapearArticulosEnvases(entidad);

            return entidad;
        }

        private void MapearArticulosEnvases(Envase entidad)
        {
            var drArticulosEnvase = dao.EjecutarConsulta("select * from vacio_art where codigo='" + entidad.Codigo + "'");

            var listaArticulosEnvase = new List<ArticuloEnvase>();

            while (drArticulosEnvase.Read())
            {
                var unidades = drArticulosEnvase["unidades"].ToString().Trim();
                var codigoArt = drArticulosEnvase["articulo"].ToString().Trim();
                var valor = drArticulosEnvase["valor"].ToString().Trim();
                var cargaporfrac = drArticulosEnvase["cargaporfrac"].ToString().Trim();
                var codigoEnvase = drArticulosEnvase["codigo"].ToString().Trim();

                var artEnv = new ArticuloEnvase();

                artEnv.Articulo = this.BuscarEntidadPorCodigo<Articulo>(codigoArt);
                artEnv.Cantidad = unidades == "" ? 0 : Int32.Parse(unidades);
                artEnv.PrecioUnitario = valor == "" ? 0 : Decimal.Parse(valor);
                artEnv.Fraccion = cargaporfrac.Contains("T") ? true : false;
                artEnv.CodigoEnvase = codigoEnvase;

                listaArticulosEnvase.Add(artEnv);
            }


            listaArticulosEnvase.ForEach(c =>
            {
                if (entidad.Articulos.Any(articulo => articulo.CodigoEnvase == c.CodigoEnvase && articulo.Articulo.Codigo == c.Articulo.Codigo)) //existe y actualizo las props
                {
                    entidad.Articulos.FirstOrDefault(art => art.CodigoEnvase == c.CodigoEnvase && art.Articulo.Codigo == c.Articulo.Codigo).Cantidad = c.Cantidad;
                    entidad.Articulos.FirstOrDefault(art => art.CodigoEnvase == c.CodigoEnvase && art.Articulo.Codigo == c.Articulo.Codigo).Fraccion = c.Fraccion;
                    entidad.Articulos.FirstOrDefault(art => art.CodigoEnvase == c.CodigoEnvase && art.Articulo.Codigo == c.Articulo.Codigo).PrecioUnitario = c.PrecioUnitario;
                }
                else
                    entidad.Articulos.Add(c);
            });

            List<ArticuloEnvase> articulosBorrados = new List<ArticuloEnvase>();

            entidad.Articulos.ToList().ForEach(art =>
            {
                if (!listaArticulosEnvase.Any(a => a.CodigoEnvase == art.CodigoEnvase && a.Articulo.Codigo == art.Articulo.Codigo))
                    articulosBorrados.Add(art);
            });

            articulosBorrados.ForEach(artb => entidad.Articulos.Remove(artb));

            drArticulosEnvase.Close();
            drArticulosEnvase.Dispose();
            //dao.Desconectar();
        }
    }
}
