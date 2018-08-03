using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class ConceptoDeMovimientoBancario : DTOMaestro
    {
        [DataMember]
        public Afecta Afecta { get; set; }
    }

    public enum Afecta : int
    {
        [EnumMember]
        Debe = 0,
        [EnumMember]
        Haber = 1
    }

}
