using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    /// <summary>
    /// DTO para Canal
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorCanal))]
    public class Canal : DTOMaestro
    {
    }
}
