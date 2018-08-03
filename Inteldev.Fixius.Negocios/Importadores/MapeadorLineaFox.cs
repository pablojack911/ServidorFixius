using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorLineaFox : MapeadorFox<Linea>
    {
        public MapeadorLineaFox(IDao con, string empresa, string entidad)
            : base("lineas", "codigo", con, empresa, entidad)
        {

        }

        protected override Linea Mapear(Linea entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            entidad.ConceptoDeMovimiento = this.BuscarEntidadPorCodigo<ConceptoDeMovimiento>(registro["rubrocja"].ToString());
            entidad.CondicionDePago = this.BuscarEntidadPorCodigo<CondicionDePagoCliente>(registro["condicio"].ToString());
            entidad.Reposicion = int.Parse(registro["minimos"].ToString());
            entidad.StockCritico = int.Parse(registro["criticos"].ToString());
            entidad.Acuerdo1 = decimal.Parse(registro["dscto1"].ToString());
            entidad.Acuerdo2 = decimal.Parse(registro["dscto2"].ToString());
            entidad.Acuerdo3 = decimal.Parse(registro["dscto3"].ToString());
            entidad.Acuerdo4 = decimal.Parse(registro["dscto4"].ToString());
            entidad.Empresa = registro["empresa"].ToString();
            entidad.AdmiteConvenio = this.ObtenerBoolDeString(registro["permiteconv"].ToString());
            entidad.IncluirEnEstadistica = this.ObtenerBoolDeString(registro["ventas"].ToString());
            entidad.PrecargaSeparada = this.ObtenerBoolDeString(registro["carga_apart"].ToString());
            entidad.NoValorizar = this.ObtenerBoolDeString(registro["novalorizar"].ToString());
            entidad.PermiteOCAbierta = this.ObtenerBoolDeString(registro["ocabierta"].ToString());
            entidad.MonitorearObjetivos = this.ObtenerBoolDeString(registro["monobjvta"].ToString());
            entidad.IncluirDeposito3 = this.ObtenerBoolDeString(registro["tomadep3"].ToString());

            return entidad;
        }
    }
}
