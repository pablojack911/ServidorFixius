using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class ServicioPedido : ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Pedido,Inteldev.Fixius.Modelo.Preventa.Pedido>, IServicioPedido
    {
        public Pedido CrearPedido(Cliente cliente, Preventista preventista, Empresa empresa, DivisionComercial divisionComercial)
        {
            var pedido = new Pedido();
            var detalle = new DetallePedido();
            pedido.Cliente = cliente;
            pedido.ClienteId = cliente.Id;
            pedido.Preventista = preventista;
            pedido.PreventistaId = preventista.Id;
            detalle.Empresa = empresa;
            detalle.DivisionComercial = divisionComercial;
            detalle.DivisionComercialId = divisionComercial.Id;
            pedido.DetallePedido.Add(detalle);
            return pedido;
        }
    }
}
