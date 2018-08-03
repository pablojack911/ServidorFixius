using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class ServicioDetallePedido : ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.DetallePedido,Inteldev.Fixius.Modelo.Preventa.DetallePedido>, IServicioDetallePedido
    {
        public DetallePedido CrearItemDetalle(Articulo articulo, Cliente cliente)
        {
            return new DetallePedido();
        }
    }
}
