using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO Canal
    /// </summary>
    public class ValidadorCanal : ValidadorBase<Canal>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorCanal()
        {
            this.ClearRules(c => c.Codigo);
            this.RuleFor(c => c.Codigo)
                .Length(0, 3)
                    .WithMessage("Máximo 3 caracteres")
                .NotEmpty()
                    .WithMessage("Debe ingresar un código")
                .NotNull()
                    .WithMessage("Debe ingresar un código")
                .Must((ramo, codigo) =>
                {
                    if (codigo == null || codigo == string.Empty)
                        return true;
                    else
                        return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
                })
                    .WithMessage("Sólo acepta letras y números");
        }
    }
}
