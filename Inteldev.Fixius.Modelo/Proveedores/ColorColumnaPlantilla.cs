using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public class ColorColumnaPlantilla : EntidadMaestro
	{
		public TipoColumna Columna { get; set; }
		public string ColorColumna { get; set; }
	}
}
