using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class DetalleDataGridBascs<TipoColumna> : EntidadBase
	{
		public Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
		public ICollection<TipoColumna> Columnas { get; set; }
	}
}
