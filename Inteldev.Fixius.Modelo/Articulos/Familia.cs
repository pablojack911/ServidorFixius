using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class Familia : EntidadMaestro
    {
        public Subsector Subsector { get; set; }
        [ForeignKey("Subsector")]
        public int? SubsectorId { get; set; }
    }
}
