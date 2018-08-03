using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Proveedores;
using System.Data;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Microsoft.Practices.Unity;
using Inteldev.Core.DataSwitch;

namespace Inteldev.Fixius.Negocios.Proveedores.Mapeadores
{
	public class MapeadorOrdenDeCompra : Inteldev.Fixius.Negocios.Proveedores.Interfaces.IMapeadorOrdenDeCompra
	{
		private IList<Sucursal> sucursales;
        private string empresa;
        private string entidad;

		public MapeadorOrdenDeCompra(string empresa, string entidad)
		{
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "Sucursal") };
            var buscadorSucursal = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Sucursal>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Sucursal>), parameters);
			this.sucursales = buscadorSucursal.BuscarLista(1, CargarRelaciones.NoCargarNada);
            this.empresa = empresa;
            this.entidad = entidad;
		}

		private DataTable crearDataTable(Modelo.Proveedores.PlantillaListaProveedor plantilla)
		{
			var detalle = new DataTable("Detalle");
            if(!detalle.Columns.Contains("Cantidad"))
			    detalle.Columns.Add(new DataColumn("Cantidad",typeof(int)));
			//aca tengo que poner las cantidades 
			foreach (var item in this.sucursales)
			{
				detalle.Columns.Add(new DataColumn(item.Nombre,typeof(int)));
			}
			detalle.Columns.Add(new DataColumn("Articulo", typeof(int)));
			detalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
			detalle.Columns.Add(new DataColumn("Bultos", typeof(int)));
			detalle.Columns.Add(new DataColumn("DescuentoPotencial", typeof(decimal)));
			detalle.Columns.Add(new DataColumn("DescuentoAplicado", typeof(string)));
			foreach (var columna in plantilla.Columnas)
			{
				detalle.Columns.Add(new DataColumn(columna.Nombre, typeof(decimal)));
				if (columna.Nombre == "Neto")
				{
					detalle.Columns.Add(new DataColumn("DescuentoObjetivos", typeof(Decimal)));
					detalle.Columns.Add(new DataColumn("SubtotalObjetivos", typeof(decimal)));
				}
			}
			return detalle;
		}

		//esto tambien hay que cambiarlo...
		private List<Servicios.DTO.Proveedores.Columna> getColumnas(Modelo.Proveedores.PlantillaListaProveedor plantilla)
		{
			var result = new List<Servicios.DTO.Proveedores.Columna>();
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = 0, Nombre = "Cantidad", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Cantidad });
			for (int i = 0; i < this.sucursales.Count; i++)
			{
				result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = i+1, Nombre = this.sucursales.ElementAt(i).Nombre, TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Cantidad });
			}
			
			var counter = this.sucursales.Count + 1;
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = counter, Nombre = "Articulo" , TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Final});
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = counter+1, Nombre = "Descripcion", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Final });
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = counter+2, Nombre = "Bultos", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Final});
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = counter+3, Nombre = "DescuentoPotencial", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Final });
			result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = counter+4, Nombre = "DescuentoAplicado", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.Final});
			
			foreach (var item in plantilla.Columnas)
			{
				var column = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.Columna, Servicios.DTO.Proveedores.Columna>(item);
				column.Orden += (counter + 7);
				if (column.Nombre == "Neto")
				{
					column.Orden = column.Orden - 2;
					result.Add(column);
					result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = column.Orden+1, Nombre = "DescuentoObjetivos", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.DescuentoLineal });
					result.Add(new Servicios.DTO.Proveedores.Columna() { Orden = column.Orden + 2, Nombre = "SubtotalObjetivos", TipoColumna = Servicios.DTO.Proveedores.TipoColumna.SubTotal });
				}
				else
					result.Add(column);
			}
			return result;
		}

		private Modelo.Proveedores.PlantillaListaProveedor cargarPlantilla(int idProveedor)
		{
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "PlantillaListaProveedor") };
            var buscadorPlantilla = (IBuscador<Modelo.Proveedores.PlantillaListaProveedor>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Proveedores.PlantillaListaProveedor>),parameters);
			buscadorPlantilla.CargarEntidadesRelacionadas = CargarRelaciones.CargarTodo;
			var plantilla = buscadorPlantilla.BuscarLista(
				pl => pl.Proveedores.FirstOrDefault(pr => pr.Id == idProveedor) != null, buscadorPlantilla.CargarEntidadesRelacionadas).FirstOrDefault();

			return plantilla;
		}

		private void sincronizarDetalle(DataTable dataTable, ICollection<Modelo.Proveedores.OrdenDeCompraDetalle> listadetalle)
		{
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
			var tipo = typeof(Modelo.Proveedores.OrdenDeCompraDetalle);
			Predicate<string> existe = (nomprop => tipo.GetProperty(nomprop) != null);
			Action<string, object, object> set = ((nomprop, objeto, valor) => tipo.GetProperty(nomprop).SetValue(objeto, valor));
			parameters[1] = new ParameterOverride("entidad","Articulo");
            var buscaArticulo = (IBuscador<Articulo>) FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Articulo>),parameters);
			buscaArticulo.CargarEntidadesRelacionadas = CargarRelaciones.NoCargarNada;
            parameters[1] = new ParameterOverride("entidad","OrdenDeCompraDetalle");
            var buscaDetalleLista = (BuscadorOrdenDeCompraDetalle) FabricaNegocios.Instancia.Resolver(typeof(BuscadorOrdenDeCompraDetalle),parameters);
			foreach (DataRow row in dataTable.Rows)
			{
				if (row.RowState != DataRowState.Unchanged)
				{
					var detalle = new Modelo.Proveedores.OrdenDeCompraDetalle();
					var articuloId = row.Field<int>("Articulo");
					var columnas = buscaDetalleLista.obtenerColumnasArticulo(articuloId);
					foreach (DataColumn Columna in dataTable.Columns)
					{

						if (Columna.ColumnName != "Descripcion")
						{
							if (existe(Columna.ColumnName))
							{
								if (Columna.ColumnName == "Articulo")
									detalle.Articulo = buscaArticulo.BuscarSimple(row[Columna.ColumnName]);
								else
								{
									if (row[Columna] != null)
									{
										set(Columna.ColumnName, detalle, row[Columna]);
									}
								}
							}
							else
							{
								decimal valor;
								if (decimal.TryParse(row[Columna].ToString(), out valor))
								{
									var detallecolumna = new Modelo.Proveedores.ListaDePreciosColumna();
									detallecolumna.Nombre = Columna.ColumnName;
									var col = columnas.FirstOrDefault(p => p.Nombre == Columna.ColumnName);
									if (col != null)
										detallecolumna.Id = col.Id;
									else
										detallecolumna.Id = 0;
									detallecolumna.Valor = Convert.ToDecimal(valor);
									detalle.Columnas.Add(detallecolumna);
								}
							}
						}
					}
					listadetalle.Add(detalle);
				}
			}
		}

		private void cargarDataTable(DataTable tabla, Modelo.Proveedores.OrdenDeCompra entidad, List<Articulo> articulos, ObjetivosDeCompra objetivos)
		{
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            var db = (IDataSwitch<OrdenDeCompra>)FabricaNegocios.Instancia.Resolver(typeof(IDataSwitch<OrdenDeCompra>),parameters);
			var lista = entidad.ListaDePrecios;
			
			string no = "No";

			var resultado = from a in articulos
							join l in lista.Detalle on a.Id equals l.ArticuloId into aa
							join u in entidad.Detalle on a.Id equals u.ArticuloId into cc
							join h in objetivos.Objetivos on a.Id equals h.Articulo.Id into ee
							from bb in aa.DefaultIfEmpty(new Modelo.Proveedores.ListaDePreciosDetalle())
							from dd in cc.DefaultIfEmpty(new Modelo.Proveedores.OrdenDeCompraDetalle())
							from ff in ee.DefaultIfEmpty(new Modelo.Proveedores.Objetivos())
							select new
							{
								dd.Cantidad,
								Articulo = a.Id,
								Descripcion = a.Nombre,
								Bultos = ff.Bultos,
								DescuentoPotencial = ff.Descuento,
								DescuentoAplicado = no,
								bb.Neto,
								bb.Iva,
								bb.ImpInterno,
								bb.Costo,
								bb.Final,
								bb.Columnas
							};
			

			var columnas = tabla.Columns;
			foreach (var item in resultado)
			{
				var row = tabla.NewRow();
				foreach (DataColumn columna in columnas)
				{
					var prop = item.GetType().GetProperty(columna.ColumnName);
					object valor = null;
					if (prop == null)
					{
						if (item.Columnas.Any())
						{
							var result = item.Columnas.Where(c => c.Nombre == columna.ColumnName).FirstOrDefault();
							if(result != null)
								valor = result.Valor;
						}
						else
							valor = 0;
					}
					else
					{
						valor = prop.GetValue(item);
					}

					if (valor != null)
					{
						row[columna.ColumnName] = valor;
					}
					else
					{
						if (columna.DataType.Equals(typeof(int)) || columna.DataType.Equals(typeof(decimal)))
						{
							row[columna.ColumnName] = 0;
						}
					}
				}
				tabla.Rows.Add(row);
			}
			foreach (DataRow row in tabla.Rows)
			{
				row.AcceptChanges();
			}
		}


		public Modelo.Proveedores.OrdenDeCompra DtoToEntidad(Servicios.DTO.Proveedores.OrdenDeCompra dto, Modelo.Proveedores.OrdenDeCompra entidad)
		{
			entidad.Id = dto.Id;
			entidad.Nombre = dto.Nombre;
			entidad.Codigo = dto.Codigo;
			entidad.CondicionDePago = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.CondicionDePagoProveedor, Modelo.Proveedores.CondicionDePagoProveedor>(dto.CondicionDePago);
			entidad.Deposito = Mapeador.Instancia.DtoToEntidad<Inteldev.Core.DTO.Stock.Deposito, Inteldev.Core.Modelo.Stock.Deposito>(dto.Deposito);
			entidad.Estado = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.EstadoOrdenDeCompra, Modelo.Proveedores.EstadoOrdenDeCompra>(dto.Estado);			;
			entidad.FechaEntrega = dto.FechaEntrega;
			entidad.ImporteFinal = dto.ImporteFinal;
			entidad.Marca = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Articulos.Marca, Modelo.Articulos.Marca>(dto.Marca);
			entidad.TipoOrden = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.TipoOrden, Modelo.Proveedores.TipoOrden>(dto.TipoOrden);
			entidad.TotalBultos = dto.TotalBultos;
			entidad.Proveedor = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.Proveedor, Modelo.Proveedores.Proveedor>(dto.Proveedor);
			entidad.ListaDePrecios = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.ListaDePrecios, Modelo.Proveedores.ListaDePrecios>(dto.ListaDePrecios);
			this.sincronizarDetalle(dto.Detalle, entidad.Detalle);
			return entidad;
		}

		public Modelo.Proveedores.OrdenDeCompra DtoToEntidad(Servicios.DTO.Proveedores.OrdenDeCompra dto)
		{
			return this.DtoToEntidad(dto, new Modelo.Proveedores.OrdenDeCompra());
		}

		public Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(Modelo.Proveedores.OrdenDeCompra entidad, Servicios.DTO.Proveedores.OrdenDeCompra dto,List<Articulo> articulos,ObjetivosDeCompra objetivos)
		{
			var plantilla = this.cargarPlantilla(entidad.Proveedor.Id);

			dto.Id = entidad.Id;
			dto.Nombre = entidad.Nombre;
			dto.Codigo = entidad.Codigo;
            
			dto.CondicionDePago = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.CondicionDePagoProveedor, Servicios.DTO.Proveedores.CondicionDePagoProveedor>(entidad.CondicionDePago);
			dto.Deposito = Mapeador.Instancia.EntidadToDto<Inteldev.Core.Modelo.Stock.Deposito, Inteldev.Core.DTO.Stock.Deposito>(entidad.Deposito);
			dto.Estado = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.EstadoOrdenDeCompra, Servicios.DTO.Proveedores.EstadoOrdenDeCompra>(entidad.Estado);
			dto.FechaEntrega = entidad.FechaEntrega;
			dto.ImporteFinal = entidad.ImporteFinal;
			dto.Marca = Mapeador.Instancia.EntidadToDto<Modelo.Articulos.Marca, Servicios.DTO.Articulos.Marca>(entidad.Marca);
			dto.TipoOrden = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.TipoOrden, Servicios.DTO.Proveedores.TipoOrden>(entidad.TipoOrden);
			dto.TotalBultos = entidad.TotalBultos;
			dto.Proveedor = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>(entidad.Proveedor);
			dto.ListaDePrecios = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.ListaDePrecios, Servicios.DTO.Proveedores.ListaDePrecios>(entidad.ListaDePrecios);
            if (plantilla != null)
            {
                dto.Columnas = this.getColumnas(plantilla);
                dto.Detalle = this.crearDataTable(plantilla);
                this.cargarDataTable(dto.Detalle, entidad, articulos, objetivos);
            }
			if (dto.Id != 0)
			{
				foreach (DataRow row in dto.Detalle.Rows)
				{
					var neto = (int)row["Cantidad"];
					if (neto != 0)
						row.SetModified();
				}
			}
			return dto;

		}

		public Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(Modelo.Proveedores.OrdenDeCompra entidad, List<Articulo> articulos, ObjetivosDeCompra objetivos)
		{
			var listaDto = new Servicios.DTO.Proveedores.OrdenDeCompra();
			return this.EntidadToDto(entidad, listaDto,articulos, objetivos);
		}

		public List<Servicios.DTO.Proveedores.OrdenDeCompra> ToListDto(List<Modelo.Proveedores.OrdenDeCompra> listaEntidades)
		{
			var listadto = new List<Servicios.DTO.Proveedores.OrdenDeCompra>();
			listaEntidades.ForEach(l => listadto.Add(new Servicios.DTO.Proveedores.OrdenDeCompra() { Id = l.Id, Nombre = l.Nombre }));
            //foreach (var item in listaEntidades)
            //{
            //    listadto.Add(this.EntidadToDto(item));
            //}
			return listadto;
		}

		public List<Modelo.Proveedores.OrdenDeCompra> ToListEntidad(List<Servicios.DTO.Proveedores.OrdenDeCompra> listaDto)
		{
			var result = new List<OrdenDeCompra>();
			foreach (var item in listaDto)
			{
				result.Add(this.DtoToEntidad(item));
			}
			return result;
		}

		public Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(OrdenDeCompra entidad, Servicios.DTO.Proveedores.OrdenDeCompra dto)
		{
			throw new NotImplementedException();
		}

		public Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(OrdenDeCompra entidad)
		{
			throw new NotImplementedException();
		}


        public List<OrdenDeCompra> ToListEntidad(object listaDto)
        {
            throw new NotImplementedException();
        }


        public OrdenDeCompra DtoToEntidad(object dto)
        {
            throw new NotImplementedException();
        }


        public AutoMapper.IMappingEngine MotorDeMapeador()
        {
            return Mapeador.Instancia.Engine;
        }
    }
}
