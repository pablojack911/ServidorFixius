using Inteldev.Core.Modelo;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Mapeadores
{
    public class MapeadorOrdenDePagoDataTable : MapeadorDataTable<Modelo.Proveedores.OrdenDePago,Servicios.DTO.Proveedores.OrdenDePago> , IMapeadorOrdenDePago
    {
        public MapeadorOrdenDePagoDataTable()
        {
            this.columnasDataTable = new Dictionary<string, Type>();
            this.columnasDataTable.Add("Fecha", typeof(DateTime));
            this.columnasDataTable.Add("Tipo", typeof(string));
            this.columnasDataTable.Add("Prenumero", typeof(int));
            this.columnasDataTable.Add("Numero", typeof(int));
            this.columnasDataTable.Add("Importe", typeof(decimal));
            this.columnasDataTable.Add("Pendiente", typeof(decimal));
            this.columnasDataTable.Add("Aplicado", typeof(decimal));
            this.columnasDataTable.Add("Saldo", typeof(decimal));
            this.listasDetalle.Add("Aplicaciones");
        }

        public void CargaDocumentoCompra(System.Data.DataTable tabla, dynamic items)
        {
            foreach (Modelo.Proveedores.DocumentoCompra item in items)
            {
                DataRow row = tabla.NewRow();
                row.SetField<DateTime>("Fecha", item.Fecha);
                row.SetField<Modelo.Proveedores.TipoDocumento>("Tipo", item.TipoDocumento);
                row.SetField<string>("Prenumero", item.Prenumero);
                row.SetField<string>("Numero", item.Numero);
                if (item.Aplicado == 0)
                {
                    row.SetField<decimal>("Pendiente", item.Importe);
                }
                else
                {
                    row.SetField<decimal>("Pendiente", item.Importe - item.Aplicado);
                }
                row.SetField<decimal>("Importe", item.Importe);
                row.SetField<decimal>("Aplicado", item.Aplicado);
                tabla.Rows.Add(row);
            }

            foreach (DataRow item in tabla.Rows)
            {
                item.AcceptChanges();
            }
        }

        public void CargaOrdenesDePago(System.Data.DataTable tabla, dynamic items)
        {
            foreach (Modelo.Proveedores.OrdenDePago item in items)
            {
                DataRow row = tabla.NewRow();
                row.SetField<DateTime>("Fecha", item.Fecha);
                row.SetField<TipoDocumento>("Tipo", TipoDocumento.OrdenDePago);
                row.SetField<string>("Prenumero", item.Prenumero);
                row.SetField<string>("Numero", item.Numero);
                if (item.Aplicado == 0)
                {
                    row.SetField<decimal>("Pendiente", item.Importe);
                }
                else
                {
                    row.SetField<decimal>("Pendiente", item.Importe - item.Aplicado);
                }
                row.SetField<decimal>("Importe", (item.Importe) * -1);
                row.SetField<decimal>("Aplicado", (item.Aplicado) * -1);
                tabla.Rows.Add(row);
            }

            foreach (DataRow item in tabla.Rows)
            {
                item.AcceptChanges();
            }
        }

        protected override void cargarDataTable(System.Data.DataTable tabla, ICollection<Core.Modelo.EntidadBase> items)
        {
            //aca me tira que no puede con la colleccion de aplicados.
            var resultDocumentoCompra = new List<Modelo.Proveedores.DocumentoCompra>();
            var resultOrdenDePago = new List<Modelo.Proveedores.OrdenDePago>();
            //ESTO SI QUE SI LO HACEN EN CASA LES VA A IR MAL
            foreach (Modelo.Proveedores.Aplicacion item in items)
            {
                resultDocumentoCompra.Add(item.DocumentoCompra);;
                resultOrdenDePago.Add(item.OrdenDePago);
            }

            this.CargaDocumentoCompra(tabla, resultDocumentoCompra);
            this.CargaOrdenesDePago(tabla, resultOrdenDePago);


            //poner columna de orden de pago que estoy haciendo ahora.
            var ultimaOrdenDePago = tabla.NewRow();
            ultimaOrdenDePago.SetField<DateTime>("Fecha", DateTime.Now);
            ultimaOrdenDePago.SetField<TipoDocumento>("Tipo", TipoDocumento.OrdenDePago);
            ultimaOrdenDePago.SetField<int>("Prenumero", 0);
            ultimaOrdenDePago.SetField<int>("Numero", 0);
            tabla.Rows.Add(ultimaOrdenDePago);

            foreach (DataRow item in tabla.Rows)
            {
                item.AcceptChanges();
            }

            //aca tengo que poner la expression para las columnas
            foreach (DataColumn columna in tabla.Columns)
            {
                switch (columna.ColumnName)
                {
                    case "Saldo":
                        columna.Expression = string.Format("Pendiente-Aplicado");
                        break;
                    //case "Aplicado":
                    //    columna.Expression = string.Format("IIF(AplicadoRespaldo>Pendiente,0,AplicadoRespaldo)");
                    //    break;
                    default:
                        break;
                }
            }

        }

        protected override void sincronizarDetalle(DataTable dataTable, PropertyInfo propiedadEntidad, object entidad)
        {
            var listadetalle = (propiedadEntidad.GetValue(entidad) as IEnumerable<object>).Cast<Modelo.Proveedores.Aplicacion>().ToList();
            foreach (Modelo.Proveedores.Aplicacion item in listadetalle)
            {
                listadetalle.Add(item);
            }
            Modelo.Proveedores.Aplicacion aplicacion = null;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState != DataRowState.Unchanged)
                {
                    aplicacion = new Modelo.Proveedores.Aplicacion();
                    //aca tengo que poner el detalle en aplicaciones y en esas cosas
                    var tipo = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), row.Field<String>("Tipo"));
                    switch (tipo)
                    {
                        case TipoDocumento.Factura:
                            var detalle = new Modelo.Proveedores.DocumentoCompra();
                            detalle.Importe = row.Field<decimal>("Importe");
                            detalle.Aplicado = row.Field<decimal>("Aplicado");
                            detalle.Fecha = row.Field<DateTime>("Fecha");
                            detalle.Prenumero = row.Field<string>("Prenumero");
                            detalle.Numero = row.Field<string>("Numero");
                            aplicacion.DocumentoCompra = detalle;
                            listadetalle.Add(aplicacion);
                            break;
                        case TipoDocumento.NotaDeCredito:
                            break;
                        case TipoDocumento.NotaDeDebito: 
                            break;
                        case TipoDocumento.OrdenDePago:
                            if (row.Field<int>("Numero") != 0)
                            {
                                var detalleOrdenDePago = new Modelo.Proveedores.OrdenDePago();
                                detalleOrdenDePago.Importe = row.Field<decimal>("Importe") * -1;
                                detalleOrdenDePago.Aplicado = row.Field<decimal>("Aplicado") * -1;
                                aplicacion.OrdenDePago = detalleOrdenDePago;
                                listadetalle.Add(aplicacion);
                            }
                            break;
                        default:
                            break;
                    }
                }
                //aca tengo que setear de alguna forma la lista. Pero, como me afecta esto?
            }
            propiedadEntidad.SetValue(entidad,listadetalle);
        }

        public Modelo.Proveedores.OrdenDePago DtoToEntidad(object dto)
        {
            var valor = (Servicios.DTO.Proveedores.OrdenDePago)dto;
            return this.DtoToEntidad(valor);
        }

    }
}
