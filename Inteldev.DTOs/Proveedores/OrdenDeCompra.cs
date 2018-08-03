using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Auditoria;
using Inteldev.Core.DTO.Stock;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class OrdenDeCompra : DTOMaestro
	{
		[DataMember]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
		[DataMember]
		public ListaDePrecios ListaDePrecios { get; set; }
		[DataMember]
		public int ListaDePreciosId { get; set; }
		[DataMember]
		public Deposito Deposito { get; set; }
		[DataMember]
		public int? DepositoId { get; set; }
		[DataMember]
		public CondicionDePagoProveedor CondicionDePago { get; set; }
		[DataMember]
		public DateTime FechaEntrega { get; set; }
		[DataMember]
		public EstadoOrdenDeCompra Estado { get; set; }
		[DataMember]
		public TipoOrden TipoOrden { get; set; }
		[DataMember]
		public DataTable Detalle { get; set; }
		[DataMember]
		public Marca Marca { get; set; }
		[DataMember]
		public int? MarcaId { get; set; }
		[DataMember]
		public int TotalBultos { get; set; }
		[DataMember]
		public decimal ImporteFinal { get; set; }
		[DataMember]
		public List<Columna> Columnas { get; set; }
	}
}
