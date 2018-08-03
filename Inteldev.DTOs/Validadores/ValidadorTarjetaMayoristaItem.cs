using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Inteldev.Core.CodeBar;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    /// <summary>
    /// Validador para DTO TarjetaMayoristaItem
    /// </summary>
    public class ValidadorTarjetaMayoristaItem : ValidadorBase<TarjetaMayoristaItem>
    {
        /// <summary>
        /// Constructor con reglas de validacion
        /// </summary>
        public ValidadorTarjetaMayoristaItem()
        {
            this.ClearRules(tarj => tarj.Codigo);
            this.ClearRules(tarj => tarj.Nombre);

            Func<TarjetaMayoristaItem, string, bool> validaDesdeHasta = (tar, cod) =>
            {
                if (cod != null && tar.TipoTarjeta != null && tar.TipoTarjeta.Desde != null && tar.TipoTarjeta.Hasta != null && cod.Length == 13)
                {
                    var cod12 = cod.Substring(0, 12);
                    var res = string.Compare(cod12, tar.TipoTarjeta.Desde);
                    var res2 = string.Compare(cod12, tar.TipoTarjeta.Hasta);
                    if (res > 0 && res2 < 0)
                        return true;
                }
                return false;
            };

            Func<TarjetaMayoristaItem, String, bool> validaCodigoSinLetra = (t, Codigo) =>
                {
                    long numero = 0;
                    if (t.Codigo == null || t.Codigo == string.Empty)
                        return true;
                    else
                    {
                        var ret = false;
                        ret = long.TryParse(t.Codigo, out numero);
                        return ret;
                    }
                };

            this.RuleFor(tarj => tarj.Codigo)
                .Must(validaCodigoSinLetra)
                     .WithMessage("Código no acepta letras.")
                .Length(13)
                    .WithMessage("Código debe ser 13 dígitos.")
                .Must(validaDesdeHasta)
                    .WithMessage("Código fuera de rango.")
                .Must(tar => (tar != null) ? CodeBar.Validar<Ean13>(tar) : false)
                    .WithMessage("Código inválido");





        }
    }
}
