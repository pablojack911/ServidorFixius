using Inteldev.Core.Negocios.Mapeador;
using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Mapeadores
{
    public interface IMapeadorOrdenDePago : IMapeadorGenerico<Modelo.Proveedores.OrdenDePago,Servicios.DTO.Proveedores.OrdenDePago>
    {
        void CargaOrdenesDePago(System.Data.DataTable tabla, dynamic items);
        void CargaDocumentoCompra(System.Data.DataTable tabla, dynamic items);
    }
}
