using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;

namespace Inteldev.Fixius.Negocios.Articulos.Numeradores
{
    public class NumeradorSubfamilia : Numerador<Subfamilia>
    {
        protected BuscadorSubfamilia buscador;
        public NumeradorSubfamilia(string empresa, string entidad)
            : base(empresa, entidad)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subfamilia");
            this.buscador = (BuscadorSubfamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subfamilia>), parameter);
        }
        public override string UltimoCodigo()
        {

            return this.buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo)
                .Where(p => p.FamiliaId == this.entidad.Familia.Id)
                    .Max(p => p.Codigo);
        }
    }
}
