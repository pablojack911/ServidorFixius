using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorListaDePreciosDetalle<TDetalle> : IBuscador<TDetalle>
		where TDetalle : ListaDePreciosDetalle
	{

		System.Collections.Generic.ICollection<ListaDePreciosColumna> obtenerColumnasArticulo(int articuloId);
		ListaDePreciosDetalle BuscaPorArticulo(int articuloId);
	}
}