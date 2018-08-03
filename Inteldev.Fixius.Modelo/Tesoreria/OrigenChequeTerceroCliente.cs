using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class OrigenChequeTerceroCliente : OrigenChequeTercero
    {
        public Cliente Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }
    }
}
