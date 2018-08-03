using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class TarjetaClienteMayorista : EntidadMaestro
    {
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public TarjetaClienteMayorista Hereda { get; set; }
        [ForeignKey("Hereda")]
        public int? HeredaId { get; set; }
        public virtual ICollection<Ramo> Ramos { get; set; }
        public TipoDeTarjetaMayorista Uso { get; set; }
        public TarjetaClienteMayorista()
        {
            this.Ramos = new List<Ramo>();
        }
    }

    public enum TipoDeTarjetaMayorista : int
    {
        Clientes = 0,
        UsoInterno = 1
    }
}
