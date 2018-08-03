using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class ChequePropio : EntidadBase
    {
        public ChequePropio()
        {
            this.Fecha = DateTime.Now;
            this.FechaDeEfectivizacion = DateTime.Now;
        }
        public Banco Banco { get; set; }
        [ForeignKey("Banco")]
        public int? BancoId { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDeEfectivizacion { get; set; }
        public decimal Importe { get; set; }
        public string PagueseA { get; set; }
    }
}
