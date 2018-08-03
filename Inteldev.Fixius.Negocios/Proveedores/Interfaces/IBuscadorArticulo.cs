using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorArticulo : IBuscador<Articulo>
	{
		System.Collections.Generic.List<Inteldev.Fixius.Modelo.Articulos.Articulo> obtenerArticulosProveedor(int id, int areaId, int sectorId, int subSectorId, int familiaId, int subFamiliaId);
		List<Articulo> obtenerArticulosProveedor(int id);
		List<Articulo> obtenerArticulos(int folder, int areaID, int sectorID, int subsectorID, int familiaID,
			int subfamiliaID, int marca);
	}
}
