using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorNotaDevolucion : BuscadorGenerico<Inteldev.Fixius.Modelo.Clientes.NotaDeDebitoDeVenta>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorNotaDevolucion
	{
		public BuscadorNotaDevolucion(string empresa)
			: base(empresa,"NotaDeDebitoDeVenta")
		{

		}

		public NotaDeDebitoDeVenta buscaPorArticulo(int articuloId )
		{
			return this.Contexto.Consultar<NotaDeDebitoDeVenta>(CargarRelaciones.NoCargarNada).Where(p => p.ArticuloId == articuloId).FirstOrDefault();
		}
	}
}
