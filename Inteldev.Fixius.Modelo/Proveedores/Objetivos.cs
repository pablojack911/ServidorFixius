﻿using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class Objetivos : EntidadBase
	{
		public DateTime Desde { get; set; }
		public DateTime Hasta { get; set; }
		public int Bultos { get; set; }
		public Decimal Descuento { get; set; }
		public aplicableEnum Aplicable { get; set; }
		
		public Area Area { get; set; }
		[ForeignKey("Area")]
		public int? AreaId { get; set; }

		public Sector Sector { get; set; }
		[ForeignKey("Sector")]
		public int? SectorId { get; set; }
		
		public Subsector Subsector { get; set; }
		[ForeignKey("Subsector")]
		public int? SubsectorId { get; set; }
		
		public Familia Familia { get; set; }
		[ForeignKey("Familia")]
		public int? FamiliaId{ get; set; }
		
		public Subfamilia Subfamilia { get; set; }
		[ForeignKey("Subfamilia")]
		public int? SubfamiliaId { get; set; }
		
		public Articulos.Articulo Articulo { get; set; }
		[ForeignKey("Articulo")]
		public int? ArticuloId { get; set; }
	}

	public enum aplicableEnum : int
	{
		NotaDeCredito = 0,
		Factura = 1
	}

}
