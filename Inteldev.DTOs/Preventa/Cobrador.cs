using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    /// <summary>
    /// DTO para Cobrador
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorPreventa))]
    public class Cobrador : Preventa
    {
        
    }
}
