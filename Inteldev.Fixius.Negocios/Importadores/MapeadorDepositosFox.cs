using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorDepositosFox : MapeadorFox<Deposito>
    {
        public MapeadorDepositosFox(IDao con, string empresa, string entidad)
            : base("deposito", "codigo", con, empresa, entidad)
        {
        }

        protected override Deposito Mapear(Deposito entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            return entidad;
        }

    }
}
