using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Contabilidad;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Contabilidad
{
    public class ReferenciaContable:EntidadMaestro
    {
        public string Empresa { get; set; }
        public Imputaciones Imputacion { get; set; }
        public ConceptoDeMovimiento Concepto { get; set; }
        [ForeignKey("Concepto")]
        public int? ConceptoDeMovimientoId { get; set; }
    }
}
