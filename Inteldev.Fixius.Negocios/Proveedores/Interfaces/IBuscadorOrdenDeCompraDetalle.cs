using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorOrdenDeCompraDetalle : IBuscador<OrdenDeCompraDetalle>
	{
        Dictionary<Articulo, OrdenDeCompra> buscaArticulosIngresoStock(System.Collections.Generic.List<int> ordenesDeCompra);
		System.Collections.Generic.ICollection<Inteldev.Fixius.Modelo.Proveedores.ListaDePreciosColumna> obtenerColumnasArticulo(int articuloId);
	}
}
