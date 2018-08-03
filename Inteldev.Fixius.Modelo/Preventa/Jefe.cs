using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class Jefe : Preventa
    {
        public Jefe()
        {
            this.Supervisores = new List<Supervisor>();
            //this.DatosOldPreventa = new DatosOldPreventa(); //¿¿??¿?¿?¿?¿?¿?¿¿?
        }
        [UnoAMuchos]
        public ICollection<Supervisor> Supervisores { get; set; }
    }
}
