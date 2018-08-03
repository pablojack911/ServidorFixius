using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Datos
{
    public class DaoFoxPrueba:DaoFox
    {
        public DaoFoxPrueba()
            : base("Provider=VFPOLEDB.1 ;Data Source=////server//work//AppVfp//Hergo_release//datos//truesoft.dbc")

        { }
    }
}
