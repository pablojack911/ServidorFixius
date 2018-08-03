using Inteldev.Core;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Mapeadores
{
	public class MapeadorDevolucionDeMercaderia : MapeadorDataTable<Modelo.Proveedores.DevolucionDeMercaderia,Servicios.DTO.Proveedores.DevolucionDeMercaderia>
	{
		public MapeadorDevolucionDeMercaderia()
		{
            this.columnasDataTable.Add("Articulo",typeof(string));
            this.columnasDataTable.Add("Cantidad",typeof(int));
            this.columnasDataTable.Add("Costo",typeof(decimal));
		}
		
        protected override void sincronizarDetalle(DataTable dataTable, PropertyInfo propiedadEntidad, object entidad)
        {
            var listadetalle = (propiedadEntidad.GetValue(entidad) as IEnumerable<object>).Cast<Modelo.Proveedores.DetalleDevolucionMercaderia>().ToList();
			var buscaArticulo = FabricaNegocios._Resolver<IBuscador<Modelo.Articulos.Articulo>>();
			buscaArticulo.CargarEntidadesRelacionadas = CargarRelaciones.NoCargarNada;
			foreach (DataRow row in dataTable.Rows)
			{
				if (row.RowState != DataRowState.Unchanged)
				{
					var detalle = new Modelo.Proveedores.DetalleDevolucionMercaderia();
					var articuloCod = row.Field<string>("Articulo");
					detalle.Articulo = buscaArticulo.BuscarPorCodigo<Modelo.Articulos.Articulo>(articuloCod);
					detalle.Cantidad = row.Field<int>("Cantidad");
					detalle.Costo = row.Field<decimal>("Costo");
					listadetalle.Add(detalle);
				}
			}
            propiedadEntidad.SetValue(entidad,listadetalle);
        }

        protected override void cargarDataTable(DataTable tabla, ICollection<EntidadBase> items)
        {
            foreach (DetalleDevolucionMercaderia item in items)
            {
                DataRow row = tabla.NewRow();
                row.SetField<string>("Articulo", item.Articulo.Codigo);
                row.SetField<int>("Cantidad", item.Cantidad);
                row.SetField<decimal>("Costo", item.Costo);
                tabla.Rows.Add(row);
            }
            foreach (DataRow item in tabla.Rows)
            {
                item.AcceptChanges();
            }
        }
	}
}
