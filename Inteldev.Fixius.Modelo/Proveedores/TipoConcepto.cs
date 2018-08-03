using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public enum TipoConcepto : int
    {
        Neto1,
        Neto2,
        Neto3,
        Exento,
        IvaTasaGeneral,
        IvaTasaReducida,
        IvaTasaDiferencial,
        PercepcionIva,
        PercepcionIIBB,
        ImpuestoInterno,
        Final
    }
}
