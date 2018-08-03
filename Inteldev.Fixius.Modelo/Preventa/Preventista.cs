using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class Preventista : Preventa
    {
        public Supervisor Supervisor { get; set; }
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }

    }
}
