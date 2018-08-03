using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class DiasDeSemana
    {
        [DataMember]
        public bool Lunes { get; set; }
        [DataMember]
        public bool Martes { get; set; }
        [DataMember]
        public bool Miercoles { get; set; }
        [DataMember]
        public bool Jueves { get; set; }
        [DataMember]
        public bool Viernes { get; set; }
        [DataMember]
        public bool Sabado { get; set; }
    }
}
