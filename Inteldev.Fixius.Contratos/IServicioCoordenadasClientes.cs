using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioCoordenadasClientes : IServicioABM<CoordenadaCliente>
    {
        //[OperationContract]
        //CoordenadaCliente ObtenerPorCliente(string codigo);
        [OperationContract(Name = "ObtenerRutasDelDiaPorPreventista")]
        ICollection<CoordenadaCliente> ObtenerCoordenadasPorPreventista(Preventista preventista, DateTime dia, string empresa);
        [OperationContract(Name = "ObtenerRutasDelDiaPorCodigoPreventista")]
        ICollection<CoordenadaCliente> ObtenerCoordenadasPorPreventista(string codigoPreventista, DateTime dia, string empresa);
        [OperationContract]
        GrabadorCarrier GrabarLista(List<CoordenadaCliente> coordenadasClientes, Usuario usuario, string empresa);
        [OperationContract]
        ICollection<CoordenadaCliente> ActualizarCoordenadasClientes();
        [OperationContract]
        ICollection<CoordenadaCliente> ObtenerCoordenadasClientesInvalidas();
        [OperationContract]
        ICollection<CoordenadaCliente> ObtenerCoordenadasClientesPorZona(List<string> codigosClientes);
    }
}
