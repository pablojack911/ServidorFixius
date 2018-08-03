using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class CodigoEan : DTOBase
    {
        [DataMember]
        public string CodigoDeBarra { get; set; }
        [DataMember]
        public int UnidadesPorBulto { get; set; }
        [DataMember]
        public int UnidadesPorPack { get; set; }

        //[DataMember]
        //public int UnidadesPorPallet { get; set; }
        //[DataMember]
        //public int UnidadesPorBase { get; set; }
        //[DataMember]
        //public int UnidadesPorAltura { get; set; }

        [DataMember]
        public bool Activo { get; set; }
    }
}
