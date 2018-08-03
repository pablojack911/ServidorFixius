using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorBase<Clase>))]
    public class Clase : DTOMaestro
    {

    }
}
