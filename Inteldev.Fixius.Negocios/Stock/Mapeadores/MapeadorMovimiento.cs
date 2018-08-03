using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
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
	public class MapeadorMovimiento : MapeadorDataTable<Modelo.Stock.Movimiento,Servicios.DTO.Stock.Movimiento>
	{

		public MapeadorMovimiento()
		{
            this.columnasDataTable.Add("Articulo", typeof(string));
            this.columnasDataTable.Add("Cantidad",typeof(int));
		}

        protected override void sincronizarDetalle(DataTable dataTable, PropertyInfo propiedadEntidad, object entidad)
        {
            var listadetalle = (propiedadEntidad.GetValue(entidad) as IEnumerable<object>).Cast<DetalleMovimiento>().ToList();
            var buscaArticulo = FabricaNegocios._Resolver<IBuscador<Articulo>>();
            foreach (DataRow row in dataTable.Rows)
            {
                var detalle = new DetalleMovimiento();
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
                        case "Cantidad":
                            detalle.Cantidad = (int)row[Columna.ColumnName];
                            break;
                    }
                }
                listadetalle.Add(detalle);
            }
            propiedadEntidad.SetValue(entidad,listadetalle);
        }

        protected override void cargarDataTable(DataTable tabla, ICollection<Core.Modelo.EntidadBase> items)
        {
            foreach (DetalleMovimiento item in items)
            {
                var row = tabla.NewRow();
                if (item.Articulo != null)
                {
                    row["Articulo"] = item.Articulo.Codigo;
                }
                else
                    row["Articulo"] = 0;
                row["Cantidad"] = item.Cantidad;
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
