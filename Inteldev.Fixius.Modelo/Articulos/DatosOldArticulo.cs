using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class DatosOldArticulo : EntidadBase
    {
        public Linea Linea { get; set; }
        [ForeignKey("Linea")]
        public int? LineaId { get; set; }
        public Rubro Rubro { get; set; }
        [ForeignKey("Rubro")]
        public int? RubroId { get; set; }
        public Clase Clase { get; set; }
        [ForeignKey("Clase")]
        public int? ClaseId { get; set; }
        public Division Division { get; set; }
        [ForeignKey("Division")]
        public int? DivisionId { get; set; }
        public Articulo ArticuloEnvase { get; set; }
        [ForeignKey("ArticuloEnvase")]
        public int? ArticuloEnvaseId { get; set; }
        public SKU SKU { get; set; }
        [ForeignKey("SKU")]
        public int? SKUId { get; set; }
        public string ContenidoPorUnidad { get; set; }
        public bool ControlStock { get; set; }
        public bool NoVenderPorPreventa { get; set; }
        public bool ExclusivoMayorista { get; set; }
        public bool NoIncluirEnPreventa { get; set; }
        public bool NoRecibirPedidos { get; set; }
        public bool NoRecibirPedidosCadenas { get; set; }
        public bool NoRecibirPedidosInterior { get; set; }
        public bool BultosMasterEnBorrador { get; set; }
        public bool PuedeComprar { get; set; }
        public bool PuedeVenderEnCadenas { get; set; }
        public bool PedirREBA { get; set; }
        public bool MostrarEnListadoDeCriticos { get; set; }
        public bool ExcluirConvenioClienteZ { get; set; }
        public bool NoValorizar { get; set; }
        public decimal MargenPreventa { get; set; }
        public decimal MargenMayorista { get; set; }
        public int MinimoDeVenta { get; set; }
    }
}
