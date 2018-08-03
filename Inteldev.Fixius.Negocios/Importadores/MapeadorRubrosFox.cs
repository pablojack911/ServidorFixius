using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    /// <summary>
    /// Mapeador para recibir datos de la table rubros de Fox
    /// </summary>
    public class MapeadorRubrosFox : MapeadorFox<Rubro>
    {
        public MapeadorRubrosFox(IDao con, string empresa, string entidad)
            : base("rubros", "codigo", con, empresa, entidad)
        {

        }

        protected override Rubro Mapear(Rubro entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.CondicionDePago = this.BuscarEntidadPorCodigo<CondicionDePagoCliente>(registro["condicio"].ToString().Trim());
            entidad.AdmiteConvenio = this.ObtenerBoolDeString(registro["permiteconv"].ToString().Trim());
            entidad.NoIncluirEnListaDePrecios = this.ObtenerBoolDeString(registro["preventa"].ToString().Trim());
            entidad.Acuerdo1 = Decimal.Parse(registro["dscto1"].ToString().Trim());
            entidad.Acuerdo2 = Decimal.Parse(registro["dscto2"].ToString().Trim());
            entidad.Acuerdo3 = Decimal.Parse(registro["dscto3"].ToString().Trim());
            entidad.Acuerdo4 = Decimal.Parse(registro["dscto4"].ToString().Trim());
            return entidad;
        }
    }
}
