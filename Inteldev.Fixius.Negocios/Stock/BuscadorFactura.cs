using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock
{
    public class BuscadorFactura : BuscadorGenerico<Modelo.Proveedores.DocumentoCompra>, Inteldev.Fixius.Negocios.Stock.IBuscadorFactura
    {
        public BuscadorFactura(string empresa) : base(empresa,"DocumentoCompra")
        {

        }

        public DocumentoCompra BuscaFactura(int proveedorId, string prenumero, string numero)
        {
            return this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.CargarEntidades)
                .Where(p=>p.ProveedorId == proveedorId && p.Prenumero == prenumero && p.Numero==numero && p.TipoDocumento == TipoDocumento.Factura).FirstOrDefault();
        }
    }
}
