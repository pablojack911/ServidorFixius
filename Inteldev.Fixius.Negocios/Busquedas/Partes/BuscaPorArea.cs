using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
	public class BuscaPorArea : ParteBusqueda<Articulo>
	{
		public void Cargar(object Busqueda)
		{
            //this.Nombre = "Area";
            //this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()) && p.ToString().Length > 3);
            //this.AgregaParteIzquierdaBuscarPor("Area","Nombre",typeof(Area),typeof(Articulo));
            ////this.AgregaParteIzquierdaBuscarPor("Area.Nombre",typeof(Area));
            //this.tipoBusqueda = typeof(string);
            //this.busqueda = Busqueda.ToString();
            //this.CondicionWhereContains();
		}

		
	}
}
