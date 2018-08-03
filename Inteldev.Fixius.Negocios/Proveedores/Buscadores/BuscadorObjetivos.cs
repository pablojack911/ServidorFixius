using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Proveedores;
using System.Data;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorObjetivos : BuscadorGenerico<Modelo.Proveedores.ObjetivosDeCompra>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorObjetivos
	{
		public BuscadorObjetivos(string empresa) : base(empresa,"ObjetivosDeCompra")
		{

		}

		public ObjetivosDeCompra obtenerObjetivosProveedor(int id)
		{
			var objetivos =  this.Contexto.Consultar<Modelo.Proveedores.ObjetivosDeCompra>(CargarRelaciones.CargarTodo)
				.Include("Objetivos")
				.Include("Objetivos.Articulo")
				.Where(l=>l.Proveedor.Id == id).FirstOrDefault();
			
			if (objetivos == null)
			{
				objetivos = new Modelo.Proveedores.ObjetivosDeCompra();
			}

			return objetivos;
		}
	}
}
