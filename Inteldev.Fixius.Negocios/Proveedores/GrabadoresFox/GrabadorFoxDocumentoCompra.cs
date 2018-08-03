using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.GrabadoresFox
{
    public class GrabadorFoxDocumentoCompra : GrabadorFox<DocumentoCompra>
    {
        public string tipoDocumento { get; set; }
        public GrabadorFoxDocumentoCompra(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(DocumentoCompra entidad)
        {
            this.Tabla = "Ivacpras";
            this.ClavePrimaria = "Proveedor+tipo+letra+sucursal+numero";
            tipoDocumento = this.ObtenerTipo(entidad.TipoDocumento);
            this.ValorClavePrimaria = string.Concat(entidad.Proveedor.Codigo, tipoDocumento, entidad.Letra, entidad.Prenumero.ToString().PadLeft(4, '0'), entidad.Numero.ToString().PadLeft(8, '0'));
        }

        private string obtenerCoc()
        {
            var comando = this.Dao.CrearDbCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "sys(2015)";
            string sys2015 = comando.ExecuteScalar().ToString();
            //this.Dao.Desconectar();
            return "CARGACOM_" + sys2015;
        }

        private string ObtenerTipo(TipoDocumento tipoDocumento)
        {
            switch (tipoDocumento)
            {
                case TipoDocumento.Factura:
                    return "001";
                    break;
                case TipoDocumento.NotaDeCredito:
                    return "005";
                    break;
                case TipoDocumento.NotaDeDebito:
                    return "003";
                    break;
                case TipoDocumento.OrdenDePago:
                    return "008";
                    break;
                case TipoDocumento.NotaDeCreditoInterno:
                    return "005";
                    break;
                case TipoDocumento.NotadeDébitoInterno:
                    return "003";
                    break;
                default:
                    return "001";
                    break;
            }
        }

        public override void ConfigurarCamposValores(DocumentoCompra entidad)
        {
            string coc = this.obtenerCoc();

            SetearValores("fecha", DateTimeToDateFox(entidad.Fecha), "date()");
            SetearValores("fechacon", DateTimeToDateFox(entidad.FechaContable), "date()");
            SetearValores("tipo", tipoDocumento, "");
            SetearValores("letra", entidad.Letra.ToString(), "");
            SetearValores("sucursal", entidad.Prenumero.ToString().PadLeft(4, '0'), "");
            SetearValores("numero", entidad.Numero.ToString().PadLeft(8, '0'), "");
            SetearValores("proveedor", entidad.Proveedor.Codigo, "");
            SetearValores("nombre", entidad.Proveedor.RazonSocial, "");
            SetearValores("condiva", GrabadorFoxProveedor.CondicionAnteIva(entidad.Proveedor.CondicionAnteIva), "");
            SetearValores("cuit", entidad.Proveedor.Cuit, "");
            SetearValores("empresa", entidad.Empresa, "");
            SetearValores("es_totales", "S", "");

            var neto = entidad.ItemsConceptos.Where(p => p.Tipo == TipoConcepto.Neto1).Sum(p => p.Debe + p.Haber);
            var exento = entidad.ItemsConceptos.Where(p => p.Tipo == TipoConcepto.Exento).Sum(p => p.Debe + p.Haber);
            var iva = entidad.ItemsConceptos.Where(p => p.Tipo == TipoConcepto.IvaTasaDiferencial ||
                                                        p.Tipo == TipoConcepto.IvaTasaGeneral ||
                                                        p.Tipo == TipoConcepto.IvaTasaReducida).Sum(p => p.Debe + p.Haber);
            var percepcion = entidad.ItemsConceptos.Where(p => p.Tipo == TipoConcepto.PercepcionIva ||
                                                               p.Tipo == TipoConcepto.PercepcionIIBB).Sum(p => p.Debe + p.Haber);
            var importe = entidad.ItemsConceptos.Where(p => p.Tipo == TipoConcepto.Final).Sum(p => p.Debe + p.Haber);

            SetearValores("neto", neto, 0);
            SetearValores("exento", exento, 0);
            SetearValores("iva", iva, 0);
            SetearValores("percepcion", percepcion, 0);
            SetearValores("importe", importe, 0);
            SetearValores("coc", coc, "");

            var grabadorcompras = FabricaNegocios._Resolver<GrabadorFoxCompras>();
            grabadorcompras.ValorClavePrimaria = this.ValorClavePrimaria;
            grabadorcompras.tipoDocumento = tipoDocumento;
            grabadorcompras.coc = coc;
            grabadorcompras.Dao = this.Dao;
            grabadorcompras.Grabar(entidad);

            var grabadorsubcompras = FabricaNegocios._Resolver<GrabadorFoxSubCompras>();
            grabadorsubcompras.ValorClavePrimaria = this.ValorClavePrimaria;
            grabadorsubcompras.tipoDocumento = tipoDocumento;
            grabadorsubcompras.Dao = this.Dao;
            grabadorcompras.coc = coc;
            grabadorsubcompras.GrabarSubCompras(entidad);
        }
    }
}
