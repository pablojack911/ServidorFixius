﻿using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public class Descuento:DTOBase
    {
        [DataMember]
        public decimal Valor { get; set; }
    }
}
