using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class Columna:EntidadBase
    {
        public int Orden { get; set; }        
        public string Color { get; set; }        
        public string TipoColumna { get; set; }
    }
}
