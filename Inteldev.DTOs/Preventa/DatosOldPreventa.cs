using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class DatosOldPreventa : DTOBase
    {
        [DataMember]
        public bool Inactivo { get; set; }
        [DataMember]
        public bool EsSupervisor { get; set; }
    }
}
