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
    public class NumeradorSubsector : Numerador<Subsector>
    {
        protected BuscadorSubsector buscador;
        public NumeradorSubsector(string empresa, string entidad)
            : base(empresa, entidad)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subsector");
            this.buscador = (BuscadorSubsector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subsector>), parameter);
        }

        public override string UltimoCodigo()
        {
            return this.buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo)
                .Where(p => p.SectorId == this.entidad.Sector.Id)
                    .Max(p => p.Codigo);
        }
    }
}
