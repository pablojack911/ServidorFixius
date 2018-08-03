using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO ZonaGeografica
    /// </summary>
    public class ValidadorZonaGeografica : ValidadorBase<ZonaGeografica>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorZonaGeografica()
        {
            this.ClearRules(z => z.Codigo);

            this.RuleFor(z => z.Localidad)
                .NotEmpty()
                    .WithMessage("Debe seleccionar una Localidad.")
                .NotNull()
                    .WithMessage("Debe seleccionar una Localidad.");

            this.RuleFor(z => z.Provincia)
                .NotEmpty()
                    .WithMessage("Debe seleccionar una Provincia.")
                .NotNull()
                    .WithMessage("Debe seleccionar una Provincia.");
        }
    }
}
