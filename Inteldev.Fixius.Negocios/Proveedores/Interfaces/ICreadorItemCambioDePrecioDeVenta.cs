using Inteldev.Core.Modelo;
using System;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface ICreadorItemCambioDePrecioDeVenta<TCosto>
		where TCosto : EntidadBase
	{
		System.Collections.Generic.List<Inteldev.Fixius.Modelo.Precios.ItemCambioDePrecioDeVenta> CreaItems(int folder, int areaID, int sectorID, int subsectorID, int familiaID, int subfamiliaID, int marca);
	}
}
