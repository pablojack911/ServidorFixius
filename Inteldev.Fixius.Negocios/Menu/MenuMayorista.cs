using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Menu;
using Inteldev.Core.Negocios.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Menu
{
	public class MenuMayorista : GestorMenu, IMenuMayorista
	{
		public MenuMayorista()
			: base()
		{ }

		public override void Crear( )
		{
			base.CargaGeneral();
			var f = agregarEntrada(raiz, "Facturacion");
			agregarEntrada(f, "Maestro de Clientes");
			agregarEntrada(f, "Tabla Tarjetas Mayorista");
			agregarEntrada(f, "Emision de Comprobantes");
			agregarEntrada(f, "Tabla de Ramos");
			agregarEntrada(f, "Tabla de Grupos Cliente");
		}

	}
}
