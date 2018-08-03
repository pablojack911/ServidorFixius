using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class ListaDePreciosDetalle : EntidadBase
    {
        public Articulo Articulo { get; set; }
        [ForeignKey("Articulo")]
        public int? ArticuloId { get; set; }

        public decimal Neto { get; set; }
        public decimal Iva { get; set; }
        public decimal ImpInterno { get; set; }
        public decimal Costo { get; set; }
        public decimal Final { get; set; }
        public ICollection<ListaDePreciosColumna> Columnas { get; set; }
    }
}