using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
    public class ConceptoDeMovimientoDeStock : DTOMaestro
    {
        [DataMember]
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
