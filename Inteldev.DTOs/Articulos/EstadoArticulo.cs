using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public enum EstadoArticulo : int
    {
		[EnumMember]
		Activo = 0,
		[EnumMember]
		Suspendido = 1,
		[EnumMember]
		Inactivo = 2
    }
}
