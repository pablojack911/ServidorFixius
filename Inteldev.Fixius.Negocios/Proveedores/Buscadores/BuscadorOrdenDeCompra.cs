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
	public class BuscadorOrdenDeCompra : BuscadorGenerico<Modelo.Proveedores.OrdenDeCompra>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorOrdenDeCompra
	{
		public BuscadorOrdenDeCompra(string empresa,string entidad) :base(empresa,entidad)
		{

		}
		public List<Articulo> buscaArticulosOrdenDeCompra(int ordenDeCompra)
		{
			var orden = this.Contexto.Consultar<OrdenDeCompra>(CargarRelaciones.CargarCollecciones)
				.Where(p=>p.Id == ordenDeCompra).FirstOrDefault();
			var articulos = new List<Articulo>();
			foreach (var item in orden.Detalle)
			{
				articulos.Add(item.Articulo);
			}
			return articulos;
		}

		public List<OrdenDeCompra> BuscarOrdenes(List<int> ordenesDeCompra)
		{
			var consulta = this.Contexto.Consultar<OrdenDeCompra>(CargarRelaciones.NoCargarNada);
			foreach (var item in ordenesDeCompra)
			{
				consulta.Where(p=>p.Id == item);
			}
			return consulta.ToList();
		}

		public List<OrdenDeCompra> BuscarOrdenes(EstadoOrdenDeCompra estado, int ProveedorId )
		{
			return this.Contexto.Consultar<OrdenDeCompra>(CargarRelaciones.CargarTodo).Where(p => p.Estado == estado && p.ProveedorId == ProveedorId).ToList();
		}
	}
}
