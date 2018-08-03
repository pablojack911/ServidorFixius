using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorArticulosCompuestosFox : MapeadorArticulosFox
    {
        public MapeadorArticulosCompuestosFox(IDao dao, string empresa, string entidad)
            : base(dao, empresa, entidad)
        {
            this.Inicializador("articulo", "select * from articulo where codigo<>' ' and !empty(descrip) and (!empty(entero) or !empty(entero2)) ORDER BY codigo", "codigo", dao);
        }

        protected override Modelo.Articulos.Articulo Mapear(Modelo.Articulos.Articulo entidad, System.Data.DataRow registro)
        {
            #region Articulos Compuestos
            entidad.ArticulosCompuestos.Clear();

            var codArt1 = registro["entero"].ToString().Trim();
            var cant1 = registro["cantidad1"].ToString().Trim();
            if (codArt1 != "")
            {
                var artComp = new ArticuloCompuesto() { ArticuloComponente = this.BuscarEntidadPorCodigo<Articulo>(codArt1) };
                artComp.Cantidad = cant1 == "" ? 0 : Int32.Parse(cant1);
                entidad.ArticulosCompuestos.Add(artComp);
            }

            var codArt2 = registro["entero2"].ToString().Trim();
            var cant2 = registro["cantidad2"].ToString().Trim();
            if (codArt2 != "")
            {
                var artComp2 = new ArticuloCompuesto() { ArticuloComponente = this.BuscarEntidadPorCodigo<Articulo>(codArt2) };
                artComp2.Cantidad = cant2 == "" ? 0 : Int32.Parse(cant2);
                entidad.ArticulosCompuestos.Add(artComp2);
            }
            #endregion
            return base.Mapear(entidad, registro);
        }

        public override bool CompararParaBorrar(Core.Modelo.EntidadMaestro entidad)
        {
            var arti = (Articulo)entidad;

            return arti.ArticulosCompuestos.Count > 0;
        }
    }
}
