using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    [Table("ArticulosCompuestos")]
    public class ArticuloCompuesto : EntidadMaestro
    {
        public Articulo ArticuloComponente { get; set; }
        [ForeignKey("ArticuloComponente")]
        public int? ArticuloComponenteId { get; set; }
        public int Cantidad { get; set; }
    }
}
