using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
namespace Inteldev.Fixius.Negocios.Stock
{
    public interface IBuscadorFactura : IBuscador<DocumentoCompra>
    {
        DocumentoCompra BuscaFactura(int proveedorId, string prenumero, string numero);
    }
}
