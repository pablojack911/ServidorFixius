using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
	public class ReciboStock : DocumentoVenta
	{
		[DataMember]
		public ICollection<OrdenDeCompra> OrdenesDeCompra { get; set; }
		[DataMember]
		public Movimiento MovimientoStock { get; set; }
		[DataMember]
		public int IngresoId { get; set; }
		[DataMember]
		public int Numero { get; set; }
		[DataMember]
		public int PreNumero { get; set; }
	}
}
