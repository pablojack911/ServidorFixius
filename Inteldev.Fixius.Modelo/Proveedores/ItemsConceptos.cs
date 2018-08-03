using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class ItemsConceptos : EntidadBase
	{
		public TipoConcepto Tipo { get; set; }
		public decimal Debe { get; set; }
		public decimal Haber { get; set; }
		public ConceptoDeMovimiento Concepto { get; set; }
		[ForeignKey("Concepto")]
		public int? ConceptoId {get;set;}
		//public int HashNeto { get; set; }
	}
}
