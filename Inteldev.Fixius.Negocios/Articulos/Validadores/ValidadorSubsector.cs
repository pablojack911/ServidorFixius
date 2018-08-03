using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Inteldev.Fixius.Negocios.Validadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Validadores
{
    public class ValidadorSubsector : ValidadorGenerico<Subsector>
    {
        public override bool isRepetido(Subsector entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subsector");
            var buscador = (BuscadorSubsector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subsector>), parameter);
            Subsector subsector = null;
            if (entidad.Id == 0)
                subsector = buscador.ObtenerSubsector(entidad.Codigo, entidad.Sector.Id);
            else
                subsector = buscador.ObtenerSubsector(entidad.Codigo,
                                                      entidad.Sector.Codigo,
                                                      entidad.Sector.Area.Codigo);

            if (subsector == null)
                return false;
            else
                return true;
        }
    }
}
