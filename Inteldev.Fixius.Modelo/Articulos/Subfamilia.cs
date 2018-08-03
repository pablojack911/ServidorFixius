using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class Subfamilia : EntidadMaestro
    {
        public Familia Familia { get; set; }
        [ForeignKey("Familia")]
        public int? FamiliaId { get; set; }
    }
}
