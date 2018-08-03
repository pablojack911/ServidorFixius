using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorListaDePrecios : IBuscador<Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios>
	{
		ListaDePrecios obtenerListaProveedor(int id, bool cargarEntidades);
	}
}
