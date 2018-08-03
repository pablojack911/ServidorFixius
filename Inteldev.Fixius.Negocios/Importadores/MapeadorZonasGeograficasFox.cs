using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorZonasGeograficasFox : MapeadorFox<ZonaGeografica>
    {
        public MapeadorZonasGeograficasFox(IDao dao, string empresa, string entidad)
            : base("zonas", "SELECT * FROM zonas WHERE nombre<>' '", "codigo", dao, empresa, entidad)
        {

        }
        protected override ZonaGeografica Mapear(ZonaGeografica entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();


            return entidad;
        }
    }
}
