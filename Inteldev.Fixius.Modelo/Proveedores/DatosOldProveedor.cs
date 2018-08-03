using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class DatosOldProveedor : EntidadBase
    {
        public bool EsSubempresa { get; set; }
        public bool EmiteComprobantes { get; set; }
        public bool CargaPedidos { get; set; }
        public bool ComisionLogistica { get; set; }
        public bool CalculoBodegas { get; set; }
        public string PuntoDeVenta { get; set; }
        public int PlazoEntregaDias { get; set; } //nuevo 31/10/14
        public Deposito Deposito { get; set; }
        [ForeignKey("Deposito")]
        public int? DepositoId { get; set; }
        public Transportista Fletero { get; set; }
        [ForeignKey("Fletero")]
        public int? FleteroId { get; set; }
    }
}
