using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public enum EstadoOrdenDeCompra : int
	{
		[EnumMember]
		Pendiente = 0,
		[EnumMember]
		Recibida = 1,
		[EnumMember]
		Anulada = 2
	}
}
