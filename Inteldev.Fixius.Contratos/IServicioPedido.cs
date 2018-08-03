using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Organizacion;
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
    public interface IServicioPedido : IServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Pedido>
    {
        [OperationContract]
        Pedido CrearPedido(Cliente cliente, Preventista preventista, Empresa empresa, DivisionComercial divisionComercial);
    }
}
