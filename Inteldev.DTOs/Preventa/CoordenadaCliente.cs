using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class CoordenadaCliente : DTOMaestro
    {
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public string Icono { get; set; }
        [DataMember]
        public double Latitud { get; set; }
        [DataMember]
        public double Longitud { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public int Orden { get; set; }
    }
}
