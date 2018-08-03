using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface

        IServicioRutaDeVenta : IServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>
    {
        [OperationContract]
        List<Cliente> ObtenerListaClientes(Preventista preventista, DateTime dia);
        [OperationContract]
        void GrabarVertices(string codigoRuta, ICollection<Coordenada> coordenadasVertices);
        [OperationContract]
        List<Coordenada> ObtenerVertices(string codigo, string empresa, string division);
        [OperationContract(Name = "ObtenerRutasDelDiaPorPreventista")]
        List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime dia);
        [OperationContract(Name = "ObtenerRutasDelDiaPorCodigoPreventista")]
        List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime dia);
        [OperationContract]
        List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division);
    }
}
