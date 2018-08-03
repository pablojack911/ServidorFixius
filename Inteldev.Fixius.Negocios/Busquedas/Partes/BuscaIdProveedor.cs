using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
	public class BuscaIdProveedor<TEntidad> :  ParteBusqueda<TEntidad> 
		where TEntidad:EntidadBase
	{
		public void Cargar(object busqueda)
		{
            this.Nombre = "IdProveedor";
            int Busqueda;
            this.PuedeBuscar = (p => int.TryParse(p.ToString(), out Busqueda));
            this.SetearParteIzquierda("Proveedor","Id",typeof(Proveedor));
            int id = 0;
            int.TryParse(busqueda.ToString(), out id);
            this.SetearParteDerecha(id,typeof(int));
            this.JuntaExpressionIgual();
		}
	}
}
