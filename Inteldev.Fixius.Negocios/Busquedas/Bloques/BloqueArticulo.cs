using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Busquedas.Partes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Bloques
{
	public class BloqueArticulo : BlockDeBusqueda<Articulo>
	{
        public override void AgregarPartes(List<object> listaPropiedades, List<Core.Modelo.ParametrosMiniBusca> Parametros)
        {
            throw new NotImplementedException();
        }
		public override void AgregarPartes( )
		{
			var buscaArea = new BuscaPorArea();
			var buscaPorNombreProveedor = new BusquedaNombreProveedor<Articulo>();
			var buscaPorIdProveedor = new BuscaIdProveedor<Articulo>();
			var buscaPorId = new BusquedaPorInt<Articulo>();
			var buscaPorCodigo = new BusquedaString<Articulo>();
			var buscaPorNombre = new BusquedaString<Articulo>();
			buscaArea.Cargar(Busqueda);
			buscaPorNombreProveedor.Cargar(Busqueda);
			buscaPorIdProveedor.Cargar(Busqueda);
			buscaPorId.Cargar(Busqueda,"Id");
			buscaPorCodigo.Cargar(Busqueda,"Codigo");
			buscaPorNombre.Cargar(Busqueda,"Nombre");
			this.Partes.Add(buscaArea);
			this.Partes.Add(buscaPorNombreProveedor);
			this.Partes.Add(buscaPorIdProveedor);
			this.Partes.Add(buscaPorId);
			this.Partes.Add(buscaPorCodigo);
			this.Partes.Add(buscaPorNombre);
		}
	}
}
