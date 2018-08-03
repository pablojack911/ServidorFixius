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
    public class MapeadorMarcasFox : MapeadorFox<Marca>
    {
        public MapeadorMarcasFox(IDao con, string empresa, string entidad)
            : base("Marcas", "codigo", con, empresa, entidad)
        {
        }

        protected override Marca Mapear(Marca entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }
    }

}
