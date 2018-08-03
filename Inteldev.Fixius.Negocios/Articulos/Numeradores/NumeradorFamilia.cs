using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Microsoft.Practices.Unity;
using System.Linq;

namespace Inteldev.Fixius.Negocios.Articulos.Numeradores
{
    public class NumeradorFamilia : Numerador<Familia>
    {
        protected BuscadorFamilia buscador;
        public NumeradorFamilia(string empresa, string entidad)
            : base(empresa, entidad)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "familia");
            this.buscador = (BuscadorFamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Familia>), parameter);
        }

        public override string UltimoCodigo()
        {
            return this.buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo)
               .Where(p => p.SubsectorId == this.entidad.Subsector.Id)
                   .Max(p => p.Codigo);
        }
    }
}
