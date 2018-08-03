using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorTipoProveedorFox : MapeadorFox<TipoProveedor>
    {
        public MapeadorTipoProveedorFox(IDao con, string empresa, string entidad)
            : base("tipoprov","codigo", con, empresa, entidad)
        {
        }

        protected override TipoProveedor Mapear(TipoProveedor entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
