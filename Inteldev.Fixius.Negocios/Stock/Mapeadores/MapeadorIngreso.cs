using Inteldev.Core;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock.Mapeadores
{
	public class MapeadorIngreso : MapeadorDataTable<Modelo.Stock.Ingreso,Servicios.DTO.Stock.Ingreso>
	{

        public MapeadorIngreso(string empresa)
            :base(empresa)
        {
            this.columnasDataTable.Add("Descripcion", typeof(string));
            this.columnasDataTable.Add("Articulo", typeof(string));
            this.columnasDataTable.Add("Bultos", typeof(int));
            this.columnasDataTable.Add("Orden De Compra", typeof(string));
        }

        protected override void sincronizarDetalle(DataTable dataTable, PropertyInfo propiedadEntidad, object entidad)
        {
            var listadetalle = (propiedadEntidad.GetValue(entidad) as IEnumerable<object>).Cast<Modelo.Stock.ItemIngreso>().ToList();
            var buscaArticulo = FabricaNegocios._Resolver<IBuscador<Articulo>>();
            buscaArticulo.CargarEntidadesRelacionadas = CargarRelaciones.NoCargarNada;
            var buscaOrdenDeCompra = FabricaNegocios._Resolver<IBuscador<OrdenDeCompra>>();
            foreach (DataRow row in dataTable.Rows)
            {
                var detalle = new Modelo.Stock.ItemIngreso();
                var articuloCod = row.Field<string>("Articulo");
                foreach (DataColumn Columna in dataTable.Columns)
                {
                    switch (Columna.ColumnName)
                    {
                        case "Articulo":
                            var articulo = buscaArticulo.BuscarPorCodigo<Articulo>((string)row[Columna.ColumnName]);
                            detalle.Articulo = articulo;
                            if (articulo != null)
                                detalle.ArticuloId = articulo.Id;
                            else
                                detalle.ArticuloId = 0;
                            break;
                        case "Bultos":
                            detalle.Bultos = (int)row[Columna.ColumnName];
                            break;
                        case "Orden De Compra":
                            var ordenDeCompra = buscaOrdenDeCompra.BuscarPorCodigo<OrdenDeCompra>((string)row[Columna.ColumnName]);
                            detalle.OrdenDeCompra = ordenDeCompra;
                            detalle.OrdenDeCompraId = ordenDeCompra.Id;
                            break;
                    }
                }
                listadetalle.Add(detalle);
            }
            propiedadEntidad.SetValue(entidad,listadetalle);
        }

        protected override void cargarDataTable(DataTable tabla, ICollection<EntidadBase> items)
        {
            foreach (ItemIngreso item in items)
            {
                var row = tabla.NewRow();
                if (item.Articulo != null)
                {
                    if(item.OrdenDeCompra != null)
                        row["Orden De Compra"] = item.OrdenDeCompra.Codigo;
                    row["Descripcion"] = item.Articulo.Nombre;
                    row["Articulo"] = item.Articulo.Codigo;
                }
                else
                    row["Articulo"] = 0;
                row["Bultos"] = item.Bultos;
                tabla.Rows.Add(row);
            }

            if (tabla.Rows != null)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    row.AcceptChanges();
                }
            }
        }
    }
}
