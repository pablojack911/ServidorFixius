﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorBase<Area>))]
    public class Area : DTOMaestro
    {

    }
}
