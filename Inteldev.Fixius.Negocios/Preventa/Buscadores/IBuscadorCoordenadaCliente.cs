using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.Buscadores
{
    interface IBuscadorCoordenadaCliente : IBuscador<CoordenadaCliente>
    {
        List<CoordenadaCliente> ObtenerCoordenadas(int? preventistaId, DateTime dia);
        List<CoordenadaCliente> ObtenerCoordenadas(string codigoPreventista, DateTime dia);
        List<CoordenadaCliente> ObtenerClientesConCoordenadasInvalidas();
        List<CoordenadaCliente> ObtenerCoordenadasClientes(List<string> codigosClientes);
    }
}
