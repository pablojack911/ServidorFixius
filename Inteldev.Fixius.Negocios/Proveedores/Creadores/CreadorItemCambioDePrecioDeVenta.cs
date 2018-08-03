using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
	public class CreadorItemCambioDePrecioDeVenta<TCosto> : Inteldev.Fixius.Negocios.Proveedores.Interfaces.ICreadorItemCambioDePrecioDeVenta<TCosto>
		where TCosto : EntidadBase
	{
		private IBuscadorArticulo buscadorArticulo;
		private IBuscaCosto<TCosto> buscadorCosto;

		public CreadorItemCambioDePrecioDeVenta(IBuscaCosto<TCosto> buscadorCosto, IBuscadorArticulo buscadorArticulo)
		{
			this.buscadorArticulo = buscadorArticulo;
			this.buscadorCosto = buscadorCosto;
		}

		public List<ItemCambioDePrecioDeVenta> CreaItems(int folder,int areaID,int sectorID,int subsectorID,int familiaID, int subfamiliaID, int marca)
		{
			var result = new List<ItemCambioDePrecioDeVenta>();
			var costos = buscadorCosto.BuscaCosto();
			var articulos = this.buscadorArticulo.obtenerArticulos(folder,areaID,sectorID,subsectorID,familiaID,subfamiliaID,marca);
			foreach (var articulo in articulos)
			{
				var item = new ItemCambioDePrecioDeVenta();
				item.Articulo = articulo;
				item.ArticuloId = articulo.Id;
                if (costos!=null && costos.Count!=0)
				    item.Costo = costos[articulo.Id];

				var unidad = articulo.CodigoEAN.FirstOrDefault(p=>p.Activo == true);
				if (unidad != null && unidad.UnidadesPorBulto != 0)
				{
					item.CFU = item.Costo / (int)unidad.UnidadesPorBulto;
				}
				else
					item.CFU = 0;
				result.Add(item);
			}
			return result;
		}
	}
}
