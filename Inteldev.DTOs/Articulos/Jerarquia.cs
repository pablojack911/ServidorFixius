using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class Jerarquia:DTOMaestro
    {
        [DataMember]
        public List<Jerarquia> Nodos { get; set; }
        [DataMember]
        public Jerarquia Padre { get; set; }
        [DataMember]
        public int Nivel { get; set; }
    }
}
