using Inteldev.Core.Datos;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System.Collections.Generic;

namespace Inteldev.Fixius.Negocios.Preventa.Buscadores
{
    public interface IBuscadorFoxConfigZona
    {
        IDao conexion { get; set; }
        List<CoordenadaCliente> BuscarClientes();
        List<CoordenadaCliente> BuscarClientes(List<string> codigosClientes);

    }
}
