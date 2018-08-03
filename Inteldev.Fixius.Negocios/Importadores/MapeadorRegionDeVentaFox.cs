using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    /// <summary>
    /// Clase que recibe y mapea una RegionDeVenta
    /// </summary>
    public class MapeadorRegionDeVentaFox : MapeadorFox<RegionDeVenta>
    {
        public MapeadorRegionDeVentaFox(IDao con, string empresa, string entidad)
            : base("regiones", "select * from regiones where !empty(georegion)", "codigo", con, empresa, entidad)
        {

        }

        protected override RegionDeVenta Mapear(RegionDeVenta entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            var geo = registro["georegion"].ToString().Trim();
            entidad.GeoRegionDeVenta = this.BuscarEntidadPorCodigo<GeoRegionDeVenta>(geo);

            return entidad;
        }
    }
}
