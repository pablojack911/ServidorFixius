using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Inteldev.Fixius.Servicios.DTO.Proveedores;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorFactura : ValidadorBase<DocumentoCompra>
    {
        public ValidadorFactura()
        {
            this.RuleFor(p => p.Numero).NotEmpty().NotNull().WithMessage("Este campo tiene que contener algo");
            this.RuleFor(p => p.Prenumero).NotEmpty().NotNull().WithMessage("Este campo tiene que contener algo");
            this.RuleFor(p => p.Proveedor).NotEmpty().NotNull().WithMessage("Este campo tiene que contener algo");
        }
    }
}
