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
    public class ValidadorSubfamilia : ValidadorGenerico<Subfamilia>
    {
        public override bool isRepetido(Inteldev.Fixius.Modelo.Articulos.Subfamilia entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subfamilia");
            var buscador = (BuscadorSubfamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subfamilia>), parameter);

            Subfamilia subflia = null;
            
            if (entidad.Id == 0)
                subflia = buscador.ObtenerSubfamilia(entidad.Codigo, entidad.Familia.Id);
            else
                subflia = buscador.ObtenerSubfamilia(entidad.Codigo,
                                                     entidad.Familia.Codigo,
                                                     entidad.Familia.Subsector.Codigo,
                                                     entidad.Familia.Subsector.Sector.Codigo,
                                                     entidad.Familia.Subsector.Sector.Area.Codigo);

            if (subflia == null)
                return false;
            else
                return true;

        }
    }
}
