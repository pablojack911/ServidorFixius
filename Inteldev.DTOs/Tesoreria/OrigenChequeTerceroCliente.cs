using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class OrigenChequeTerceroCliente : OrigenChequeTercero
    {
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public int? ClienteId { get; set; }
    }
}
