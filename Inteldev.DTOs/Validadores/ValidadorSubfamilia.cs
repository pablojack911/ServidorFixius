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
    /// Validador para DTO SubFamilia
    /// </summary>
    public class ValidadorSubfamilia : ValidadorBase<Subfamilia>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorSubfamilia()
        {
            this.ClearRules(p => p.Codigo);

            this.RuleFor(p => p.Familia)
                .NotNull()
                    .WithMessage("Debe seleccionar una Familia.");

        }
    }
}
