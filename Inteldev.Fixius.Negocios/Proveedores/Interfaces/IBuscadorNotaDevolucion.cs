using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorNotaDevolucion
	{
		Inteldev.Fixius.Modelo.Clientes.NotaDeDebitoDeVenta buscaPorArticulo(int articuloId);
	}
}
