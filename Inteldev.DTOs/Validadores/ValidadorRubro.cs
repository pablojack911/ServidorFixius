using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Core.DTO.Validaciones;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO Rubro
    /// </summary>
    public class ValidadorRubro : ValidadorBase<Rubro>
    {
        /// <summary>
        /// Constructor con las reglas de validación
        /// </summary>
        public ValidadorRubro()
        {
            this.ClearRules(r => r.Codigo);
            //this.RuleFor(r => r.Codigo)
            //    .Must((rubro, codigo) =>
            //    {
            //        if (codigo == null || codigo == string.Empty)
            //            return true;
            //        else
            //            return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
            //    })
            //        .WithMessage("Sólo letras y números.")
            //    .Length(3)
            //        .WithMessage("Código no puede superar los 3 dígitos.")
            //    .NotEmpty()
            //        .WithMessage("Requerido.")
            //    .NotNull()
            //        .WithMessage("Requerido.");
        }
    }
}
