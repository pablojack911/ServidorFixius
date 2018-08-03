using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa
{
    public class CreadorJefe:CreadorGenerico<Inteldev.Fixius.Modelo.Preventa.Jefe>
    {
        public CreadorJefe(string empresa, string entidad):base(empresa,entidad)
        {

        }

        protected override void CargarDatos(Modelo.Preventa.Jefe Entidad)
        {
            Entidad.DatosOldPreventa = new Modelo.Preventa.DatosOldPreventa();
        }
    }
}
