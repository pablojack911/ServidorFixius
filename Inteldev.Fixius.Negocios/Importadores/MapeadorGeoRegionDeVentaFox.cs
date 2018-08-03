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
    /// Clase que recibe y mapea una GeoRegionDeVenta
    /// </summary>
    public class MapeadorGeoRegionDeVentaFox : MapeadorFox<GeoRegionDeVenta>
    {
        public MapeadorGeoRegionDeVentaFox(IDao con, string empresa, string entidad)
            : base("regiones", "select * from regiones where empty(georegion)", "codigo", con, empresa, entidad)
        {

        }

        protected override GeoRegionDeVenta Mapear(GeoRegionDeVenta entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }
}
