using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class MapeadorCallesFox : MapeadorFox<Calle>
    {
        public MapeadorCallesFox(IDao con, string empresa, string entidad)
            : base("streets", "select cast(padl(trans(recno()),10,'0') as c(10)) as codigo, street from streets", "codigo", con, empresa, entidad)
        {
        }

        protected override Calle Mapear(Calle entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["street"].ToString().Trim();
            return entidad;
        }

    }
}
