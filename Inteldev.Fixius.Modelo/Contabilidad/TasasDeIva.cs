using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Contabilidad
{
	public class TasasDeIva : EntidadMaestro
	{
		public EnumTasas Enum { get; set; }
		public decimal Valor { get; set; }
	}

}
