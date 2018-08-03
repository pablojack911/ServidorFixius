using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Core.DTO.Validaciones;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO GrupoCliente
    /// </summary>
    public class ValidadorGrupoCliente : ValidadorBase<GrupoCliente>
    {
        /// <summary>
        /// Constructor con reglas de valdacion
        /// </summary>
        public ValidadorGrupoCliente()
        {
            this.ClearRules(gc => gc.Codigo);

            //this.RuleFor(grupo => grupo.Codigo)
            //    .Must((grupo, codigo) =>
            //    {
            //        if (codigo == null || codigo == string.Empty)
            //            return false;
            //        else
            //            return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
            //    })
            //        .WithMessage("Sólo letras y números.")
            //    .Length(0, 3)
            //        .WithMessage("Código no puede superar los 3 dígitos.");
        }
    }
}
