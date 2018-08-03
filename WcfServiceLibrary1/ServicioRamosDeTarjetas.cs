using Inteldev.Core.Negocios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Servicios.DTO.Clientes;
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
    public class ServicioRamosDeTarjetas : IServicioRamosDeTarjetas
    {
        public bool EncontroRamoEnTarjetas(Ramo ramo, List<DTO.Clientes.TarjetaMayoristaItem> listaTarjetas)
        {
            bool encontro = false;
            if (ramo != null)
                if (listaTarjetas.Count > 0)
                {
                    var ramocodigo = ramo.Codigo;

                    var tarjetaHabilitada = listaTarjetas.FirstOrDefault(t => t.Habilitada == true);
                    if (tarjetaHabilitada != null)
                    {
                        var tipoTarjetaHabilitada = tarjetaHabilitada.TipoTarjeta;
                        var paramers = new ParameterOverride[2];
                        paramers[0] = new ParameterOverride("empresa", "01");
                        paramers[1] = new ParameterOverride("entidad", "Ramo");
                        var buscadorRamos = (IBuscador<Fixius.Modelo.Clientes.Ramo>)FabricaNegocios.Instancia.Resolver(typeof(BuscadorGenerico<Fixius.Modelo.Clientes.Ramo>), paramers);
                        if (buscadorRamos != null)
                        {
                            var ramosDeTarjeta = buscadorRamos.ConsultaSimple(Core.CargarRelaciones.CargarTodo).Where(r => r.Tarjeta.Codigo.Equals(tipoTarjetaHabilitada.Codigo)).ToList();
                            encontro = ramosDeTarjeta.Any(p => p.Codigo.Equals(ramocodigo));
                        }
                    }
                    else
                        encontro = true;
                }
                else
                    encontro = true;
            return encontro;
        }
    }
}
