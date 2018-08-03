using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    [ValidadorAtributo(typeof(ValidadorRegiones))]
    public class RegionDeVenta : Regiones
    {
        //public RegionDeVenta()
        //{
        //    this.RutasDeVenta = new List<RutaDeVenta>();
        //}

        //[DataMember]
        //public List<RutaDeVenta> RutasDeVenta { get; set; }
        [DataMember]
        public GeoRegionDeVenta GeoRegionDeVenta { get; set; }
        [DataMember]
        public int? GeoRegionDeVentaId { get; set; }
    }
}
