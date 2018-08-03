using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador utilizado para los siguientes DTOs:
    ///     Cobrador
    ///     Preventista
    ///     Supervisor
    ///     Vendedor
    ///     Jefe
    /// </summary>
    public class ValidadorPreventa : ValidadorBase<Preventa.Preventa>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorPreventa()
        {
            this.ClearRules(p => p.Codigo);
            this.RuleFor(p => p.Codigo)
                .Must((preventa, codigo) =>
                {
                    if (codigo == null || codigo == string.Empty)
                        return false;
                    else
                        return codigo.All(x => Regex.IsMatch(x.ToString(), "[a-zA-Z0-9]"));
                })
                    .WithMessage("Sólo letras y números.")
                .Length(2)
                    .WithMessage("Código debe ser 2 caracteres.");

        }
    }
}
