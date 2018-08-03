using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public enum EstadoCambioDePreciosDeVenta:int
    {
        [EnumMember]
        Pendiente = 0,
        [EnumMember]
        Confirmado = 1,
        [EnumMember]
        Anulado = 2
    }
}
