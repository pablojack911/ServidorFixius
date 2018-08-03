using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public class ColorColumnaPlantilla : DTOMaestro
	{
		[DataMember]
		public TipoColumna Columna { get; set; }
		[DataMember]
		public string ColorColumna { get; set; }
	}
}
