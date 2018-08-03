using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class MovimientoBancario : DTOMaestro
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaEfectiva { get; set; }
        [DataMember]
        public ConceptoDeMovimientoBancario ConceptoMovimientoBancario { get; set; }
        [DataMember]
        public int? ConceptoMovimientoBancarioId { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Detalle { get; set; }
        [DataMember]
        public decimal Debe { get; set; }
        [DataMember]
        public decimal Haber { get; set; }
    }
}
