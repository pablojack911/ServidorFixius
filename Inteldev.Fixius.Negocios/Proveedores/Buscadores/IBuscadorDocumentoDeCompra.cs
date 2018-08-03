using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public interface IBuscadorDocumentoDeCompra
    {
        System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra> BuscaNoAplicados(int ProveedorId);
        System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra> BuscaNCInternasPendiente(int ProveedorId);
        System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra> BuscaNDInternasPendiente(int ProveedorId);
    }
}
