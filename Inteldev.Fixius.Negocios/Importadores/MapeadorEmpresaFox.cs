using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorEmpresaFox:MapeadorFox<Empresa>
    {
        public MapeadorEmpresaFox(IDao dao, string empresa, string entidad)
            : base("param", "codigo", dao, empresa, entidad)
        { }

        protected override Empresa Mapear(Empresa entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["empresa"].ToString().Trim();
            entidad.RazonSocial = registro["empresa"].ToString().Trim();
            entidad.CUIT = registro["cuit"].ToString();
            entidad.CondicionAnteIVA = Core.Modelo.Fiscal.CondicionAnteIva.ResponsableInscripto;
            return entidad;
        }
    }
}
