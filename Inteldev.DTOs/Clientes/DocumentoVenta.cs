using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class DocumentoVenta : Documento
    {
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public int? ClienteId { get; set; }
    }
}
