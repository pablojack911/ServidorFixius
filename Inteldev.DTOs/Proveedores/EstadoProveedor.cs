using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public enum EstadoProveedor : int
    {
		[EnumMember]
		Habilitado = 0,
		[EnumMember]
		Suspendido = 1
    }
}
