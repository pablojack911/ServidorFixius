using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class ConceptoDeMovimientoBancario : EntidadMaestro
    {
        public Afecta Afecta { get; set; }
    }

    public enum Afecta : int
    {
        Debe = 0,
        Haber = 1
    }
}
