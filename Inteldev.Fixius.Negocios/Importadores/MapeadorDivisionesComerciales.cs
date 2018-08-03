using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorDivisionesComerciales:MapeadorFox<DivisionComercial>
    {

        public MapeadorDivisionesComerciales(IDao con, String empresa, string entidad)
                    :base ("zonas","select codigo,nombre from proveedo where preventa=1 order by codigo group by codigo","codigo",con,empresa,entidad)
        {
        }


        protected override DivisionComercial Mapear(DivisionComercial entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            
            return entidad;
        }
    }
}
