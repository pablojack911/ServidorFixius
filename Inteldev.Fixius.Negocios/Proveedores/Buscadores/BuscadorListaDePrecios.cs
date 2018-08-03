using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorListaDePrecios : BuscadorGenerico<Modelo.Proveedores.ListaDePrecios>, IBuscadorListaDePrecios
    {
        public BuscadorListaDePrecios(string empresa)
            : base(empresa,"ListaDePrecios")
        { }

        public override Modelo.Proveedores.ListaDePrecios BuscarSimple(object busqueda)
        {
			//aca fijate de mejorarlo despues 
            if (this.CargarEntidadesRelacionadas == Core.CargarRelaciones.CargarTodo)
                return this.Contexto.Consultar<Modelo.Proveedores.ListaDePrecios>(this.CargarEntidadesRelacionadas)
					.Include(d => d.Detalle.Select(a => a.Articulo))
                    .Where(l => l.Id == (int)busqueda)
                    .FirstOrDefault();
            else
                return base.BuscarSimple(busqueda);
        }

		public ListaDePrecios obtenerListaProveedor(int id, bool cargarEntidades)
		{
				//falta que devuelva nada mas que la que esta vigente
				var result =  this.Contexto.Consultar<Modelo.Proveedores.ListaDePrecios>(this.CargarEntidadesRelacionadas)
					.Include(d => d.Proveedor)
					.Include(l => l.Detalle.Select(a=>a.Articulo))
					.Include("Detalle.Columnas")
					.Where(p => p.Proveedor.Id == id)
					.FirstOrDefault();

				return result;
		}

    }
}
