using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Stock
{
	public class Movimiento : EntidadMaestro
	{
		public Movimiento()
		{
			this.Fecha = DateTime.Now;
		}
		public DateTime Fecha { get; set; }
		public Deposito Deposito { get; set; }
		[ForeignKey("Deposito")]
		public int? DepositoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
		public ICollection<DetalleMovimiento> DetalleMovimiento { get; set; }
        public ConceptoDeMovimientoDeStock ConceptoDeMovimientoDeStock { get; set; }
        [ForeignKey("ConceptoDeMovimientoDeStock")]
        public int? ConceptoDeMovimientoDeStockId { get; set; }
		//public Documento Documento { get; set; }
		//[ForeignKey("Documento")]
		//public int? DocumentoId { get; set; }
	}
}
