using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class ConfiguraCredito : DTOBase
    {
        [DataMember]
        public decimal Limite { get; set; }
        [DataMember]
        public Vendedor Vendedor { get; set; }
        [DataMember]
        public int? VendedorId { get; set; }
        [DataMember]
        public Vendedor VendedorEspecial { get; set; }
        [DataMember]
        public Cobrador Cobrador { get; set; }
        [DataMember]
        public int? CobradorId { get; set; }
        [DataMember]
        public int? VendedorEspecialId { get; set; }
        [DataMember]
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [DataMember]
        public int? CondicionDePagoId { get; set; }
        [DataMember]
        public CondicionDePagoCliente CondicionDePago2 { get; set; }
        [DataMember]
        public int? CondicionDePago2Id { get; set; }
        [DataMember]
        public bool RespetarCondicionDePago2 { get; set; }
        [DataMember]
        public UnidadeDeNegocio UnidadDeNegocio { get; set; }
    }

    

}
