using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class OrdenDeCompra : EntidadMaestro
	{
		public OrdenDeCompra( )
		{
			this.Detalle = new List<OrdenDeCompraDetalle>();
			this.FechaEntrega = DateTime.Now;
		}
		public Proveedor Proveedor { get; set; }
		[ForeignKey("Proveedor")]
		public int? ProveedorId { get; set; }
		public ListaDePrecios ListaDePrecios { get; set; }
		[ForeignKey("ListaDePrecios")]
		public int? ListaDePreciosId { get; set; }
		public Deposito Deposito { get; set; }
        [ForeignKey("Deposito")]
		public int? DepositoId { get; set; }
		public CondicionDePagoProveedor CondicionDePago { get; set; }
		public DateTime FechaEntrega { get; set; }
		public EstadoOrdenDeCompra Estado { get; set; }
		public TipoOrden TipoOrden { get; set; }
		public ICollection<OrdenDeCompraDetalle> Detalle { get; set; }
		public Marca Marca { get; set; }
        [ForeignKey("Marca")]
		public int? MarcaId { get; set; }
		public int TotalBultos { get; set; }
		public decimal ImporteFinal { get; set; }
	}
}
