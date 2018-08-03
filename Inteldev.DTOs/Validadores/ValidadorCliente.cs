using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorCliente : ValidadorBase<Inteldev.Fixius.Servicios.DTO.Clientes.Cliente>
    {
        public ValidadorCliente()
        {
            this.ClearRules(cliente => cliente.Codigo);
            //this.RuleFor(cliente => cliente.Codigo)
            //    .Must((cliente, codigo) =>
            //    {
            //        if (codigo == null || codigo == string.Empty)
            //            return true;
            //        else
            //            return codigo.All(p => Regex.IsMatch(p.ToString(), "[a-zA-Z0-9]"));
            //    })
            //        .WithMessage("Sólo letras y números.")
            //    .Length(0, 5)
            //        .WithMessage("Código no puede superar los 5 dígitos.");

            this.RuleFor(cliente => cliente.RazonSocial)
                .NotNull()
                    .WithMessage("Campo no puede estar vacio.")
                .NotEmpty()
                    .WithMessage("Campo no puede estar vacio.");

            this.RuleFor(cliente => cliente.NombreFantasia)
                .NotNull()
                    .WithMessage("Campo no puede estar vacio.")
                .NotEmpty()
                    .WithMessage("Campo no puede estar vacio.");

            this.ClearRules(cliente => cliente.Nombre);

            //this.RuleFor(cliente => cliente.Apellido)
            //    .NotNull()
            //        .WithMessage("Campo no puede estar vacio.")
            //    .NotEmpty()
            //        .WithMessage("Campo no puede estar vacio.");


            //this.RuleFor(cliente => cliente.Domicilio).NotEmpty().NotEmpty().WithMessage("Domicilio no puede estar vacio");
            //this.RuleFor(cliente => cliente.Domicilio.Calle).NotEmpty().NotNull();
            //this.RuleFor(cliente => cliente.Domicilio.Numero).NotEmpty().NotNull();

            this.RuleFor(cliente => cliente.NumeroDocumentoCliente)
                .NotEmpty()
                    .WithMessage("Debe indicar número de documento.")
                    .When(cliente => cliente.CondicionAnteIva == Fiscal.CondicionAnteIva.ConsumidorFinal)
                .NotNull()
                    .WithMessage("Debe indicar número de documento.")
                    .When(cliente => cliente.CondicionAnteIva == Fiscal.CondicionAnteIva.ConsumidorFinal);
            this.RuleFor(cliente => cliente.NumeroDocumentoCliente)
                .Must((cliente, dni) =>
                {
                    int num = 0;
                    return int.TryParse(dni, out num);
                })
                    .WithMessage("Número de documento debe contener números solamente.")
                    .When(cliente => cliente.Id == 0 && cliente.CondicionAnteIva == Fiscal.CondicionAnteIva.ConsumidorFinal);

            this.RuleFor(cliente => cliente.Cuit)
                .NotEmpty()
                    .WithMessage("CUIT no puede estar vacío.")
                    .When(cliente => cliente.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal)
                .NotNull()
                    .WithMessage("CUIT no puede estar vacío.")
                    .When(cliente => cliente.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal)
                .Must((cliente, cuit) =>
                {
                    var validadorCuit = new ValidadorCUIT();
                    return validadorCuit.ValidaCuit(cuit);
                })
                    .WithMessage("El CUIT ingresado es incorrecto.")
                    .When(cliente => cliente.CondicionAnteIva != Fiscal.CondicionAnteIva.ConsumidorFinal);


            this.RuleFor(cliente => cliente.NumeroIibb)
                .NotEmpty()
                    .WithMessage("Número de IIBB no puede estar vacío.")
                    .When(cliente => cliente.CondicionAnteIibb != Fiscal.CondicionAnteIIBB.NoCorrespondeExento && cliente.CondicionAnteIibb != Fiscal.CondicionAnteIIBB.NoAsignado)
                .NotNull()
                    .WithMessage("Número de IIBB no puede estar vacío.")
                    .When(cliente => cliente.CondicionAnteIibb != Fiscal.CondicionAnteIIBB.NoCorrespondeExento && cliente.CondicionAnteIibb != Fiscal.CondicionAnteIIBB.NoAsignado);
            //this.RuleFor(cliente => cliente.NumeroIibb).Must((cliente, numero) =>
            //{
            //    if (cliente.CondicionAnteIibb == Fiscal.CondicionAnteIIBB.NoCorrespondeExento || cliente.CondicionAnteIibb == Fiscal.CondicionAnteIIBB.NoAsignado)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        if (numero != null && numero != string.Empty)
            //            return true;
            //        else
            //            return false;
            //    }
            //});

            var fecha_min = DateTime.Today.AddMonths(-2);
            var fecha_max = DateTime.Today.AddDays(1);

            this.RuleFor(cliente => cliente.FechaAlta)
                .GreaterThan(fecha_min)
                    .WithMessage("La fecha indicada excede los 2 meses.")
                    .When(cliente => cliente.Id == 0)
                .LessThan(fecha_max)
                    .WithMessage("La fecha no debe ser mayor a la actual.")
                    .When(cliente => cliente.Id == 0);

            this.RuleFor(cliente => cliente.Email)
                .EmailAddress()
                    .WithMessage("E-Mail inválido.")
                    .Unless(cliente => cliente.Email == string.Empty || cliente.Email == null);

            this.RuleFor(cliente => cliente.VencimientoReba)
                .GreaterThan(DateTime.Today)
                    .WithMessage("La fecha debe ser mayor a la actual.")
                    .When(cliente => cliente.Id == 0 && cliente.NumeroReba != null && cliente.NumeroReba.Length > 0);

            Func<Cliente, Ramo, bool> EncontrarRamoEntarjetas = (cli, ramo) =>
            {
                bool encontro = false;
                if (cli.Ramo != null)
                {
                    var ramocodigo = cli.Ramo.Codigo;

                    encontro = cli.TarjetasCliente.Any(t => t.TipoTarjeta.Ramos.Any(r => r.Codigo == ramocodigo));
                }
                return encontro;
            };

            this.RuleFor(cliente => cliente.Ramo)
                .NotNull()
                    .WithMessage("Requerido.");
            //this.RuleFor(cliente => cliente.Ramo)
            //    .Must(EncontrarRamoEntarjetas)
            //        .WithMessage("El ramo no corresponde con las tarjetas asignadas actualmente.")
            //        .When(cliente => cliente.TarjetasCliente.Count > 0);

            //this.RuleFor(cliente => cliente.CuentaPadre)
            //    .Must(cli =>
            //    {
            //        if (cli.CuentaPadre != null)
            //            if (cli.CuentaPadre.Codigo == cli.Codigo)
            //                return false;
            //        return true;
            //    })
            //        .When(c => c.Id != 0 && c.CuentaPadre != null)
            //        .WithMessage("Cuenta Padre no puede ser el mismo cliente.");
            this.RuleFor(cliente => cliente.CuentaPadre)
               .NotEqual(cliente => cliente)
                   .When(cliente => cliente.Id != 0)
                   .WithMessage("Cuenta Padre no puede ser el mismo cliente.");

            this.RuleFor(cliente => cliente.ZonaGeografica)
                .NotNull()
                    .WithMessage("Requerido.");

            //this.RuleFor(cliente => cliente.DatosOld.Domicilio)
            //    .NotEmpty()
            //        .WithMessage("Requerido.")
            //    .NotNull()
            //        .WithMessage("Requerido.");
        }
    }
}
