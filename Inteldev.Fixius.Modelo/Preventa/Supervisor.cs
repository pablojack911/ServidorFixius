using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class Supervisor : Preventa
    {
        public Supervisor()
        {
            this.Preventistas = new List<Preventista>();
        }
        [UnoAMuchos]
        public ICollection<Preventista> Preventistas { get; set; }

        public Jefe Jefe { get; set; }
        [ForeignKey("Jefe")]
        public int? JefeId { get; set; }
    }
}
