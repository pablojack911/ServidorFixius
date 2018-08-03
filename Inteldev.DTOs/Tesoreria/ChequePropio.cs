using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class ChequePropio : DTOBase
    {
        [DataMember]
        public Banco Banco { get; set; }
        [DataMember]
        public int? BancoId { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaDeEfectivizacion { get; set; }
        [DataMember]
        public decimal Importe { get; set; }
        [DataMember]
        public string PagueseA { get; set; }
    }
}
