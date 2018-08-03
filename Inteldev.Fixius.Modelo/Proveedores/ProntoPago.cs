using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class ProntoPago : EntidadBase
    {
        public int ProntoPagoDias { get; set; }
        public decimal ProntoPagoDesc { get; set; }
    }
}
