using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Fixius.Modelo.Tesoreria;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorBancosFox : MapeadorFox<Banco>
    {
        public MapeadorBancosFox(IDao con, string empresa, string entidad)
            : base("bancos","codigo", con, empresa,entidad)
        {
        }

        protected override Banco Mapear(Banco entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
