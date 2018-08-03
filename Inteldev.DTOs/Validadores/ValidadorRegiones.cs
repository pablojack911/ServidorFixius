using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Text.RegularExpressions;
using Inteldev.Core.DTO;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO GeoRegionDeVenta y DTO RegionDeVenta
    /// </summary>
    public class ValidadorRegiones : ValidadorBase<Regiones>
    {
        /// <summary>
        /// Constructor con las reglas de validacion
        /// </summary>
        public ValidadorRegiones()
        {
            this.ClearRules(g => g.Codigo);
            this.RuleFor(g => g.Codigo)
                .NotEmpty()
                    .WithMessage("Requerido.")
                .NotNull()
                    .WithMessage("Requerido.")
                .Length(2)
                    .WithMessage("Máximo 2 caracteres.")
                .Must((geo, codigo) =>
                {
                    if (codigo == null)
                        return false;
                    else
                        return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
                })
                    .WithMessage("Sólo letras y números.");
        }
    }
}
