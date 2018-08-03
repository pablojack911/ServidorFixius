using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class DetalleDevolucionMercaderia : EntidadBase
	{
		public Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
		public decimal Costo { get; set; }
		public int Cantidad { get; set; }
	}
}
