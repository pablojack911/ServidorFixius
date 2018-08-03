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
    public class ValidadorFamilia : ValidadorGenerico<Familia>
    {
        public override bool isRepetido(Familia entidad, string empresa)
        {
            Familia flia = null;

            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "familia");
            var buscador = (BuscadorFamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Familia>), parameter);
            
            if (entidad.Id == 0) //nuevo desde dto
                flia = buscador.ObtenerFamilia(entidad.Codigo, entidad.Subsector.Id);
            else
                flia = buscador.ObtenerFamilia(entidad.Codigo, entidad.Subsector.Codigo, entidad.Subsector.Sector.Codigo, entidad.Subsector.Sector.Area.Codigo);

            if (flia == null)
                return false;
            else
                return true;
        }
    }
}
