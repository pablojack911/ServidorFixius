using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Stock
{
	public class DetalleMovimiento : EntidadBase
	{
		public Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
		public int Cantidad { get; set; }
	}
}
