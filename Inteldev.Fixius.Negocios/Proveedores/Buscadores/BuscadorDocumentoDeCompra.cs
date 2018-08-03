using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BuscadorDocumentoDeCompra : BuscadorGenerico<Modelo.Proveedores.DocumentoCompra>, Inteldev.Fixius.Negocios.Proveedores.Buscadores.IBuscadorDocumentoDeCompra
    {
        public BuscadorDocumentoDeCompra(string empresa) : base(empresa, "DocumentoCompra") { }
        /// <summary>
        /// Busca entre los documentos de compra aquellos cuyo importe sea distinto al aplicado
        /// </summary>
        /// <returns>lista de documentos de compra</returns>
        public List<DocumentoCompra> BuscaNoAplicados(int ProveedorId)
        {
            return this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.NoCargarNada)
                .Where(p => p.Importe != p.Aplicado && p.ProveedorId == ProveedorId && p.TipoDocumento != TipoDocumento.NotaDeCreditoInterno && p.TipoDocumento != TipoDocumento.NotadeDébitoInterno).ToList();
        }

        public List<DocumentoCompra> BuscaNCInternasPendiente(int ProveedorId)
        {
            return this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.CargarTodo)
                .Where(p => p.TipoDocumento == TipoDocumento.NotaDeCreditoInterno && p.Importe != p.Aplicado && p.Proveedor.Id == ProveedorId).ToList();
        }

        public List<DocumentoCompra> BuscaNDInternasPendiente(int ProveedorId)
        {
            return this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.CargarTodo)
                .Where(p => p.TipoDocumento == TipoDocumento.NotadeDébitoInterno && (p.Importe != p.Aplicado) && p.Proveedor.Id == ProveedorId).ToList();
        }

        public IQueryable<DocumentoCompra> ObtenerDocumento(string empresa, string sucursal, int proveedorId, int tipoDoc, string preNro, string nro)
        {
            var Docs = this.Contexto.Consultar<DocumentoCompra>(CargarRelaciones.CargarTodo);
            //DocumentoCompra doc = null;
            var doc = (from q in Docs
                       where q.Empresa == empresa &&
                             q.Sucursal == sucursal &&
                             q.ProveedorId == proveedorId &&
                             (int)q.TipoDocumento == tipoDoc &&
                             q.Prenumero == preNro &&
                             q.Numero == nro
                       select q);
            return doc;
        }
    }
}
