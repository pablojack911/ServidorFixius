using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Creadores
{
    public class CreadorCliente : CreadorDTO<Modelo.Clientes.Cliente, Servicios.DTO.Clientes.Cliente>
    {
        public CreadorCliente(ICreador<Modelo.Clientes.Cliente> creadorEntidad,
            IMapeadorGenerico<Modelo.Clientes.Cliente, Servicios.DTO.Clientes.Cliente> mapeador,
            string empresa,
            string entidad)
            : base(creadorEntidad, mapeador, empresa, entidad)
        {
        }

        public override Core.DTO.Carriers.CreadorCarrier<Servicios.DTO.Clientes.Cliente> Crear()
        {
            var clienteCarrier = base.Crear();
            var cliente = clienteCarrier.GetEntidad();
            cliente.DatosOld = new DatosOldCliente();
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", this.empresa);
            parameters[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRutaDeVenta = (IBuscadorDTO<Fixius.Modelo.Clientes.RutaDeVenta, Fixius.Servicios.DTO.Clientes.RutaDeVenta>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Fixius.Modelo.Clientes.RutaDeVenta, Fixius.Servicios.DTO.Clientes.RutaDeVenta>), parameters);
            if (buscadorRutaDeVenta != null)
            {
                var parametrosMiniBusca = new List<ParametrosMiniBusca>();
                parametrosMiniBusca.Add(new ParametrosMiniBusca() { Nombre = "empresa", Valor = "01" });
                parametrosMiniBusca.Add(new ParametrosMiniBusca() { Nombre = "divisionId", Valor = 2 }); //por defecto en fox... para obtener la ruta 0744
                var zonaGeo = buscadorRutaDeVenta.BuscarPorCodigo<Fixius.Modelo.Clientes.RutaDeVenta>("0744", Core.CargarRelaciones.CargarEntidades, parametrosMiniBusca);
                if (zonaGeo != null)
                    cliente.ZonaGeografica = zonaGeo;
            }
            foreach (var unidadDeNegocio in Enum.GetNames(typeof(UnidadeDeNegocio)))
            {
                if (unidadDeNegocio != "Gestion" && unidadDeNegocio != "Logistica")
                {
                    var configuraCredito = new ConfiguraCredito();
                    configuraCredito.UnidadDeNegocio = (UnidadeDeNegocio)Enum.Parse(typeof(UnidadeDeNegocio), unidadDeNegocio);
                    if (unidadDeNegocio == "Preventa")
                    {
                        parameters[1] = new ParameterOverride("entidad", "CondicionDePagoCliente");
                        var buscadorCondiciones = (IBuscadorDTO<Fixius.Modelo.Clientes.CondicionDePagoCliente, Fixius.Servicios.DTO.Clientes.CondicionDePagoCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Fixius.Modelo.Clientes.CondicionDePagoCliente, Fixius.Servicios.DTO.Clientes.CondicionDePagoCliente>), parameters);
                        if (buscadorCondiciones != null)
                        {
                            var cond = buscadorCondiciones.BuscarPorCodigo<Fixius.Modelo.Clientes.CondicionDePagoCliente>("01", Core.CargarRelaciones.CargarEntidades, null);
                            if (cond != null)
                                configuraCredito.CondicionDePago = cond;
                        }
                    }
                    cliente.ConfiguraCreditos.Add(configuraCredito);
                }
            }
            return clienteCarrier;
        }
    }
}
