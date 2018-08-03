using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.BuscadoresDTO
{
    public interface IBuscadorCoordenadaClienteDTO : IBuscadorDTO<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>
    {
        List<Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasDeClientes(int? preventistaId, DateTime dia);
        List<Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasDeClientes(string codigoPreventista, DateTime dia);
        List<Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente> BuscarClientesConCoordenadasInvalidas();
        List<Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente> BuscarCoordenadasClientes(List<string> codigosClientes);

    }
}
