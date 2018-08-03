using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inteldev.Fixius.Modelo.Precios
{
    public class ItemCambioDePrecioDeVenta:EntidadBase
    {
        public Articulo Articulo { get; set; }
        [ForeignKey("Articulo")]
        public int? ArticuloId { get; set; }
		public decimal Costo { get; set; }
		public decimal CFU { get; set; }
		public ICollection<SubItemCambioDePrecioDeVenta> SubItems { get; set; }
    }
}
