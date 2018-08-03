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
    /// Validador para DTO Familia
    /// </summary>
    public class ValidadorFamilia : ValidadorBase<Familia>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorFamilia()
        {
            this.ClearRules(p => p.Codigo);

            this.RuleFor(p => p.Subsector)
                .NotNull()
                    .WithMessage("Debe seleccionar un Subsector.");

        }
    }
}
