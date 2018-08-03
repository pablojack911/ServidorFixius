using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorClasesFox : MapeadorFox<Clase>
    {
        public MapeadorClasesFox(IDao con, string empresa, string entidad)
            : base("clase", "codigo", con, empresa, entidad)
        {

        }
        protected override Clase Mapear(Clase entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }
}
