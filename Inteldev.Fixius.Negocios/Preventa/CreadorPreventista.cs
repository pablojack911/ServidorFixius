using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa
{
    public class CreadorPreventista : CreadorGenerico<Inteldev.Fixius.Modelo.Preventa.Preventista>
    {
        public CreadorPreventista(string empresa,string entidad):base(empresa,entidad)
        {

        }
        protected override void CargarDatos(Modelo.Preventa.Preventista Entidad)
        {
            Entidad.DatosOldPreventa = new Modelo.Preventa.DatosOldPreventa();
        }

        
    }
}
