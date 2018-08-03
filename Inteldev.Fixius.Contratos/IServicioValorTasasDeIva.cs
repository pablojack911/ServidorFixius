using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioValorTasasDeIva
    {
        [OperationContract]
        decimal ObtenerValorDeTasaDeIVA(EnumTasas tasa);
    }
}
