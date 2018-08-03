using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class DatosOldProveedor : DTOBase
    {
        [DataMember]
        public bool EsSubempresa { get; set; }
        [DataMember]
        public bool EmiteComprobantes { get; set; }
        [DataMember]
        public bool CargaPedidos { get; set; }
        [DataMember]
        public bool ComisionLogistica { get; set; }
        [DataMember]
        public bool CalculoBodegas { get; set; }
        [DataMember]
        public Deposito Deposito { get; set; }
        [DataMember]
        public int? DepositoId { get; set; }
        [DataMember]
        public string PuntoDeVenta { get; set; }
        [DataMember]
        public Transportista Fletero { get; set; }
        [DataMember]
        public int? FleteroId { get; set; }
        [DataMember]
        public int PlazoEntregaDias { get; set; }
    }
}
