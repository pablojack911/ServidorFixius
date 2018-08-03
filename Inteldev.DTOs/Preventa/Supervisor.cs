using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    /// <summary>
    /// DTO para Supervisor
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorPreventa))]
    public class Supervisor : Preventa
    {
        [DataMember]
        public List<Preventista> Preventistas { get; set; }
        [DataMember]
        public Jefe Jefe { get; set; }
        [DataMember]
        public int? JefeId { get; set; }
    }
}
