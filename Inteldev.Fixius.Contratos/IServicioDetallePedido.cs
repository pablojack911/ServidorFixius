using Inteldev.Core.Contratos;
using Inteldev.Fixius.Servicios.DTO.Articulos;
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
    public interface IServicioDetallePedido : IServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.DetallePedido>
    {
        [OperationContract]
        DetallePedido CrearItemDetalle(Articulo articulo, Cliente cliente);
    }
}
