using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO
{
    public class Contexto : DTOMaestro
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string StringConexion { get; set; }
    }
}
