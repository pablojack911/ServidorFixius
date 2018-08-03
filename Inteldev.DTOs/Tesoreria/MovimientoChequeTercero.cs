using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class MovimientoChequeTercero : DTOBase
    {
        [DataMember]
        public DateTime Fecha { get; set; }
    }
}
