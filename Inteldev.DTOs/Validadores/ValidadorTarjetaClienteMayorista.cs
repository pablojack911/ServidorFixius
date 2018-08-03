using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO TarjetaClienteMayorista
    /// </summary>
    public class ValidadorTarjetaClienteMayorista : ValidadorBase<TarjetaClienteMayorista>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorTarjetaClienteMayorista()
        {
            this.ClearRules(t => t.Codigo);

            Func<TarjetaClienteMayorista, string, bool> validaDesdeHasta = (tar, hasta) =>
            {
                if (tar.Desde != null && tar.Hasta != null)
                    if (tar.Desde.Length == 12 && tar.Hasta.Length == 12)
                    {
                        var res = string.Compare(tar.Desde, tar.Hasta);
                        if (res < 0)
                            return true;
                    }
                return false;
            };

            this.RuleFor(t => t.Desde)
                .Length(12)
                    .WithMessage("Deben ser 12 caracteres")
                .Must(validaDesdeHasta)
                    .WithMessage("Debe ser inferior al Hasta");

            this.RuleFor(t => t.Hasta)
                .Length(12)
                    .WithMessage("Deben ser 12 caracteres")
                .Must(validaDesdeHasta)
                    .WithMessage("Debe ser superior a Desde");

        }
    }
}
