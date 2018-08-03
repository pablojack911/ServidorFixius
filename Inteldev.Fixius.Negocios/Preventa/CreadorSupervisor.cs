using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa
{
    public class CreadorSupervisor : CreadorGenerico<Inteldev.Fixius.Modelo.Preventa.Supervisor>
    {
        public CreadorSupervisor(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        protected override void CargarDatos(Modelo.Preventa.Supervisor Entidad)
        {
            Entidad.Preventistas = new List<Preventista>();
            Entidad.DatosOldPreventa = new Modelo.Preventa.DatosOldPreventa();
        }
    }
}
