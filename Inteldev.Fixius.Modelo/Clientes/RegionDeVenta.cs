using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class RegionDeVenta : Regiones
    {
        public RegionDeVenta()
        {
            //RutasDeVenta = new List<RutaDeVenta>();
        }

        //[MuchosAMuchos]
        //public virtual ICollection<RutaDeVenta> RutasDeVenta { get; set; }


        public virtual GeoRegionDeVenta GeoRegionDeVenta { get; set; }

        [ForeignKey("GeoRegionDeVenta")]
        public int? GeoRegionDeVentaId { get; set; } 
    }
}
