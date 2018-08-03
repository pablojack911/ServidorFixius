using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public enum TipoOrden : int
	{
		[EnumMember]
		Abierta = 0,
		[EnumMember]
		Cerrada = 1
	}
}
