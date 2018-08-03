using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class MovimientoBancario : EntidadMaestro
    {
        public MovimientoBancario()
        {
            this.Fecha = DateTime.Now;
            this.FechaEfectiva = DateTime.Now;
        }
        public DateTime Fecha { get; set; }
        public DateTime FechaEfectiva { get; set; }
        public ConceptoDeMovimientoBancario ConceptoMovimientoBancario { get; set; }
        [ForeignKey("ConceptoMovimientoBancario")]
        public int? ConceptoMovimientoBancarioId { get; set; }
        public string Numero { get; set; }
        public string Detalle { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
    }
}
