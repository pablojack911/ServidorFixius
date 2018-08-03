using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes
{
    public interface IBuscadorRutaDeVenta : IBuscador<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta>
    {
        List<Cliente> ObtenerClientes(Preventista preventista, DateTime fecha);
        List<Cliente> ObtenerClientes(int? preventistaId, DateTime fecha);
        IQueryable<RutaDeVenta> CrearConsulta(int? preventistaId, DateTime fecha);
        ICollection<Coordenada> ObtenerCoordenadas(string codigo, string empresa, string division);
        List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime fecha);
        List<RutaDeVenta> ObtenerRutasDelDia(int? preventistaId, DateTime fecha);
        List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime fecha);
        List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division);
    }
}
