using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{

	public class ObjetivosDeCompra : DTOMaestro
	{
		[DataMember]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
		[DataMember]
		public List<Objetivos> Objetivos { get; set; }	
	}
}
