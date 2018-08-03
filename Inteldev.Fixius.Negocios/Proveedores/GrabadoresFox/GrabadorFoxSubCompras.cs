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
    public class GrabadorFoxSubCompras : GrabadorFox<DocumentoCompra>
    {
        public string tipoDocumento { get; set; }
        object clave;
        public string coc { get; set; }
        public GrabadorFoxSubCompras(IDao dao)
            : base(dao)
        {
            this.Tabla = "subcpras";
            this.ClavePrimaria = "Proveedor+tipo+letra+sucursal+numero+cuenta";
        }


        public bool GrabarSubCompras(DocumentoCompra entidad)
        {
            clave = this.ValorClavePrimaria;
            bool ok = false;
            foreach (var item in entidad.ItemsConceptos)
            {
                this.CamposValores.Clear();
                this.Configurar(entidad, item);
                ok = this.Grabar(entidad);
            }
            return ok;
        }
        public void Configurar(DocumentoCompra entidad, ItemsConceptos item)
        {
            this.ValorClavePrimaria = this.clave + item.Concepto.Codigo;
            SetearValores("fecha_com", DateTimeToDateFox(entidad.Fecha), "date()");
            SetearValores("fecha_con", DateTimeToDateFox(entidad.FechaContable), "date()");
            SetearValores("fecha_vto", DateTimeToDateFox(entidad.FechaVencimiento), "date()");
            SetearValores("fecha_ing", DateTimeToDateFox(entidad.FechaIngreso), "date()");
            SetearValores("tipo", tipoDocumento, "");
            SetearValores("letra", entidad.Letra.ToString(), "");
            SetearValores("sucursal", entidad.Prenumero.ToString().PadLeft(4, '0'), "");
            SetearValores("numero", entidad.Numero.ToString().PadLeft(8, '0'), "");
            SetearValores("proveedor", entidad.Proveedor.Codigo, "");
            SetearValores("empresa", entidad.Empresa, "");

            SetearValores("cuenta", item.Concepto.Codigo, "");
            SetearValores("concepto", item.Concepto.Nombre, "");
            SetearValores("debe", item.Debe, "");
            SetearValores("haber", item.Haber, "");
            SetearValores("coc", this.coc, "");
            SetearValores("rubroiva", this.BoolToInt(item.Tipo == TipoConcepto.IvaTasaGeneral || item.Tipo == TipoConcepto.IvaTasaDiferencial || item.Tipo == TipoConcepto.IvaTasaReducida), "");
            SetearValores("rubrototal", this.BoolToInt(item.Tipo == TipoConcepto.Final), "");
            SetearValores("rubroneto", this.BoolToInt(item.Tipo == TipoConcepto.Neto1), "");
            SetearValores("rubroexento", this.BoolToInt(item.Tipo == TipoConcepto.Exento), "");
            SetearValores("rubropercep", this.BoolToInt(item.Tipo == TipoConcepto.PercepcionIva || item.Tipo == TipoConcepto.PercepcionIva), "");

        }

        public override void Configurar(DocumentoCompra entidad)
        {

        }

        public override void ConfigurarCamposValores(DocumentoCompra entidad)
        {

        }
    }
}
