using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class DocumentoProveedor : Documento
	{
		public Proveedor Proveedor { get; set; }
		[ForeignKey("Proveedor")]
		public int? ProveedorId { get; set; }
    }
}
