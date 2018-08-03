using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Preventa;
using Inteldev.Fixius.Negocios.Preventa.Buscadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.BuscadoresDTO
{
    public class BuscadorCoordenadaClienteDTO : BuscadorDTO<Fixius.Modelo.Preventa.CoordenadaCliente, Servicios.DTO.Preventa.CoordenadaCliente>, IBuscadorCoordenadaClienteDTO
    {
        public BuscadorCoordenadaClienteDTO(IBuscador<CoordenadaCliente> buscador, IMapeadorGenerico<CoordenadaCliente, Servicios.DTO.Preventa.CoordenadaCliente> mapeador)
            : base(buscador, mapeador)
        {

        }
        public List<Servicios.DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasDeClientes(int? preventistaId, DateTime dia)
        {
            var mapeadorCoordenadas = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>>();
            var buscadorCoordenadas = (IBuscadorCoordenadaCliente)this.BuscadorEntidad;
            var result = buscadorCoordenadas.ObtenerCoordenadas(preventistaId, dia);
            return mapeadorCoordenadas.ToListDto(result);
        }

        public List<Servicios.DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasDeClientes(string codigoPreventista, DateTime dia)
        {
            var mapeadorCoordenadas = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>>();
            var buscadorCoordenadas = (IBuscadorCoordenadaCliente)this.BuscadorEntidad;
            var result = buscadorCoordenadas.ObtenerCoordenadas(codigoPreventista, dia);
            return mapeadorCoordenadas.ToListDto(result);
        }

        public new List<Servicios.DTO.Clientes.RutaDeVenta> BuscarLista(object param, Core.CargarRelaciones cargarEntidades)
        {
            throw new NotImplementedException();
        }

        public new Servicios.DTO.Clientes.RutaDeVenta BuscarPorCodigo<TMaestro>(object busqueda, Core.CargarRelaciones cargarEntidades, List<Core.DTO.ParametrosMiniBusca> parametros) where TMaestro : Core.Modelo.EntidadMaestro
        {
            throw new NotImplementedException();
        }

        public new Servicios.DTO.Clientes.RutaDeVenta BuscarSimple(object busqueda, Core.CargarRelaciones cargarEntidades)
        {
            throw new NotImplementedException();
        }

        public List<Servicios.DTO.Preventa.CoordenadaCliente> BuscarClientesConCoordenadasInvalidas()
        {
            var mapeadorCoordenadas = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>>();
            var buscadorCoordenadas = (IBuscadorCoordenadaCliente)this.BuscadorEntidad;
            var result = buscadorCoordenadas.ObtenerClientesConCoordenadasInvalidas();
            return mapeadorCoordenadas.ToListDto(result);
        }


        public List<Servicios.DTO.Preventa.CoordenadaCliente> BuscarCoordenadasClientes(List<string> codigosClientes)
        {
            var mapeadorCoordenadas = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>>();
            var buscadorCoordenadas = (IBuscadorCoordenadaCliente)this.BuscadorEntidad;
            var result = buscadorCoordenadas.ObtenerCoordenadasClientes(codigosClientes);
            return mapeadorCoordenadas.ToListDto(result);
        }
    }
}
