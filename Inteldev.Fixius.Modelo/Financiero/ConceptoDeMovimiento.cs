using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Financiero
{
	public class ConceptoDeMovimiento : EntidadMaestro
	{
		public ConceptoDeMovimiento( )
		{
			this.Proveedores = new List<Proveedor>();
		}
		public ICollection<Proveedor> Proveedores { get; set; }
	}
}
