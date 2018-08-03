using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorListaDePreciosDetalle<TDetalle> : BuscadorGenerico<TDetalle>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorListaDePreciosDetalle<TDetalle>, IBuscaCosto<ListaDePreciosDetalle>
		where TDetalle : ListaDePreciosDetalle
	{
        public BuscadorListaDePreciosDetalle(string empresa) : base(empresa, "ListaDePreciosDetalle") { }

		public ICollection<ListaDePreciosColumna> obtenerColumnasArticulo(int articuloId)
		{
			return this.Contexto.Consultar<TDetalle>(Core.CargarRelaciones.NoCargarNada)
				.Where(p => p.ArticuloId == articuloId).Select(p => p.Columnas).FirstOrDefault();
		}

		public Dictionary<int,decimal> BuscaCosto()
		{
			var detalle = this.Contexto.Consultar<ListaDePreciosDetalle>(Core.CargarRelaciones.NoCargarNada)
				.Select(lista => new { lista.Costo, lista.ArticuloId }).ToList();
			var result = new Dictionary<int, decimal>();
			foreach (var item in detalle)
			{
				result.Add((int)item.ArticuloId,item.Costo);
			}
			return result;
		}


		public ListaDePreciosDetalle BuscaPorArticulo(int articuloId)
		{
			throw new NotImplementedException();
		}
	}
}
