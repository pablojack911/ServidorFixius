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
    public class MapeadorEmpaquesFox : MapeadorFox<Empaque>
    {
        public MapeadorEmpaquesFox(IDao con, string empresa, string entidad)
            : base("empaque", "codigo", con, empresa, entidad)
        {
        }

        protected override Empaque Mapear(Empaque entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Contenido = Decimal.Parse(registro["litros"].ToString().Trim());
            return entidad;
        }

    }
}
