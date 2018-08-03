using Inteldev.Fixius.Modelo.Proveedores;
using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public interface IBuscadorComprobante
    {
        Inteldev.Fixius.Modelo.Proveedores.DocumentoProveedor BuscarRepetido(string empresa, string sucursal, int ProveedorId, int tipoDoc, string preNum, string num);
    }
}
