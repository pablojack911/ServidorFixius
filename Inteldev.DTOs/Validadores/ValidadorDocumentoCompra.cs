using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Inteldev.Fixius.Servicios.DTO.Validadores
{
    public class ValidadorDocumentoCompra : ValidadorBase<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>
    {
        public ValidadorDocumentoCompra()
        {
            this.RuleFor(doc => doc.Autoriza).Must((doc,autoriza) => 
            {
                if (doc.Proveedor.RequiereDatosDeAutorizacion)
                {
                    if (autoriza == null)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            });
            this.RuleFor(doc => doc.Motivo).Must((doc, motivo) =>
            {
                if (doc.Proveedor.RequiereDatosDeAutorizacion)
                {
                    if (motivo == null || String.Empty == motivo)
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            });
            //this.RuleFor(doc => doc.FechaContable).Must((doc,fecha) => 
            //{
            //    var fech = fecha.Date;
            //    if (doc.TipoDocumento == Proveedores.TipoDocumento.NotaDeCreditoInterno || doc.TipoDocumento == Proveedores.TipoDocumento.NotadeDébitoInterno)
            //        return true;
            //    else
            //    {
            //        if ((fech > doc.Empresa.FechaDesde.Date || fech == doc.Empresa.FechaDesde.Date) && (fech < doc.Empresa.FechaHasta.Date || fech == doc.Empresa.FechaHasta.Date))
            //            return true;
            //        else
            //            return false;
            //    }
            //});
        }
    }
}
