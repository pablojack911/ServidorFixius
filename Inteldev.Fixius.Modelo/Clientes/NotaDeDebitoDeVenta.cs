using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
	public class NotaDeDebitoDeVenta : DocumentoVenta
	{
		public Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
		public int Cantidad { get; set; }
		public decimal Costo { get; set; }
	}
}
