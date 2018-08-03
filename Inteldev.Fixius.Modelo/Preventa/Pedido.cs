using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class Pedido : EntidadMaestro
    {
        public Pedido()
        {
            this.FechaEntrega = DateTime.Now;
            this.FechaFacturacion = DateTime.Now;
            this.FechaPedido = DateTime.Now;
            this.DetallePedido = new List<DetallePedido>();
        }

        public DateTime FechaPedido { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Preventista Preventista { get; set; }
        [ForeignKey("Preventista")]
        public int? PreventistaId { get; set; }
        public Cliente Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }
        public ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
