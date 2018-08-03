using Inteldev.Core.Negocios;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Negocios.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
	public class ServicioOrdenDeCompra : ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra,Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra>, Inteldev.Fixius.Contratos.IServicioOrdenDeCompra
	{
		public List<OrdenDeCompra> ObtenerOrdenesDeCompra(EstadoOrdenDeCompra estado, int proveedorId )
		{
			var buscador = FabricaNegocios._Resolver<IBuscadorDTOOrdenDeCompra>();
			return buscador.BuscarOrdenes(estado, proveedorId);
		}
	}
}
