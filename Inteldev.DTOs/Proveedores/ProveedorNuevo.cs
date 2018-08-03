using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	[DataContract]
	public class ProveedorNuevo : DTOMaestro
	{
		[DataMember]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public Area Area { get; set; }
	}
}
