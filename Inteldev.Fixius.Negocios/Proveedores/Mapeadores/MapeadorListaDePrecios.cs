using Inteldev.Core;
using Inteldev.Core.DataSwitch;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Mapeadores
{
    public class MapeadorListaDePrecios : IMapeadorGenerico<Modelo.Proveedores.ListaDePrecios, Servicios.DTO.Proveedores.ListaDePrecios>
    {
        private string empresa;
        private string entidad;

        public MapeadorListaDePrecios(string empresa, string entidad)
        {
            this.entidad = entidad;
            this.empresa = empresa;
        }

        private DataTable crearDataTable(Modelo.Proveedores.PlantillaListaProveedor plantilla)
        {
            var detalle = new DataTable("Detalle");
            detalle.Columns.Add(new DataColumn("Articulo", typeof(int)));
            detalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            foreach (var columna in plantilla.Columnas)
            {
                detalle.Columns.Add(new DataColumn(columna.Nombre, typeof(decimal)));
            }
            detalle.Columns.Add(new DataColumn("Id", typeof(int)));
            return detalle;
        }

        private Modelo.Proveedores.PlantillaListaProveedor cargarPlantilla(int idProveedor)
        {
            //aca de donde saco empresa??
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            var buscadorPlantilla = (IBuscador<Modelo.Proveedores.PlantillaListaProveedor>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Proveedores.PlantillaListaProveedor>), parameters);
            buscadorPlantilla.CargarEntidadesRelacionadas = CargarRelaciones.CargarTodo;
            var plantilla = buscadorPlantilla.BuscarLista(
				pl => pl.Proveedores.FirstOrDefault(pr => pr.Id == idProveedor) != null,buscadorPlantilla.CargarEntidadesRelacionadas).FirstOrDefault();
            return plantilla;
        }

        private void sincronizarDetalle(DataTable dataTable, ICollection<Modelo.Proveedores.ListaDePreciosDetalle> listadetalle)
        {
			var tipo = typeof(Modelo.Proveedores.ListaDePreciosDetalle);
			Predicate<string> existe = (nomprop => tipo.GetProperty(nomprop) != null);
			Action<string, object, object> set = ((nomprop, objeto, valor) => tipo.GetProperty(nomprop).SetValue(objeto, valor));
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            var buscaArticulo = (IBuscador<Articulo>) FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Articulo>),parameters);
            buscaArticulo.CargarEntidadesRelacionadas = CargarRelaciones.NoCargarNada;
            parameters[1] = new ParameterOverride("entidad", "ListaDePreciosDetalle");
            var buscaDetalleLista = (BuscadorListaDePreciosDetalle<ListaDePreciosDetalle>)FabricaNegocios.Instancia.Resolver(typeof(BuscadorListaDePreciosDetalle<ListaDePreciosDetalle>), parameters);
			foreach (DataRow row in dataTable.Rows)
			{
				if (row.RowState != DataRowState.Unchanged)
				{
					var detalle = new Modelo.Proveedores.ListaDePreciosDetalle();
					var articuloId = row.Field<int>("Articulo");
					var columnas = buscaDetalleLista.obtenerColumnasArticulo(articuloId);
					foreach (DataColumn Columna in dataTable.Columns)
					{
						if (Columna.ColumnName != "Descripcion")
						{
							if (existe(Columna.ColumnName))
							{
								if (Columna.ColumnName == "Articulo")
								{
									detalle.Articulo = new Articulo();
									detalle.Articulo.Id = (int)row["Articulo"];
								}
								else
								{
									set(Columna.ColumnName, detalle, row[Columna]);
								}
							}
							else
							{
								var detallecolumna = new Modelo.Proveedores.ListaDePreciosColumna();
								detallecolumna.Nombre = Columna.ColumnName;
								if (columnas != null)
									detallecolumna.Id = columnas.FirstOrDefault(p => p.Nombre == Columna.ColumnName).Id;
								detallecolumna.Valor = (Decimal)row[Columna];
								detalle.Columnas.Add(detallecolumna);
							}
						}
					}
					listadetalle.Add(detalle);
				}
			}
        }

        private void cargarDataTable(DataTable tabla, Modelo.Proveedores.ListaDePrecios lista)
        {
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            var db = (Inteldev.Core.DataSwitch.IDataSwitch<Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios>)FabricaNegocios.Instancia.Resolver(typeof(IDataSwitch<Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios>),parameters);
			var buscadorDetalle = FabricaNegocios._Resolver<IBuscadorListaDePreciosDetalle<ListaDePreciosDetalle>>();
            var articulos = db.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == lista.Proveedor.Id)
                            .Select(art => new { art.Id, art.Nombre }).ToList();


			var resultado = from a in articulos
							join l in lista.Detalle on a.Id equals l.Articulo.Id into aa
							from bb in aa.DefaultIfEmpty(new Modelo.Proveedores.ListaDePreciosDetalle())
							select new
							{
								bb.Id,
								Articulo = a.Id,
								Descripcion = a.Nombre,
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
						object valor;
						if (prop == null)
						{
							if (item.Columnas.Any())
								valor = item.Columnas.Where(c => c.Nombre == columna.ColumnName).FirstOrDefault().Valor;
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
        

        public Modelo.Proveedores.ListaDePrecios DtoToEntidad(Servicios.DTO.Proveedores.ListaDePrecios dto, Modelo.Proveedores.ListaDePrecios entidad)
        {

            entidad.Id = dto.Id;
            entidad.Nombre = dto.Nombre;
            entidad.Vigencia = dto.Vigencia;
            //entidad.Proveedor = Mapeador.Instancia.DtoToEntidad<Servicios.DTO.Proveedores.Proveedor, Modelo.Proveedores.Proveedor>(dto.Proveedor);
			entidad.Proveedor = new Inteldev.Fixius.Modelo.Proveedores.Proveedor();
			entidad.Proveedor.Id = dto.Proveedor.Id;
			entidad.Proveedor.Codigo = dto.Proveedor.Codigo;
            entidad.Observaciones = Mapeador.Instancia.ListaToEntidad<Servicios.DTO.Proveedores.ObservacionProveedor,
                                                              Modelo.Proveedores.ObservacionProveedor>(dto.Observaciones);
            
            this.sincronizarDetalle(dto.Detalle, entidad.Detalle);
            return entidad;
        }
                
        public Modelo.Proveedores.ListaDePrecios DtoToEntidad(Servicios.DTO.Proveedores.ListaDePrecios dto)
        {
            return this.DtoToEntidad(dto, new Modelo.Proveedores.ListaDePrecios());
        }

        public Servicios.DTO.Proveedores.ListaDePrecios EntidadToDto(Modelo.Proveedores.ListaDePrecios entidad, Servicios.DTO.Proveedores.ListaDePrecios dto)
        {
            //necesito empresa
            var plantilla = this.cargarPlantilla(entidad.Proveedor.Id);

            dto.Id = entidad.Id;
            dto.Nombre = entidad.Nombre;
            dto.Vigencia = entidad.Vigencia;
            dto.Proveedor = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>(entidad.Proveedor);
            dto.Observaciones = Mapeador.Instancia.ListaToDto<Servicios.DTO.Proveedores.ObservacionProveedor,
                                                              Modelo.Proveedores.ObservacionProveedor>(entidad.Observaciones.ToList());

            if (plantilla != null)
            {
                dto.Columnas = Mapeador.Instancia.EntidadToDto<Modelo.Proveedores.PlantillaListaProveedor, Servicios.DTO.Proveedores.PlantillaListaProveedor>(plantilla).Columnas;
                dto.Detalle = this.crearDataTable(plantilla);
                this.cargarDataTable(dto.Detalle, entidad);
            }
            if (dto.Id != 0)
            {
                foreach (DataRow row in dto.Detalle.Rows)
                {
                    var neto = (decimal)row["Neto"];
                    if (neto != 0)
                        row.SetModified();
                }
            }
            return dto;
        }


       

        public Servicios.DTO.Proveedores.ListaDePrecios EntidadToDto(Modelo.Proveedores.ListaDePrecios entidad)
        {
			var listaDto = new Servicios.DTO.Proveedores.ListaDePrecios();
            return this.EntidadToDto(entidad, listaDto);
        }

        public List<Servicios.DTO.Proveedores.ListaDePrecios> ToListDto(List<Modelo.Proveedores.ListaDePrecios> listaEntidades)
        {
            var listadto = new List<Servicios.DTO.Proveedores.ListaDePrecios>();
            listaEntidades.ForEach(l=> listadto.Add(new Servicios.DTO.Proveedores.ListaDePrecios(){ Id=l.Id, Nombre=l.Nombre}));
            return listadto;
        }

        public List<Modelo.Proveedores.ListaDePrecios> ToListEntidad(List<Servicios.DTO.Proveedores.ListaDePrecios> listaDto)
        {
            throw new NotImplementedException();
        }


        public List<ListaDePrecios> ToListEntidad(object listaDto)
        {
            throw new NotImplementedException();
        }


        public ListaDePrecios DtoToEntidad(object dto)
        {
            throw new NotImplementedException();
        }


        public AutoMapper.IMappingEngine MotorDeMapeador()
        {
            return Mapeador.Instancia.Engine;
        }
    }
}
