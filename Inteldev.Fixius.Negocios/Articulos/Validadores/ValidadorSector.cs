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
    public class ValidadorSector : ValidadorGenerico<Sector>
    {
        public override bool isRepetido(Sector entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "sector");
            var buscador = (BuscadorSector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Sector>), parameter);

            //Type tipoBuscador = buscador.GetType();
            //object[] codigos = new object[] 
            //{ 
            //    entidad.Codigo, 
            //    entidad.Area.Codigo
            //};
            var sector = buscador.ObtenerSector(entidad.Codigo, entidad.Area.Codigo);

            if (sector == null)
                return false;
            else
                return true;
        }
    }
}
