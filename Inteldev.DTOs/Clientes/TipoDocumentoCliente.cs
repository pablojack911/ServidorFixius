﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public enum TipoDocumentoCliente:int
    {
        [EnumMember]
        DNI,
        [EnumMember]
        LC,
        [EnumMember]
        LE,
        [EnumMember]
        OTRO
    }
}
