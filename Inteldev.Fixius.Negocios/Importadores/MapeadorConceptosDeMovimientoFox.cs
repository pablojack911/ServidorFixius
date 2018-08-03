using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class MapeadorConceptosDeMovimientoFox:MapeadorFox<ConceptoDeMovimiento>
    {
        public MapeadorConceptosDeMovimientoFox(IDao con, string empresa, string entidad)
            : base("cjarubro","codigo", con, empresa, entidad)
        {
        }

        protected override ConceptoDeMovimiento Mapear(ConceptoDeMovimiento entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }
}
