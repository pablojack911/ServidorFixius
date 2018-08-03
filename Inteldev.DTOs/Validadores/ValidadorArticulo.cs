using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System.Threading.Tasks;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorArticulo : ValidadorBase<Inteldev.Fixius.Servicios.DTO.Articulos.Articulo>
    {
        public ValidadorArticulo()
        {
            this.ClearRules(a => a.Codigo);

            this.RuleFor(p => p.Nombre)
                .NotNull()
                    .WithMessage("Descripción no puede estar vacío.")
                .NotEmpty()
                    .WithMessage("Descripción no puede estar vacío.");

            this.RuleFor(p => p.NombreBreve)
                .NotNull()
                    .WithMessage("Campo no puede estar vacío.")
                .NotEmpty()
                    .WithMessage("Campo no puede estar vacío.");
            //this.RuleFor(p => p.TasasDeIva).NotNull().NotEmpty().WithMessage("Tasas de IVA no puede estar vacío");
            //this.RuleFor(p => p.Proveedor).NotNull().NotEmpty().WithMessage("Proveedor no puede estar vacío");
            //this.RuleFor(p => p.DatosOld.Linea).NotNull().NotEmpty().WithMessage("Linea no puede estar vacío");
            //this.RuleFor(p => p.DatosOld.Rubro).NotNull().NotEmpty().WithMessage("Rubro no puede estar vacío");
        }
    }
}
