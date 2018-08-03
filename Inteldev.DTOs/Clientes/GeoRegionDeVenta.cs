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
    public class GeoRegionDeVenta : Regiones
    {
        //public GeoRegionDeVenta()
        //{
        //    this.GeoRegionDeVentas = new List<GeoRegionDeVenta>();
        //}

        //[DataMember]
        //public List<RegionDeVenta> RegionesDeVenta { get; set; }
        //[DataMember]
        //public string Campodeprueba { get; set; }
    }
}
