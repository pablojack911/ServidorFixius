using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Precios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorListaDePreciosDeVentaFox : MapeadorFox<ListaDePreciosDeVenta>
    {
        public MapeadorListaDePreciosDeVentaFox(IDao con, string empresa, string entidad)
            : base("listas", "select distinct l.numero,l.titulo from listas as l inner join hablist2 as h on l.numero=h.numero group by l.numero", "numero", con, empresa, entidad)
        {
        }

        protected override ListaDePreciosDeVenta Mapear(ListaDePreciosDeVenta entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["numero"].ToString().Trim();
            entidad.Nombre = registro["titulo"].ToString().Trim();
            return entidad;
        }
        ///nombre tabla : listas distinct && union con avlist
        ///columnas: 
        ///numero == codigo
        ///titulo == nombre
        ///hablist2 en campo numero
    }
}
