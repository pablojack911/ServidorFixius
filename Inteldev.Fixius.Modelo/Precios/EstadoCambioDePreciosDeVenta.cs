using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Precios
{
    public enum EstadoCambioDePreciosDeVenta:int
    {
        Pendiente=0,
        Confirmado=1,
        Anulado=2
    }
}
