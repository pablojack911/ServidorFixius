using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Precios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class DetallePedido : DTOMaestro
    {
        [DataMember]
        public Articulo Articulo { get; set; }
        [DataMember]
        public int? ArticuloId { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public DivisionComercial DivisionComercial { get; set; }
        [DataMember]
        public int? DivisionComercialId { get; set; }
        [DataMember]
        public TipoPedido TipoPedido { get; set; }
        [DataMember]
        public decimal PrecioUnitario { get; set; }
        [DataMember]
        public List<Descuento> Descuentos { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public decimal Final { get; set; }
    }
}
