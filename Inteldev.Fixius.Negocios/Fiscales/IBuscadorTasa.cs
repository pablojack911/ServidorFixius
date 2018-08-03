using System;
namespace Inteldev.Fixius.Negocios.Fiscales
{
    public interface IBuscadorTasa
    {
        decimal ObtenerTasa(Inteldev.Fixius.Servicios.DTO.Proveedores.TipoConcepto tipoConcepto);
        decimal ObtenerTasa(string tipoConcepto);
    }
}
