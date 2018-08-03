using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Precios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Precios
{
	public class MapeadorCambioDePreciosDeVenta : IMapeadorGenerico<Inteldev.Fixius.Modelo.Precios.CambioDePreciosDeVenta, Inteldev.Fixius.Servicios.DTO.Precios.CambioDePreciosDeVenta>
	{

		public DataTable CreateDataTable()
		{
			var datatable = new DataTable("Detalle");
			datatable.Columns.Add(new DataColumn("Articulo", typeof(string)));
			datatable.Columns.Add(new DataColumn("Descripcion", typeof(string)));
			datatable.Columns.Add(new DataColumn("Costo", typeof(decimal)));
			datatable.Columns.Add(new DataColumn("CFU",typeof(decimal)));
			//aca es donde por cada unidad de negocio hago un par
			foreach (var item in getNombresColumnasUnidadDeNegocio())
			{
				datatable.Columns.Add(new DataColumn(item, typeof(decimal)));
			}
			return datatable;
		}

		private List<string> getNombresColumnasUnidadDeNegocio()
		{
			var result = new List<string>();
			foreach (string unidadDeNegocio in Enum.GetNames(typeof(Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio)))
			{
				result.Add(unidadDeNegocio + " Precio");
				result.Add(unidadDeNegocio + " Margen");
			}
			return result;
		}

		private void sincronizarDetalle(DataTable dataTable, ICollection<Modelo.Precios.ItemCambioDePrecioDeVenta> listadetalle)
		{
			var buscaArticulo = FabricaNegocios._Resolver<IBuscador<Articulo>>();
			buscaArticulo.CargarEntidadesRelacionadas = CargarRelaciones.NoCargarNada;
			foreach (DataRow row in dataTable.Rows)
			{
				var detalle = new Modelo.Precios.ItemCambioDePrecioDeVenta();
				var articuloId = row.Field<int>("Articulo");
				foreach (DataColumn Columna in dataTable.Columns)
				{
					switch(Columna.ColumnName)
					{
						case "Articulo":
							var articulo = buscaArticulo.BuscarPorCodigo<Articulo>((int)row[Columna.ColumnName]);
							detalle.Articulo = articulo;
							if (articulo != null)
								detalle.ArticuloId = articulo.Id;
							else
								detalle.ArticuloId = 0;
							break;
						case "Costo":
							detalle.Costo = (decimal)row[Columna.ColumnName];
							break;
						case "CFU":
							detalle.CFU = (decimal)row[Columna.ColumnName];
							break;
						default:
							mapeaUnidadDeNegocios(Columna,row, detalle);
							break;
					}
				}
				listadetalle.Add(detalle);
			}
		}

		private void mapeaUnidadDeNegocios(DataColumn Columna, DataRow row, ItemCambioDePrecioDeVenta detalle)
		{
			var fila = new SubItemCambioDePrecioDeVenta();
			var name = Columna.ColumnName;
			foreach (var unidadDeNegocio in Enum.GetNames(typeof(Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio)))
			{
				if (name.StartsWith(unidadDeNegocio))
				{
					fila.UnidadDeNegocio = (Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio) Enum.Parse(typeof(Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio),unidadDeNegocio);
					var margen = row.Field<object>(fila.UnidadDeNegocio.ToString() + " Margen");
					if(margen != null)
						fila.Margen = (decimal)margen;
					var precio = row.Field<object>(fila.UnidadDeNegocio.ToString() + " Precio");
					if (precio != null)
						fila.Precio = (decimal)precio;
					detalle.SubItems.Add(fila);
				}
			}
		}

		private void cargaDataTable(DataTable tabla, ICollection<ItemCambioDePrecioDeVenta> items)
		{
			foreach (var item in items)
			{
				var row = tabla.NewRow();
				if (item.Articulo != null)
				{
					row["Descripcion"] = item.Articulo.Nombre;
					row["Articulo"] = item.Articulo.Codigo;
				}
				else
					row["Articulo"] = 0;
				row["Costo"] = item.Costo;
				row["CFU"] = item.CFU;
				foreach (var unidadDeNegocio in item.SubItems)
				{
					row[unidadDeNegocio.UnidadDeNegocio.ToString() + " Precio"] = unidadDeNegocio.Precio;
					row[unidadDeNegocio.UnidadDeNegocio.ToString() + " Margen"] = unidadDeNegocio.Margen;
				}
				tabla.Rows.Add(row);
			}

			if(tabla.Rows != null)
			{
				foreach (DataRow row in tabla.Rows)
				{
					row.AcceptChanges();
				}
			}
		}

		private void SetExpression(DataTable dataTable)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				foreach (var item in Enum.GetNames(typeof(Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio)))
				{
					var margenString = item + " Margen";
					var precioString = item + " Precio";
					//var precio = dataTable.Columns.Cast<DataColumn>().Where(p=>p.ColumnName==precioString).FirstOrDefault();
					var margen = dataTable.Columns.Cast<DataColumn>().Where(p=>p.ColumnName==margenString).FirstOrDefault();
					//precio.Expression = string.Format("(`{0}`/100+1)*Costo", margenString);
					//aca tendria que poner tambien el expression del margen
					//margen.Expression = string.Format("IIF(`{0}`<> 0,((`{0}`-costo)/(`{0}`))*100,0)", precioString); ;
					//margen.Expression = string.Format("((`{0}`-costo)/`{0}`)*100", precioString);
				}
			}
		}
			
		public Modelo.Precios.CambioDePreciosDeVenta DtoToEntidad(Servicios.DTO.Precios.CambioDePreciosDeVenta dto, Modelo.Precios.CambioDePreciosDeVenta entidad)
		{
			entidad.Id = dto.Id;
			entidad.Codigo = dto.Codigo;
			entidad.Nombre = dto.Nombre;
			//si se rompe fijate en este mapeo
			entidad.Estado = (EstadoCambioDePreciosDeVenta) dto.Estado;
			entidad.FechaDesde = dto.FechaDesde;
			entidad.FechaHasta = dto.FechaHasta;
			entidad.Folder = dto.Folder;
			this.sincronizarDetalle(dto.Items,entidad.ItemsCambioDePrecioDeVenta);
			entidad.TipoDeCambio = (TipoCambioDePreciosDeVenta) dto.TipoDeCambio;
			return entidad;
		}

		public Modelo.Precios.CambioDePreciosDeVenta DtoToEntidad(Inteldev.Fixius.Servicios.DTO.Precios.CambioDePreciosDeVenta dto)
		{
			return this.DtoToEntidad(dto,new Inteldev.Fixius.Modelo.Precios.CambioDePreciosDeVenta());
		}

		public Servicios.DTO.Precios.CambioDePreciosDeVenta EntidadToDto(CambioDePreciosDeVenta entidad, Inteldev.Fixius.Servicios.DTO.Precios.CambioDePreciosDeVenta dto)
		{
			dto.Id = entidad.Id;
			dto.Nombre = entidad.Nombre;
			dto.Codigo = entidad.Codigo;
			dto.Estado = (Servicios.DTO.Precios.EstadoCambioDePreciosDeVenta)entidad.Estado;
			dto.FechaDesde = entidad.FechaDesde;
			dto.FechaHasta = entidad.FechaHasta;
			dto.Folder = entidad.Folder;
			dto.Items = CreateDataTable();
			this.cargaDataTable(dto.Items,entidad.ItemsCambioDePrecioDeVenta);
			dto.TipoDeCambio = (Servicios.DTO.Precios.TipoCambioDePreciosDeVenta)entidad.TipoDeCambio;
			this.SetExpression(dto.Items);
			return dto;
		}

		public Servicios.DTO.Precios.CambioDePreciosDeVenta EntidadToDto(CambioDePreciosDeVenta entidad)
		{
			return this.EntidadToDto(entidad, new Servicios.DTO.Precios.CambioDePreciosDeVenta());
		}


		public List<Servicios.DTO.Precios.CambioDePreciosDeVenta> ToListDto(List<CambioDePreciosDeVenta> listaEntidades)
		{
			var result = new List<Servicios.DTO.Precios.CambioDePreciosDeVenta>();
			foreach (var item in listaEntidades)
			{
				result.Add(this.EntidadToDto(item));
			}
			return result;
		}

		public List<CambioDePreciosDeVenta> ToListEntidad(List<Servicios.DTO.Precios.CambioDePreciosDeVenta> listaDto)
		{
			throw new NotImplementedException();
		}


        public List<CambioDePreciosDeVenta> ToListEntidad(object listaDto)
        {
            throw new NotImplementedException();
        }


        public CambioDePreciosDeVenta DtoToEntidad(object dto)
        {
            throw new NotImplementedException();
        }


        public AutoMapper.IMappingEngine MotorDeMapeador()
        {
            return Mapeador.Instancia.Engine;
        }
    }
}
