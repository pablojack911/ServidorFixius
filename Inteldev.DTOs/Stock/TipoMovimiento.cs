using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
	public enum TipoMovimiento : int
	{
		[EnumMember]
		Ingreso = 0,
		[EnumMember]
		Egreso = 1
	}
}
