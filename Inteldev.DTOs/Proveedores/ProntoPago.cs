using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class ProntoPago : DTOBase
    {
        [DataMember]
        public int ProntoPagoDias { get; set; }
        [DataMember]
        public decimal ProntoPagoDesc { get; set; }
    }
}
