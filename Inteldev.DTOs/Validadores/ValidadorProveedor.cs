using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorProveedor : ValidadorBase<Proveedor>
    {
        public ValidadorProveedor()
        {
            this.ClearRules(proveedor => proveedor.Codigo);
            this.RuleFor(proveedor => proveedor.Codigo)
                .Must((proveedor, codigo) =>
                {
                    if (codigo == null || codigo == string.Empty)
                        return true;
                    else
                        return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
                })
                    .WithMessage("Sólo letras y números.")
                .Length(0, 5)
                    .WithMessage("Código no puede superar los 5 dígitos.");

            this.RuleFor(proveedor => proveedor.RazonSocial)
                .NotEmpty()
                    .WithMessage("Este campo no puede estar vacio")
                .NotNull()
                    .WithMessage("Este campo no puede estar vacio");
            //this.RuleFor(proveedor => proveedor.ConceptoDeMovimiento).NotNull().NotEmpty().WithMessage("Concepto de Movimiento no puede estar vacio");
            //this.RuleFor(proveedor => proveedor.CondicionDePago).NotNull().NotEmpty().WithMessage("Condicion no puede estar vacio");

            this.RuleFor(proveedor => proveedor.Cuit)
                .NotEmpty()
                    .WithMessage("CUIT no puede estar vacío.")
                    .When(proveedor => proveedor.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal)
                .NotNull()
                    .WithMessage("CUIT no puede estar vacío.")
                    .When(proveedor => proveedor.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal)
                .Must((proveedor, cuit) =>
                {
                    var validadorCuit = new ValidadorCUIT();
                    return validadorCuit.ValidaCuit(cuit);
                })
                    .WithMessage("El CUIT ingresado es incorrecto.")
                    .When(proveedor => proveedor.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal);

            this.RuleFor(p => p.TipoProveedor)
                .NotNull()
                    .WithMessage("Seleccione un Tipo de Proveedor.");

            this.RuleFor(p => p.CondicionAnteIIBB)
                .NotNull()
                    .WithMessage("Debe indicar una Condición ante IIBB.");

            this.RuleFor(p => p.Iibb)
                .NotEmpty()
                    .WithMessage("Debe indicar el Número IIBB.")
                    .When(prov =>
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DMOnceVeitiseis ||
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DNBOcho ||
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DNBTreintaYOcho)
                .NotNull()
                    .WithMessage("Debe indicar el Número IIBB.")
                    .When(prov =>
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DMOnceVeitiseis ||
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DNBOcho ||
                        prov.CondicionAnteIIBB == Fiscal.CondicionAnteIIBB.DNBTreintaYOcho);
        }
    }
}

