using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Precios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class DetallePedido : EntidadMaestro
    {
        public DetallePedido()
        {
            this.Descuentos = new List<Descuento>();
        }
        public Articulo Articulo { get; set; }
        [ForeignKey("Articulo")]
        public int? ArticuloId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Empresa { get; set; }
        public DivisionComercial DivisionComercial { get; set; }
        [ForeignKey("DivisionComercial")]
        public int? DivisionComercialId { get; set; }
        public TipoPedido TipoPedido { get; set; }
        public ICollection<Descuento> Descuentos { get; set; }
        public int Cantidad { get; set; }
        public decimal Final { get; set; }
    }
}
