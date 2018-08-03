using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Financiero
{
	public class ConceptoDeMovimiento : DTOMaestro
	{
		[IgnoreDataMember]
		public List<Proveedor> Proveedores { get; set; }
	}
}
