using Inteldev.Core.Contratos;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioProveedor : IServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor>
    {
        [OperationContract]
        List<ConceptoDeMovimiento> ObtenerConceptosDeMovimiento(int idProv);
    }
}
