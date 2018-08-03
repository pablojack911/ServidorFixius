using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO SKU
    /// </summary>
    public class ValidadorSKU : ValidadorBase<SKU>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorSKU()
        {
            this.ClearRules(s => s.Codigo);
        }
    }
}
