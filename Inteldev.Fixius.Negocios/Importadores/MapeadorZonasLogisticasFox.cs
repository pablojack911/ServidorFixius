using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorZonasLogisticasFox : MapeadorFox<ZonaLogistica>
    {
        public MapeadorZonasLogisticasFox(IDao con, string empresa, string entidad)
            : base("zonas_logis", "codigo", con, empresa, entidad)
        {

        }
        protected override ZonaLogistica Mapear(ZonaLogistica entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            return entidad;
        }
    }
}
