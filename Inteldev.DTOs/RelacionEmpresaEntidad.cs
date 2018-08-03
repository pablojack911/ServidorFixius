using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO
{
    public class RelacionEmpresaEntidad : DTOMaestro
    {
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public int? EmpresaId { get; set; }
        [DataMember]
        public string Entidad { get; set; }
        [DataMember]
        public int Grupo { get; set; }
    }
}
