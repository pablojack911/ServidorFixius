using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Stock;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
	public class Movimiento : DTOMaestro
	{
		public Movimiento()
		{
			this.Fecha = DateTime.Today;
		}
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public Deposito Deposito { get; set; }
		[DataMember]
		public int? DepositoId { get; set; }
		//[DataMember]
		//public Documento Documento { get; set; }
		//[DataMember]
		//public int DocumentoId { get; set; }
        [DataMember]
        public TipoMovimiento TipoMovimiento { get; set; }
		[DataMember]
		public DataTable DetalleMovimiento { get; set; }
        public ConceptoDeMovimientoDeStock ConceptoDeMovimientoDeStock { get; set; }
        [DataMember]
        public int? ConceptoDeMovimientoDeStockId { get; set; }
	}
}
