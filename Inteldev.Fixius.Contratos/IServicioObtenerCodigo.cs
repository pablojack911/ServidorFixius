using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioObtenerCodigo
    {
        [OperationContract]
        string CodigoDisponible(string desde);
    }
}
