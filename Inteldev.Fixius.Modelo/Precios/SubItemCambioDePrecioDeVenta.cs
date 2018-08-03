using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Precios
{
	public class SubItemCambioDePrecioDeVenta : EntidadBase
	{
		public Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio UnidadDeNegocio { get; set; }

		public decimal Precio { get; set; }

		public decimal Margen { get; set; }
	}
}
