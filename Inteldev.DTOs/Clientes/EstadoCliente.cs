using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public enum EstadoCliente:int
    {
        [EnumMember]
        Activo,
        [EnumMember]
        Inactivo,
        [EnumMember]
        PasarALegales,
        [EnumMember]
        Suspendido
    }
}
