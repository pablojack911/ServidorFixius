using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class DocumentoProveedor : Documento
	{
		[DataMember]
		[IncluirEnBuscador]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
	}
}
