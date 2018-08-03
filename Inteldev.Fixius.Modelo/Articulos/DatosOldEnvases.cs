using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class DatosOldEnvases : EntidadBase
    {
        public decimal Precio { get; set; }
        public Articulo Articulo { get; set; }
        [ForeignKey("Articulo")]
        public int? ArticuloId { get; set; }
        public bool EsCerveza { get; set; }
    }
}
