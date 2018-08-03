using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioPercepcion
    {
        [OperationContract]
        decimal ObtenerPorcentajeDePercepcion(string Cuit);
    }
}
