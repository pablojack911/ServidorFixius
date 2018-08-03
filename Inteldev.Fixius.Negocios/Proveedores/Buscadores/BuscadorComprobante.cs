using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BuscadorComprobante : BuscadorGenerico<Modelo.Proveedores.DocumentoProveedor>, Inteldev.Fixius.Negocios.Proveedores.Buscadores.IBuscadorComprobante
    {
        public BuscadorComprobante(string empresa)
            : base(empresa, "DocumentoProveedor")
        {
        }
        public DocumentoProveedor BuscarRepetido(string empresa, string sucursal, int provId, int tipoDoc, string preNro, string nro)
        {
            return this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.NoCargarNada)
                .Where(p =>
                    p.Empresa == empresa
                    && p.Sucursal == sucursal
                    && p.ProveedorId == provId
                    && p.Numero == nro
                    && p.Prenumero == preNro
                    && p.TipoDocumento == (TipoDocumento)tipoDoc)
                .FirstOrDefault();

        }
    }
}
