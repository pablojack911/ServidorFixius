using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
	public class CreadorOrdenDeCompra : CreadorDTO<Modelo.Proveedores.OrdenDeCompra, Servicios.DTO.Proveedores.OrdenDeCompra>
	{
		public CreadorOrdenDeCompra(ICreador<Modelo.Proveedores.OrdenDeCompra> creador,
									IMapeadorGenerico<Modelo.Proveedores.OrdenDeCompra,
													  Servicios.DTO.Proveedores.OrdenDeCompra> mapeador, string empresa, string entidad)
			: base(creador, mapeador, empresa, entidad)
		{
		}

        public override CreadorCarrier<Servicios.DTO.Proveedores.OrdenDeCompra> Crear(params int[] args)
		{
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Proveedores.OrdenDeCompra>();
			var entidad = this.CreadorEntidad.Crear(args);
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "Proveedor") };
            var buscaprov = (IBuscador<Modelo.Proveedores.Proveedor>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Proveedores.Proveedor>),parameters);
			entidad.Proveedor = buscaprov.BuscarSimple(args[0]);
			
			//area es el args[1]
			var areaID = args[1];
			var sectorId = args[2];
			var subSectorId = args[3];
			var familiaId = args[4];
			var subFamiliaId = args[5];
            parameters[1] = new ParameterOverride("entidad", "ListaDePrecios");
            var buscaLista = (BuscadorListaDePrecios)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Proveedores.ListaDePrecios>),parameters);
            entidad.ListaDePrecios = buscaLista.obtenerListaProveedor(entidad.Proveedor.Id,true);
			var mapper = (IMapeadorOrdenDeCompra)this.Mapeador;
            parameters[1] = new ParameterOverride("entidad", "Articulo");
            var buscaArticulo = (IBuscadorArticulo)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorArticulo),parameters);
			var articulos = buscaArticulo.obtenerArticulosProveedor(entidad.Proveedor.Id, areaID, sectorId,subSectorId,familiaId, subFamiliaId);
            parameters[1] = new ParameterOverride("entidad", "ObjetivosDeCompra");
            var buscaObjetivos = (IBuscadorObjetivos)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorObjetivos),parameters);
			var objetivos = buscaObjetivos.obtenerObjetivosProveedor(entidad.Proveedor.Id);
            creadorCarrier.SetEntidad(mapper.EntidadToDto(entidad, articulos, objetivos));
			return creadorCarrier;
		}    

	}
}
