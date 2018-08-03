using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class MovimientoChequeTercero : EntidadBase
    {
        public MovimientoChequeTercero()
        {
            this.Fecha = DateTime.Now;
        }
        public DateTime Fecha { get; set; }
    }
}
