using System;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorObjetivos
	{
		Inteldev.Fixius.Modelo.Proveedores.ObjetivosDeCompra obtenerObjetivosProveedor(int id);
	}
}
