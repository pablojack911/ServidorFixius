using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Stock;
using Inteldev.Fixius.Negocios.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Servicios.DTO.Stock;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock
{
	public class CreadorIngreso : CreadorDTO<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>
	{
		public CreadorIngreso(ICreador<Modelo.Stock.Ingreso> creadorEntidad, IMapeadorGenerico<Modelo.Stock.Ingreso,Servicios.DTO.Stock.Ingreso> mapeador, string empresa, string entidad) : base(creadorEntidad,mapeador, empresa, entidad)
		{
            //ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa) };
            //this.Mapeador = (IMapeadorGenerico<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>)FabricaNegocios.Instancia.Resolver(typeof(IMapeadorGenerico<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>),parameters);
		}
		/// <summary>
		/// args[0] = Tipo (enum)
		/// args[1] = deposito
		/// args[2] = proveedor
		/// args[3] = orden de compra (varias)
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public override CreadorCarrier<Servicios.DTO.Stock.Ingreso> Crear(params int[] args)
		{
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "OrdenDeCompra") };
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Stock.Ingreso>();
            var creadorOrdenDeCompra = (ICreador<Modelo.Proveedores.OrdenDeCompra>)FabricaNegocios.Instancia.Resolver(typeof(ICreador<Modelo.Proveedores.OrdenDeCompra>),parameters);
			var result = new Modelo.Stock.Ingreso();
            //dasdasdsadsa
            parameters[1] = new ParameterOverride("entidad","Articulo");
            var buscadorArticulo = (IBuscadorArticulo)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorArticulo), parameters);
            parameters[1] = new ParameterOverride("entidad","Deposito");
            var buscaDeposito = (IBuscadorDTO<Inteldev.Core.Modelo.Stock.Deposito, Core.DTO.Stock.Deposito>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Stock.Deposito, Core.DTO.Stock.Deposito>),parameters);
            parameters[1] = new ParameterOverride("entidad","Proveedor");
            var buscaProveedor = (IBuscadorDTO<Modelo.Proveedores.Proveedor,Servicios.DTO.Proveedores.Proveedor>) FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Modelo.Proveedores.Proveedor,Servicios.DTO.Proveedores.Proveedor>),parameters);
			if (args[0] == 1)
			{
				List<int> ordenesDeCompra = new List<int>();
				for (int i = 3; i < args.Length; i++)
				{
					ordenesDeCompra.Add(args[i]);
				}
                parameters[1] = new ParameterOverride("entidad","OrdenDeCompra");
                var buscadorOrdenDeCompra = (IBuscadorOrdenDeCompra)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorOrdenDeCompra),parameters);
                parameters[1] = new ParameterOverride("entidad","OrdenDeCompraDetalle");
                var buscadorOrdenDeCompraDetalle = (IBuscadorOrdenDeCompraDetalle)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorOrdenDeCompraDetalle),parameters);
				var articulos = buscadorOrdenDeCompraDetalle.buscaArticulosIngresoStock(ordenesDeCompra);
				foreach (var articulo in articulos)
				{
					var item = new Modelo.Stock.ItemIngreso();
                    //articulos es un diccionario que tiene articulos - orden de compra
                    item.Articulo = articulo.Key;
                    item.OrdenDeCompra = articulo.Value;
					result.Items.Add(item);
				}
				result.OrdenesDeCompra = buscadorOrdenDeCompra.BuscarOrdenes(ordenesDeCompra);
			}
			else
			{
                var articulos = buscadorArticulo.obtenerArticulosProveedor(args[2]);
				foreach (var articulo in articulos)
				{
					var item = new Inteldev.Fixius.Modelo.Stock.ItemIngreso();
					item.Articulo = articulo;
					result.Items.Add(item);
				}
			}
            if (result.OrdenesDeCompra.Count == 0)
            {
                result.OrdenesDeCompra.Add(creadorOrdenDeCompra.Crear());
            }
            var dto = this.Mapeador.EntidadToDto(result);
            dto.Proveedor = buscaProveedor.BuscarSimple(args[2],Core.CargarRelaciones.NoCargarNada);
            dto.Deposito = buscaDeposito.BuscarSimple(args[1],Core.CargarRelaciones.NoCargarNada);
            creadorCarrier.SetEntidad(dto);
            return creadorCarrier;
		}
	}
}
