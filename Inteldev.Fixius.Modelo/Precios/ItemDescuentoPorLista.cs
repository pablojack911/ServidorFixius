using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Precios
{
    public class ItemDescuentoPorLista:EntidadBase
    {
        public ItemDescuentoPorLista()
        {
            this.Descuentos = new List<Descuento>();
        }
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public int? AreaId { get; set; }

        public Sector Sector { get; set; }
        [ForeignKey("Sector")]
        public int? SectorId { get; set; }

        public Subsector Subsector { get; set; }
        [ForeignKey("Subsector")]
        public int? SubsectorId { get; set; }

        public Familia Familia { get; set; }
        [ForeignKey("Familia")]
        public int? FamiliaId { get; set; }

        public Subfamilia Subfamilia { get; set; }
        [ForeignKey("Subfamilia")]
        public int? SubfamiliaId { get; set; }

        public Marca Marca { get; set; }
        [ForeignKey("Marca")]
        public int? MarcaId { get; set; }

        public Articulo Articulo { get; set; }
        [ForeignKey("Articulo")]
        public int? ArticuloId { get; set; }

        public ICollection<Descuento> Descuentos { get; set; } 
    }
}
