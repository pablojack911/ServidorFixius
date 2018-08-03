using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Stock
{
    public class ConceptoDeMovimientoDeStock : EntidadMaestro
    {
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
