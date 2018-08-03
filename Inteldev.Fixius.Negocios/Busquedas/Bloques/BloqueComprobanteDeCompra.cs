using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Busquedas.Partes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Bloques
{
    public class BloqueComprobanteDeCompra : BlockDeBusqueda<DocumentoCompra>
    {
        public override void AgregarPartes(List<object> listaPropiedades, List<Core.Modelo.ParametrosMiniBusca> Parametros)
        {
            var buscaProveedor = new BuscaCodigoProveedor<DocumentoCompra>();
            //var buscaFechaComprobante = new BuscaFechaComprobante<DocumentoCompra>();
            var buscaTipo = new BuscaTipoDocumento<DocumentoCompra>();
            var buscaLetra = new BuscaLetra<DocumentoCompra>();
            var buscaSucursal = new BuscaPorSucursal<DocumentoCompra>();
            var buscaInteger = new BusquedaPorInt<DocumentoCompra>();
            var buscaImporte = new BuscaPorImporte<DocumentoCompra>();
            var buscaRazonSocial = new BuscaPorRazonSocial<DocumentoCompra>();
            var buscaPorPreNumero = new BusquedaPorInt<DocumentoCompra>();
            buscaProveedor.Cargar(Busqueda);
            //buscaFechaComprobante.Cargar(Busqueda);
            buscaTipo.Cargar(Busqueda);
            buscaPorPreNumero.Cargar(Busqueda, "Prenumero");
            buscaLetra.Cargar(Busqueda);
            buscaSucursal.Cargar(Busqueda);
            buscaInteger.Cargar(Busqueda, "Numero");
            buscaImporte.Cargar(Busqueda);
            buscaRazonSocial.Cargar(Busqueda);
            this.Partes.Add(buscaProveedor);
            this.Partes.Add(buscaRazonSocial);
            //this.Partes.Add(buscaFechaComprobante);
            this.Partes.Add(buscaTipo);
            this.Partes.Add(buscaPorPreNumero);
            this.Partes.Add(buscaLetra);
            this.Partes.Add(buscaInteger);
            this.Partes.Add(buscaImporte);
            
        }

        public override void AgregarPartes()
        {
            
        }
    }
}
