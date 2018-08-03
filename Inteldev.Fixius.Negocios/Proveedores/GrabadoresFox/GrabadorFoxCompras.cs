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
    public class GrabadorFoxCompras : GrabadorFox<DocumentoCompra>
    {
        public GrabadorFoxCompras(IDao dao)
            : base(dao)
        {

        }

        public string tipoDocumento { get; set; }
        public string coc { get; set; }
        public override void Configurar(DocumentoCompra entidad)
        {
            this.Tabla = "compras";
            this.ClavePrimaria = "Proveedor+tipo+letra+sucursal+numero";
        }

        public override void ConfigurarCamposValores(DocumentoCompra entidad)
        {
            SetearValores("fecha_comp", this.DateTimeToDateFox(entidad.FechaContable), "date()");
            SetearValores("fecha_venc", this.DateTimeToDateFox(entidad.FechaVencimiento), "date()");
            SetearValores("fecha_iva", this.DateTimeToDateFox(entidad.FechaIngreso), "date()");
            SetearValores("proveedor", entidad.Proveedor.Codigo, "");
            SetearValores("tipo", tipoDocumento, "");
            SetearValores("letra", entidad.Letra.ToString(), "");
            SetearValores("sucursal", entidad.Prenumero.ToString().PadLeft(4, '0'), "");
            SetearValores("numero", entidad.Numero.ToString().PadLeft(8, '0'), "");
            SetearValores("empresa", entidad.Empresa, "");

            decimal debe = 0;
            decimal haber = 0;
            if (entidad.TipoDocumento == TipoDocumento.Factura || entidad.TipoDocumento == TipoDocumento.NotaDeDebito)
            {
                haber = entidad.Importe;
            }
            else
            {
                debe = entidad.Importe;
            }

            SetearValores("haber", haber, 0);
            SetearValores("debe", debe, 0);
            SetearValores("coc", coc, "");

            if (entidad.Autoriza != null && entidad.Motivo != null)
                SetearValores("observa", entidad.Autoriza.Nombre.Trim() + "|" + entidad.Motivo.Trim(), "");

        }
    }
}
