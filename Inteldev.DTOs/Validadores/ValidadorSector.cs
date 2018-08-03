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
    /// Validador para DTO Sector
    /// </summary>
    public class ValidadorSector : ValidadorBase<Sector>
    {
        /// <summary>
        /// Constructor con las reglas de validacion para Sector
        /// </summary>
        public ValidadorSector()
        {
            this.ClearRules(p => p.Codigo);

            this.RuleFor(p => p.Area)
                .NotNull()
                    .WithMessage("Debe seleccionar un Area.");

        }
    }
}
