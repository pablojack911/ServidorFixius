using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System.Threading.Tasks;
using System.Data;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorIngreso : ValidadorBase<Servicios.DTO.Stock.Ingreso>
    {
        public ValidadorIngreso()
        {
            this.RuleFor(p => p.Facturas).NotEmpty().NotNull().WithMessage("Este campo tiene que contener algo");
            this.RuleFor(p => p.Facturas).Must((ingreso, facturas) => {
                var cantidad = 0;
                foreach (DataRow row in ingreso.Items.Rows)
                {
                    cantidad += (int)row["Bultos"];
                }
                if (cantidad == ingreso.Facturas.Count)
                    return true;
                else
                    return false;
            });
        }
    }
}
