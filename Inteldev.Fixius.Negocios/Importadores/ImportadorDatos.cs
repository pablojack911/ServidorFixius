using System;
using System.Collections.Generic;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Microsoft.Practices.Unity;
using Inteldev.Core.DTO.Carriers;
using System.Data;
using System.Data.SqlClient;
using Inteldev.Fixius.Modelo.Fiscal;
using System.Collections.ObjectModel;
using System.Linq;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class ImportadorDatos
    {
        public ObservableCollection<Mapeador> Mapeadores { get; set; }

        public ImportadorDatos(RegistroMapeadores registro)
        {
            this.Mapeadores = registro.Mapeadores;
        }

        public void Procesar()
        {

            foreach (var mapeador in this.Mapeadores.Where(m => m.Seleccionado == true))
            {
                //LogManager.Instancia.AgregarMensaje(string.Format("Procesando {0}", mapeador.Objeto.GetType().ToString()));
                dynamic objeto = mapeador.Objeto;
                var listaEntidad = objeto.Procesar();

                if (listaEntidad is IDataReader)
                    this.BulkInsert(listaEntidad, mapeador);
                else
                    this.EntityInsert(listaEntidad, mapeador);



                //}
            }
        }

        private void EntityInsert(dynamic listaEntidad, dynamic mapeador)
        {
            var listaLote = Activator.CreateInstance(listaEntidad.GetType());

            int i = 0;
            var listaCodigos = new List<string[]>(); //utilizado para el borrar. Agregamos todos los codigos que llegan desde fox para compararlos con los que hay en la base local.
            LogManager.Instancia.AgregarMensaje("Comenzando a grabar.");//logger imprimir cantidad de grabados
            foreach (var item in listaEntidad)
            {
                listaCodigos.Add(mapeador.Objeto.ObtenerFiltroBorrador(item)); //agregamos el codigo a la lista de codigos.
                listaLote.Add(item);
                if (listaLote.Count == mapeador.Objeto.ItemsPorLote)
                {
                    i += listaLote.Count;
                    this.Grabar(listaLote, mapeador.Objeto.paramers);
                    //LogManager.Instancia.AgregarMensaje(string.Format("Total agregados de una: {0}", i));//logger imprimir cantidad de grabados
                    listaLote.Clear();
                }
            }
            if (listaLote.Count > 0)
            {
                i += listaLote.Count;
                this.Grabar(listaLote, mapeador.Objeto.paramers);
                //LogManager.Instancia.AgregarMensaje(string.Format("Total agregados de una: {0}", i));
            }
            //this.Grabar(listaEntidad, mapeador.Objeto.paramers);
            LogManager.Instancia.AgregarMensaje(string.Format("Preparandose para borrar los que ya no están en FOX."));
            this.Borrar(listaEntidad, mapeador.Objeto.paramers, mapeador, listaCodigos);
        }

        private void BulkInsert(dynamic listaEntidad, dynamic mapeador)
        {
            // OleDbConnection con = new OleDbConnection("Provider=VFPOLEDB.1 ;Data Source=S:\\Appvfp\\Hergo_release\\Datos\\truesoft.dbc");
            LogManager.Instancia.AgregarMensaje("Limpiando tabla PadronIIBB");
            var borrador = FabricaNegocios.Instancia.Resolver(typeof(IBorrador<PadronIIBB>), mapeador.Objeto.paramers);
            borrador.BorrarTodo();
            var dr = (IDataReader)listaEntidad;

            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(@"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico;Integrated Security=SSPI");
            LogManager.Instancia.AgregarMensaje("Total leído: " + listaEntidad.RecordsAffected);
            LogManager.Instancia.AgregarMensaje("Comenzando el mapeo.");
            // Copying data to destination
            sbc.DestinationTableName = mapeador.Objeto.TablaDestino;
            sbc.ColumnMappings.Clear();
            foreach (var item in mapeador.Objeto.mapeo())
            {
                sbc.ColumnMappings.Add(item[0], item[1]);
            }
            LogManager.Instancia.AgregarMensaje("Preparandose para grabar.");
            sbc.BulkCopyTimeout = 0;
            sbc.WriteToServer(dr);
            LogManager.Instancia.AgregarMensaje("Grabación finalizada.");
            dr.Close();
            dr.Dispose();
        }

        private void Borrar(dynamic listaEntidad, ParameterOverride[] parameters, dynamic mapeador, List<string[]> listaCodigos)
        {
            if (listaEntidad.Count > 0)
            {
                var tipobuscador = typeof(IBuscador<>);
                var tipoBuscadorGenerico = tipobuscador.MakeGenericType(listaEntidad[0].GetType());
                var buscador = FabricaNegocios.Instancia.Resolver(tipoBuscadorGenerico, parameters);


                var tipoborrador = typeof(IBorrador<>);
                var tipoBorradorGenerico = tipoborrador.MakeGenericType(listaEntidad[0].GetType());
                var borrador = FabricaNegocios.Instancia.Resolver(tipoBorradorGenerico, parameters);
                LogManager.Instancia.AgregarMensaje("Creando lista local para eliminar los registros que no están más en FOX.");

                Type buscaType = buscador.GetType();
                Type tipoEntidad = listaEntidad[0].GetType();
                object[] parames = { listaCodigos };
                var lista = buscaType.GetMethod("BuscarDiferencia").MakeGenericMethod(tipoEntidad).Invoke(buscador, parames);

                foreach (EntidadMaestro item in lista)
                {
                    if (mapeador.Objeto.CompararParaBorrar(item))
                    {
                        LogManager.Instancia.AgregarMensaje(string.Format("Borrando de SQL SERVER: {0}. {1}", item.Codigo, item.Nombre));
                        ErrorCarrier carrier = borrador.Borrar(item.Id, new Usuario() { Nombre = "Importador Fox" }); //auditoria?
                        LogManager.Instancia.AgregarMensaje(string.Format("Información de borrado: {0}", carrier.mensaje));
                    }
                }
            }
        }

        private void Grabar(dynamic listaEntidad, ParameterOverride[] parameters)
        {
            if (listaEntidad.Count > 0)
            {
                var tipograbador = typeof(IGrabador<>);
                var tipoGrabadorGenerico = tipograbador.MakeGenericType(listaEntidad[0].GetType());

                LogManager.Instancia.AgregarMensaje(string.Format("Creado el Grabador de la entidad {0}", listaEntidad[0].GetType().ToString()));
                dynamic grabador = FabricaNegocios.Instancia.Resolver(tipoGrabadorGenerico, parameters);
                var grabadorCarrier = grabador.GrabarListaImportador(listaEntidad);
                LogManager.Instancia.AgregarMensaje(string.Format("{0}", ((grabadorCarrier.getError() == true) ? "¡Error!" : "Correcto.")));
                LogManager.Instancia.AgregarMensaje(string.Format("Mensaje: {0}", grabadorCarrier.getMensaje()));
                grabador = null;
                grabadorCarrier = null;
            }
        }
    }
}
