using Inteldev.Core.Negocios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Clientes.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioPercepcion : IServicioPercepcion
    {

        public decimal ObtenerPorcentajeDePercepcion(string Cuit)
        {
            decimal porcentaje = 0;
            try
            {
                var paramers = new ParameterOverride[2];
                paramers[0] = new ParameterOverride("empresa", "01");
                paramers[1] = new ParameterOverride("entidad", "PadronIIBB");
                var buscador = (IBuscadorPercepcion)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorPercepcion), paramers);
                if (buscador != null)
                    porcentaje = buscador.ObtenerPorcentajeDePercepcion(Cuit);
            }
            catch (Exception ex)
            {

            }
            return porcentaje;
        }
    }
}
