using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorCondicionesDePagoClienteFox : MapeadorFox<CondicionDePagoCliente>
    {
        public MapeadorCondicionesDePagoClienteFox(IDao con, string empresa, string entidad)
            : base("condicio", "select codigo,nombre,modofac,dias from condicio", "codigo", con, empresa, entidad)
        {
        }

        protected override CondicionDePagoCliente Mapear(CondicionDePagoCliente entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.CantidadDeDias = Convert.ToInt16(registro["dias"].ToString().Trim());
            var modopago = int.Parse(registro["modofac"].ToString());

            if (modopago == 1)
            {
                entidad.ModoDePago = (ModoDePago)0;
            }
            else
            {
                entidad.ModoDePago = (ModoDePago)1;
            }
                
            return entidad;
        }

    }
}
