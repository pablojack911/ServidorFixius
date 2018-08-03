using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Datos
{
    public class DaoFoxPruebaMayorista:DaoFox
    {
        public DaoFoxPruebaMayorista()
            : base("Provider=VFPOLEDB.1 ;Data Source=////server//work//AppVfp//mayorista//mayorista_release//datos//truesoft.dbc")
        {

        }
    }
}
