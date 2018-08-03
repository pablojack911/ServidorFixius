using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class DestinoChequeBanco : DestinoChequeTercero
    {
        [DataMember]
        public Banco Banco { get; set; }
        [DataMember]
        public int? BancoId { get; set; }
    }
}
