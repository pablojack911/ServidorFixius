using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class Objetivos : DTOBase
	{
		[DataMember]
		public DateTime Desde { get; set; }
		[DataMember]
		public DateTime Hasta { get; set; }
		[DataMember]
		public int Bultos { get; set; }
		[DataMember]
		public Decimal Descuento { get; set; }
		[DataMember]
		public Area Area { get; set; }
		[DataMember]
		public int? AreaId { get; set; }
		[DataMember]
		public Sector Sector { get; set; }
		[DataMember]
		public int? SectorId { get; set; }
		[DataMember]
		public Subsector Subsector { get; set; }
		[DataMember]
		public int SubsectorId { get; set; }
		[DataMember]
		public Familia Familia { get; set; }
		[DataMember]
		public int FamiliaId { get; set; }
		[DataMember]
		public Subfamilia Subfamilia { get; set; }
		[DataMember]
		public int? SubfamiliaId { get; set; }
		[DataMember]
		public Articulos.Articulo Articulo { get; set; }
		[DataMember]
		public int? ArticuloId { get; set; }
		[DataMember]
		public aplicableEnum Aplicable { get; set; }

		public Objetivos( )
		{
			this.Desde = DateTime.Today;
			this.Hasta = DateTime.Today;
		}
	}

	public enum aplicableEnum : int
	{
		[EnumMember]
        [Description("Nota de Credito")]
		NotaDeCredito = 0,
		[EnumMember]
		Factura = 1
	}
}
