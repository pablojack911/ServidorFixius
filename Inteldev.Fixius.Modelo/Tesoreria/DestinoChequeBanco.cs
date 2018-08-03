using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class DestinoChequeBanco : DestinoChequeTercero
    {
        public Banco Banco { get; set; }
        [ForeignKey("Banco")]
        public int? BancoId { get; set; }
    }
}
