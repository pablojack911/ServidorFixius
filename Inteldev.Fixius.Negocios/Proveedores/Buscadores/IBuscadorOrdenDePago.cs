using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public interface IBuscadorOrdenDePago
    {
        System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.OrdenDePago> BuscaNoAplicados(int ProveedorId);
    }
}
