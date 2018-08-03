using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System.Data;
using Inteldev.Core;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Negocios.Proveedores.Mapeadores;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorDTOListaDePrecios : BuscadorDTO<Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios,ListaDePrecios>
	{

		public BuscadorDTOListaDePrecios(IBuscadorListaDePrecios buscadorEntidad, IMapeadorGenerico<Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios, Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios> mapeador)
			: base(buscadorEntidad,mapeador)
		{
		}

		public ListaDePrecios obtenerListaProveedor(int id, bool cargaEntidad)
		{
			this.BuscadorEntidad = FabricaNegocios._Resolver<IBuscadorListaDePrecios>();
			var buscador = (IBuscadorListaDePrecios)this.BuscadorEntidad;
			//var mapper = (MapeadorListaDePrecios)this.Mapeador;
			//var mapper = new MapeadorListaDePrecios();
			var result = buscador.obtenerListaProveedor(id, cargaEntidad);
			var devuelvo = this.Mapeador.EntidadToDto(result);
			
			return devuelvo;
		}


		public new List<Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios> BuscarLista(object param, CargarRelaciones cargarEntidades)
		{
			return base.BuscarLista(param,cargarEntidades);
		}

		public new Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios BuscarPorCodigo<TMaestro>(object busqueda, CargarRelaciones cargarEntidades) where TMaestro : Core.Modelo.EntidadMaestro
		{
			return base.BuscarPorCodigo<TMaestro>(busqueda,cargarEntidades);
		}

		public new Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios BuscarSimple(object busqueda, CargarRelaciones cargarEntidades)
		{
			return base.BuscarSimple(busqueda,cargarEntidades);
		}

	}
}
