using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization; 

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public enum UnidadDeMedida : int
    {
        [EnumMember]
        Litros = 0,
        [EnumMember]
        Cm3 = 1,
        [EnumMember]
        Kilos = 2,
        [EnumMember]
        Gramos = 3,
        [EnumMember]
        Metros = 4,
        [EnumMember]
        Centimetros = 5
    }
}
