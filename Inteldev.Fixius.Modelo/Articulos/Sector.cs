using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    [Table("Sectores")]
    public class Sector : EntidadMaestro
    {
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public int? AreaId { get; set; }
    }
}
