using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class DestinoProveedor : DestinoChequeTercero
    {
        [DataMember]
        public Proveedor Proveedor { get; set; }
        [DataMember]
        public int? ProveedorId { get; set; }
    }
}
