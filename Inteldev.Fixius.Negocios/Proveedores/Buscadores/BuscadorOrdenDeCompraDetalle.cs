using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorOrdenDeCompraDetalle : BuscadorGenerico<Modelo.Proveedores.OrdenDeCompraDetalle>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorOrdenDeCompraDetalle
	{
		public BuscadorOrdenDeCompraDetalle(string empresa, string entidad) : base(empresa,entidad) { }

		public ICollection<ListaDePreciosColumna> obtenerColumnasArticulo(int articuloId)
		{
			return this.Contexto.Consultar<ListaDePreciosDetalle>(Core.CargarRelaciones.CargarTodo)
				.Where(p => p.ArticuloId == articuloId).Select(p => p.Columnas).FirstOrDefault();				
		}

		public Dictionary<Articulo,OrdenDeCompra> buscaArticulosIngresoStock(List<int> ordenesDeCompra)
		{
			var result = new Dictionary<Articulo,OrdenDeCompra>();
			var consulta = this.Contexto.Consultar<OrdenDeCompra>(CargarRelaciones.CargarTodo);
			foreach (var item in ordenesDeCompra)
			{
				consulta.Where(p=>p.Id==item);
			}
			var detalleOrdenes = consulta.Select(p=>p.Detalle);
			foreach (var detalle in detalleOrdenes)
			{
                var ordenDeCompra = consulta.Where(p=>p.Detalle == detalle).FirstOrDefault();
				foreach (var item in detalle)
				{
					result.Add(item.Articulo,ordenDeCompra);
				}
			}
			return result;
		}

		public ListaDePreciosDetalle BuscaPorArticulo(int articuloId)
		{
			return this.Contexto.Consultar<ListaDePreciosDetalle>(CargarRelaciones.CargarEntidades).Where(p => p.ArticuloId == articuloId).FirstOrDefault();
		}

	}
}
