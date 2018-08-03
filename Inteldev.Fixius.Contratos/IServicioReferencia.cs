using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Inteldev.Fixius.Contratos
{
    [ServiceContract]
    public interface IServicioReferencia
    {
        [OperationContract]
        decimal ObtenerTasa(Inteldev.Fixius.Servicios.DTO.Proveedores.TipoConcepto tipoConcepto);
        [OperationContract]
        ConceptoDeMovimiento ObtenerConcepto(Empresa empresa, TipoDocumento tipoDocumento, TipoConcepto tipoConcepto);
    }
}
