using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO Envase
    /// </summary>
    public class ValidadorEnvase : ValidadorBase<Envase>
    {
        /// <summary>
        /// Constructor con reglas de Validacion
        /// </summary>
        public ValidadorEnvase()
        {
            this.ClearRules(e => e.Codigo);

            //this.RuleFor(e => e.DatosOld.Articulo)
            //    .NotNull()
            //        .WithMessage("Artículo no puede estar vacío.");
            
        }
    }
}
