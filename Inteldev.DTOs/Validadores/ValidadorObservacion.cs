using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorObservacion : AbstractValidator<ObservacionCliente>, IValidador
    {
        public ValidadorObservacion()
        {
            this.RuleFor(p => p.Nombre)
                .NotEmpty()
                .NotNull();
        }

        public bool ValidaEntidad(object Entidad)
        {
            if (Entidad != null)
                return this.Validate((ObservacionCliente)Entidad).IsValid;
            else
                return true;
        }

        public string ValidaPropiedad(object Entidad, string Propiedad)
        {
            var result = this.Validate((ObservacionCliente)Entidad, Propiedad);
            if (!result.IsValid)
            {
                //unicamente muestra un mensaje de error. Si la propiedad tiene mas de uno
                //entonces va que tener que modificar esto para que devuelva otra cosa.
                return result.Errors.FirstOrDefault().ErrorMessage;
            }
            else
                return string.Empty;
        }
    }
}
