using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class DatosOldArticulo : DTOBase
    {
        [DataMember]
        public Linea Linea { get; set; }
        [DataMember]
        public int? LineaId { get; set; }
        [DataMember]
        public Rubro Rubro { get; set; }
        [DataMember]
        public int? RubroId { get; set; }
        [DataMember]
        public Clase Clase { get; set; }
        [DataMember]
        public int? ClaseId { get; set; }
        [DataMember]
        public Division Division { get; set; }
        [DataMember]
        public int? DivisionId { get; set; }
        [DataMember]
        public int? SKUId { get; set; }
        [DataMember]
        public SKU SKU { get; set; }
        [DataMember]
        public Articulo ArticuloEnvase { get; set; }
        [DataMember]
        public int? ArticuloEnvaseId { get; set; }
        [DataMember]
        public bool ControlStock { get; set; }
        [DataMember]
        public bool NoVenderPorPreventa { get; set; }
        [DataMember]
        public bool ExclusivoMayorista { get; set; }
        [DataMember]
        public bool NoIncluirEnPreventa { get; set; }
        [DataMember]
        public bool NoRecibirPedidos { get; set; }
        [DataMember]
        public bool NoRecibirPedidosCadenas { get; set; }
        [DataMember]
        public bool NoRecibirPedidosInterior { get; set; }
        [DataMember]
        public bool BultosMasterEnBorrador { get; set; }
        [DataMember]
        public bool PuedeComprar { get; set; }
        [DataMember]
        public bool PuedeVenderEnCadenas { get; set; }
        [DataMember]
        public bool PedirREBA { get; set; }
        [DataMember]
        public bool MostrarEnListadoDeCriticos { get; set; }

        [DataMember]
        public decimal MargenPreventa { get; set; }
        [DataMember]
        public decimal MargenMayorista { get; set; }
        [DataMember]
        public int MinimoDeVenta { get; set; }
        [DataMember]
        public string ContenidoPorUnidad { get; set; }
        [DataMember]
        public bool ExcluirConvenioClienteZ { get; set; }
        [DataMember]
        public bool NoValorizar { get; set; }
    }
}
