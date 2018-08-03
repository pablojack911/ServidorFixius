using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Numeradores
{
    public class NumeradorSector : Numerador<Sector>
    {
        protected BuscadorSector buscador;
        public NumeradorSector(string empresa, string entidad)
            : base(empresa, entidad)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "sector");
            this.buscador = (BuscadorSector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Sector>), parameter);
        }

        public override string UltimoCodigo()
        {
            return this.buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo)
                .Where(p => p.AreaId == this.entidad.Area.Id)
                    .Max(p => p.Codigo);
        }
    }
}
