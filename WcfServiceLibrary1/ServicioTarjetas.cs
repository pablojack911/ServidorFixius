using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Fixius.Contratos;
using Microsoft.Practices.Unity;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Negocios.Clientes.Buscadores;
using System.ServiceModel;


namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioTarjetas : IServicioTarjetas
    {
        public string EsDuplicada(string codigoTarjeta)
        {
            string codigoCliente = null;
            try
            {
                var paramers = new ParameterOverride[2];
                paramers[0] = new ParameterOverride("empresa", "01");
                paramers[1] = new ParameterOverride("entidad", "TarjetaMayoristaItem");
                var buscador = (IBuscador<TarjetaMayoristaItem>)FabricaNegocios.Instancia.Resolver(typeof(BuscadorGenerico<TarjetaMayoristaItem>), paramers);
                TarjetaMayoristaItem tar = null;
                if (buscador != null)
                    tar = buscador.BuscarPorCodigo<TarjetaMayoristaItem>(codigoTarjeta);
                if (tar != null)
                {
                    paramers[1] = new ParameterOverride("entidad", "Cliente");
                    var buscadorCliente = (BuscadorCliente)FabricaNegocios.Instancia.Resolver(typeof(BuscadorCliente), paramers);

                    var q = buscadorCliente.ConsultaSimple(Core.CargarRelaciones.CargarTodo);

                    var cli = from cliente in q where cliente.TarjetasCliente.Any(t => t.Id == tar.Id) select cliente.Codigo;

                    codigoCliente = cli.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return codigoCliente;
        }

        public bool CantidadHabilitada(List<DTO.Clientes.TarjetaMayoristaItem> listaTarjetas)
        {
            var masDeUnaHabilitada = false;
            if (listaTarjetas.Count > 0)
            {
                masDeUnaHabilitada = listaTarjetas.Count(x => x.Habilitada == true) > 1;
            }
            return masDeUnaHabilitada;
        }
    }
}
