using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Stock
{
	public class ItemIngreso : EntidadBase
	{
		public int Bultos { get; set; }
		public Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
        public OrdenDeCompra OrdenDeCompra { get; set; }
        [ForeignKey("OrdenDeCompra")]
        public int? OrdenDeCompraId { get; set; }
	}
}
