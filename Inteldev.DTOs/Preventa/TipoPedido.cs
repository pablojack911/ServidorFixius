using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public enum TipoPedido : int
    {
        [EnumMember]
        Pedido = 0,
        [EnumMember]
        Cambio = 1,
        [EnumMember]
        Retiro = 2
    }
}
