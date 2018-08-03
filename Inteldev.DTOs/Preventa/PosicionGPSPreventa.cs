using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class PosicionGPSPreventa:DTOMaestro
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Preventista Preventista { get; set; }
        [DataMember]
        public int? PreventistaId { get; set; }
        [DataMember]
        public Coordenada Coordenadas { get; set; }
    }
}
