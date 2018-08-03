using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    [Table("Subsectores")]
    public class Subsector : EntidadMaestro
    {
        public Sector Sector { get; set; }
        [ForeignKey("Sector")]
        public int? SectorId { get; set; }
    }
}
