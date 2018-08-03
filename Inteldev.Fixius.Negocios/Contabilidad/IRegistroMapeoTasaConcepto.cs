using System;
namespace Inteldev.Fixius.Negocios.Contabilidad
{
    public interface IRegistroMapeoTasaConcepto
    {
        Inteldev.Fixius.Servicios.DTO.Proveedores.TipoConcepto? ObtenerConcepto(Inteldev.Fixius.Servicios.DTO.Contabilidad.EnumTasas tasa);
        Inteldev.Fixius.Servicios.DTO.Contabilidad.EnumTasas? ObtenerTasa(Inteldev.Fixius.Servicios.DTO.Proveedores.TipoConcepto concepto);
    }
}
