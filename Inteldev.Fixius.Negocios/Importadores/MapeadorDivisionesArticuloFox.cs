using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorDivisionesArticuloFox : MapeadorFox<Division>
    {
        public MapeadorDivisionesArticuloFox(IDao con, String empresa, string entidad)
            : base("divisiones", "codigo", con, empresa, entidad)
        {

        }

        protected override Division Mapear(Division entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }
}
