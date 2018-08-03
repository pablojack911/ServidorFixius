using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorTransportistasFox : MapeadorFox<Transportista>
    {
        public MapeadorTransportistasFox(IDao con, string empresa, string entidad)
            : base("proveedo", "select codigo,nombre from proveedo where fletero=1","codigo", con, empresa, entidad)
        {
        }

        protected override Transportista Mapear(Transportista entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
