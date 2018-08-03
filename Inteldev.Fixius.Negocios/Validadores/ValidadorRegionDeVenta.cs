using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Validadores
{
    /// <summary>
    /// Validador para RegionDeVenta, que en Fox viene de la tabla "regiones" junto con GeoRegionDeVenta.
    /// </summary>
    public class ValidadorRegionDeVenta : ValidadorGenerico<RegionDeVenta>
    {
        public override bool isRepetido(RegionDeVenta entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "regiones");
            
            var buscadorRegionDeVenta = (IBuscador<RegionDeVenta>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<RegionDeVenta>), parameter);
            var regionesAny = buscadorRegionDeVenta.ConsultaSimple(Core.CargarRelaciones.NoCargarNada).Any(p => p.Codigo == entidad.Codigo);
            
            var buscadorGeoRegionDeVenta = (IBuscador<GeoRegionDeVenta>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<GeoRegionDeVenta>), parameter);
            var geoRegionesAny = buscadorGeoRegionDeVenta.ConsultaSimple(Core.CargarRelaciones.NoCargarNada).Any(p => p.Codigo == entidad.Codigo);
            
            return regionesAny || geoRegionesAny;
            //if (regiones == null || regiones.Count == 0)
            //    return true;
            //return false;
        }

    }
}
