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
    /// Validador para CondicionDePagoCliente
    /// </summary>
    public class ValidadorCondicionDePagoCliente : ValidadorBase<CondicionDePagoCliente>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorCondicionDePagoCliente()
        {
            this.ClearRules(c => c.Codigo);
            this.RuleFor(c => c.CantidadDeDias)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("En números, mayor o igual a 0.");
        }
    }
}
