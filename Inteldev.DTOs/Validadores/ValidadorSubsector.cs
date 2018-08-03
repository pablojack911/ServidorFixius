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
    /// Validador para DTO Subsector
    /// </summary>
    public class ValidadorSubsector : ValidadorBase<Subsector>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorSubsector()
        {
            this.ClearRules(p => p.Codigo);

            this.RuleFor(p => p.Sector)
                .NotNull()
                    .WithMessage("Debe seleccionar un Sector.");

        }
    }
}
