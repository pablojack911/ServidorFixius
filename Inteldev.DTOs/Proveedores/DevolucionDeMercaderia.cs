using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class DevolucionDeMercaderia : DTOMaestro
	{
		[DataMember]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
		[DataMember]
		public int? SucursalId { get; set; }
		[DataMember]
		public Sucursal Sucursal { get; set; }
		[DataMember]
		public DataTable Detalle { get; set; }
	}
}
