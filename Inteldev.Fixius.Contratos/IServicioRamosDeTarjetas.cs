using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioRamosDeTarjetas
    {
        [OperationContract]
        bool EncontroRamoEnTarjetas(Ramo ramo, List<TarjetaMayoristaItem> listaTarjetas);
    }
}
