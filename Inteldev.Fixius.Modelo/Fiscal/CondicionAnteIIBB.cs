using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Fiscal
{
    public enum CondicionAnteIIBB : int
    {
        NoAsignado = 0,
        NoCorrespondeExento = 1,
        DMOnceVeitiseis = 2,
        DNBOcho = 3,
        DNBTreintaYOcho = 4
    }
}
