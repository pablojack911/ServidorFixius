using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes
{
    public interface IBuscadorRutaDeVentaDTO : IBuscadorDTO<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>
    {
        List<Cliente> ObtenerClientes(Preventista preventista, DateTime fecha);
        List<Coordenada> ObtenerCoordenadas(string codigo, string empresa, string division);
        List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime fecha);
        List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime fecha);
        List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division);
    }
}
