using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.GrabadoresFox
{
    public class GrabadorFoxLinea : GrabadorFox<Linea>
    {
        public GrabadorFoxLinea(IDao dao)
            : base(dao)
        { }
        public override void Configurar(Linea entidad)
        {
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
            this.Tabla = "Lineas";
        }

        public override void ConfigurarCamposValores(Linea entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("rubrocja", entidad.ConceptoDeMovimiento == null ? "" : entidad.ConceptoDeMovimiento.Codigo);
            this.CamposValores.Add("condicio", entidad.CondicionDePago == null ? "" : entidad.CondicionDePago.Codigo);
            this.CamposValores.Add("minimos", entidad.Reposicion);
            this.CamposValores.Add("criticos", entidad.StockCritico);
            this.CamposValores.Add("dscto1", entidad.Acuerdo1);
            this.CamposValores.Add("dscto2", entidad.Acuerdo2);
            this.CamposValores.Add("dscto3", entidad.Acuerdo3);
            this.CamposValores.Add("dscto4", entidad.Acuerdo4);
            this.CamposValores.Add("empresa", entidad.Empresa == null ? "" : entidad.Empresa);
            this.CamposValores.Add("permiteconv", entidad.AdmiteConvenio ? 1 : 0);
            this.CamposValores.Add("ventas", entidad.IncluirEnEstadistica ? 1 : 0);
            this.CamposValores.Add("carga_apart", entidad.PrecargaSeparada ? 1 : 0);
            this.CamposValores.Add("novalorizar", entidad.NoValorizar ? 1 : 0);
            this.CamposValores.Add("ocabierta", entidad.PermiteOCAbierta ? 1 : 0);
            this.CamposValores.Add("monobjvta", entidad.MonitorearObjetivos ? 1 : 0);
            this.CamposValores.Add("tomadep3", entidad.IncluirDeposito3 ? 1 : 0);
        }
    }
}
