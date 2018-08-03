using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public class ItemListaDePreciosDeVenta:DTOBase    
    {
        
        [DataMember]
        public Area Area { get; set; }
        [DataMember]
        public int? AreaId { get; set; }
        [DataMember]
        public Sector Sector { get; set; }
        [DataMember]
        public int? SectorId { get; set; }
        [DataMember]
        public Subsector Subsector { get; set; }
        [DataMember]
        public int? SubsectorId { get; set; }
        [DataMember]
        public Familia Familia { get; set; }
        [DataMember]
        public int? FamiliaId { get; set; }
        [DataMember]
        public Subfamilia Subfamilia { get; set; }
        [DataMember]
        public int? SubfamiliaId { get; set; }
        [DataMember]
        public Marca Marca { get; set; }
        [DataMember]
        public int? MarcaId { get; set; }
        [DataMember]
        public Articulo Articulo { get; set; }
        [DataMember]
        public int? ArticuloId { get; set; } 

    }
}
