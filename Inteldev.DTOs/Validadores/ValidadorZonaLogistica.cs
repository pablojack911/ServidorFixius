using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorZonaLogistica : ValidadorBase<ZonaLogistica>
    {
        public ValidadorZonaLogistica()
        {
            this.ClearRules(x => x.Codigo);
            this.RuleFor(x => x.Codigo)
                .NotEmpty()
                    .WithMessage("Necesario.")
                .NotNull()
                    .WithMessage("Necesario.")
                .Length(4)
                    .WithMessage("Máximo 4 caracteres.");

        }
    }
}
