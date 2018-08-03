using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class Entrega:DTOMaestro
    {
        [DataMember]
        public int Dias { get; set; }
    }
}
