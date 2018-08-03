using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorRamosFox : MapeadorFox<Ramo>
    {
        public MapeadorRamosFox(IDao con, string empresa, string entidad)
            : base("ramos", "select rm.codigo,rm.nombre,rm.comercio from s://mayorista//datos//ramos as rm where !empty(rm.comercio)", "codigo", con, empresa, entidad)
        {
        }

        protected override Ramo Mapear(Ramo entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            String codigoCanal = registro["comercio"].ToString().Trim();

            Canal canal = this.BuscarEntidadPorCodigo<Canal>(codigoCanal);

            entidad.Canal = canal;

            return entidad;
        }

    }
}
