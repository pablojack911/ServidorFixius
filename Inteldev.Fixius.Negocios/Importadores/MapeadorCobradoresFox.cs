using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorCobradoresFox : MapeadorFox<Cobrador>
    {
        public MapeadorCobradoresFox(IDao con, String empresa, string entidad)
            : base("operator", "select * from operator order by codigo GROUP BY codigo where cargo = 2", "codigo", con, empresa, entidad)
        {
        }

        protected override Cobrador Mapear(Cobrador entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            // Datos Anteriores
            if (entidad.DatosOldPreventa == null)
                entidad.DatosOldPreventa = new DatosOldPreventa();

            entidad.DatosOldPreventa.EsSupervisor = ObtenerBoolDeString(registro["essupervisor"].ToString());
            entidad.DatosOldPreventa.Inactivo = ObtenerBoolDeString(registro["inactivo"].ToString());

            return entidad;
        }
    }
}
