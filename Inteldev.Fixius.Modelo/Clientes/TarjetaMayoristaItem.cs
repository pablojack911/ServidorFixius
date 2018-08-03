using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class TarjetaMayoristaItem : EntidadMaestro
    {
        public TarjetaClienteMayorista TipoTarjeta { get; set; }
        [ForeignKey("TipoTarjeta")]
        public int? TipoTarjetaId { get; set; }
        public bool Habilitada { get; set; }
        public DateTime Fecha { get; set; }

        public TarjetaMayoristaItem()
        {
            Fecha = DateTime.Today;
        }
    }
}
