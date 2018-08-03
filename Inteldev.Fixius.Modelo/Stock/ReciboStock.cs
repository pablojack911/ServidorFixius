using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Stock
{
	public class ReciboStock : DocumentoVenta
	{
		public ReciboStock()
		{
			this.OrdenesDeCompra = new List<OrdenDeCompra>();
		}
		public ICollection<OrdenDeCompra> OrdenesDeCompra { get; set; }
		public Movimiento MovimientoStock { get; set; }
		public int? IngresoId { get; set; }
	}
}
