using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorCanalesFox : MapeadorFox<Canal>
    {
        public MapeadorCanalesFox(IDao con, string empresa, string entidad)
            : base("ramos", "select codigo,nombre from ramos where empty(comercio) order by codigo", "codigo", con, empresa, entidad)
        {
        }

        protected override Canal Mapear(Canal entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
