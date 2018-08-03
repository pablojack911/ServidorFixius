using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Contabilidad;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Contabilidad
{
    public class ReferenciaContable : DTOMaestro
    {
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public Imputaciones Imputacion { get; set; }
        [DataMember]
        public ConceptoDeMovimiento Concepto { get; set; }
        [DataMember]
        public int? ConceptoDeMovimientoId { get; set; }
    }
}
