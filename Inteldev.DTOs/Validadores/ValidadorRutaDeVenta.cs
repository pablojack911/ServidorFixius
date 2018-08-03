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
    /// Validador para DTO RutaDeVenta
    /// </summary>
    public class ValidadorRutaDeVenta : ValidadorBase<RutaDeVenta>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorRutaDeVenta()
        {
            this.ClearRules(r => r.Codigo);
            //this.RuleFor(r => r.Codigo)
            //    .Must((ruta, codigo) =>
            //    {
            //        if (codigo == null || codigo == string.Empty)
            //            return false;
            //        else
            //            return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
            //    })
            //        .WithMessage("Sólo letras y números.")
            //    .Length(4)
            //        .WithMessage("Código no puede superar los 4 dígitos.");

            this.RuleFor(r => r.Empresa)
                .NotNull()
                    .WithMessage("Debe seleccionar una Empresa")
                .NotEmpty()
                    .WithMessage("Debe seleccionar una Empresa");

            this.RuleFor(r => r.Division)
                .NotNull()
                    .WithMessage("Debe seleccionar una División Comercial.");

            this.RuleFor(r => r.RegionDeVenta)
                .NotNull()
                    .WithMessage("Debe seleccionar una Región.");

        }
    }
}
