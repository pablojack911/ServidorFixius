using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorOrdenDeCompra
	{
		System.Collections.Generic.List<Inteldev.Fixius.Modelo.Articulos.Articulo> buscaArticulosOrdenDeCompra(int ordenDeCompra);
		List<OrdenDeCompra> BuscarOrdenes(List<int> ordenesDeCompra);
		List<OrdenDeCompra> BuscarOrdenes(EstadoOrdenDeCompra estado, int ProveedorId);
	}
}
