using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class Empaque:EntidadMaestro
    {
        public decimal Contenido { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; }    
    }
}
