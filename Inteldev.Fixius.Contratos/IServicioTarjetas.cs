using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioTarjetas
    {
        /// <summary>
        /// Consulta la base de datos para evaluar si la tarjeta existe, y si existe a quién está asignada
        /// </summary>
        /// <param name="codigoTarjeta">Codigo de la tarjeta</param>
        /// <returns>Codigo del cliente que tiene asociado la tarjeta o null no llegara a estar utilizada.</returns>
        [OperationContract]
        string EsDuplicada(string codigoTarjeta);
        [OperationContract]
        bool CantidadHabilitada(List<TarjetaMayoristaItem> listaTarjetas);
    }
}
