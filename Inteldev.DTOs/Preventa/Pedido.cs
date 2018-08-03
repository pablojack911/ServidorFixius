using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class Pedido : DTOMaestro
    {
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public DateTime FechaFacturacion { get; set; }
        [DataMember]
        public DateTime FechaEntrega { get; set; }
        [DataMember]
        public Preventista Preventista { get; set; }
        [DataMember]
        public int? PreventistaId { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public int? ClienteId { get; set; }
        [DataMember]
        public List<DetallePedido> DetallePedido { get; set; }
    }
}
