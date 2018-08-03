using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorAreasFox : MapeadorFox<Area>
    {
        public MapeadorAreasFox(IDao con, string empresa, string entidad)
            : base("area", @"select * from s:\appvfp\hergo_release\datos\area", "codigo", con, empresa, entidad)
        {

        }
        protected override Area Mapear(Area entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }
}
