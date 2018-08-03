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
    public class MapeadorCaracteristicasFox : MapeadorFox<Caracteristica>
    {
        public MapeadorCaracteristicasFox(IDao con, string empresa, string entidad)
            : base("caracterist", "codigo", con, empresa, entidad)
        {
        }

        protected override Caracteristica Mapear(Caracteristica entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
