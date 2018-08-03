using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorLinea : ValidadorBase<Linea>
    {
        public ValidadorLinea()
        {
            this.ClearRules(a => a.Codigo);
            //this.RuleFor(l => l.Codigo)
            //    .Must(p =>
            //    {
            //        if (p != null && p != "")
            //            if (char.IsLetter(p.ToString().First()))
            //                if (!Regex.IsMatch(p.ToString().Substring(1), @"[a-zA-Z]"))
            //                    return true;
            //                else
            //                    return false;
            //            else
            //                if (!Regex.IsMatch(p.ToString(), @"[a-zA-Z]"))
            //                    return true;
            //        return false;
            //    })
            //        .WithMessage("Codigo debe estar vacio o contener solamente una letra para poder realizar la busqueda");
            //this.RuleFor(l => l.Codigo)
            //    .NotEmpty()
            //        .WithMessage("Por ahora, no vacío.")
            //    .NotNull()
            //        .WithMessage("Por ahora, no vacío.");
        }
    }
}
