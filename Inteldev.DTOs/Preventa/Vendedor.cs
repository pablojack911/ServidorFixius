using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    /// <summary>
    /// DTO para Vendedor
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorPreventa))]
    public class Vendedor : Preventa
    {
    }
}
