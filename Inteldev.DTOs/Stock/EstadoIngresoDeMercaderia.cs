using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
	public enum EstadoIngresoDeMercaderia : int
	{
		[EnumMember]
		Pendiente = 0,
		[EnumMember]
        [Description("Pendiente Parcial")]
		PendienteParcial = 1,
		[EnumMember]
		Cerrada = 2
	}
}
