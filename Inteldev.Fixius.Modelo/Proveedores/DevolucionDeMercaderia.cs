using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class DevolucionDeMercaderia : EntidadMaestro
	{
		public Proveedor Proveedor { get; set; }
		[ForeignKey("Proveedor")]
		public int? ProveedorId { get; set; }
		public Sucursal Sucursal { get; set; }
		[ForeignKey("Sucursal")]
		public int? SucursalId { get; set; }
		public ICollection<DetalleDevolucionMercaderia> Detalle { get; set; }
	}
}
