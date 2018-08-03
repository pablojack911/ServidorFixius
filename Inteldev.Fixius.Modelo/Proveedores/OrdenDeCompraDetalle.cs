using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class OrdenDeCompraDetalle : ListaDePreciosDetalle
	{
		public int Cantidad { get; set; }
	}
}
