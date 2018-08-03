using Inteldev.Core.Contratos;
using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Presentacion.ClienteServicios;
using Inteldev.Core.Presentacion.Comandos;
using Inteldev.Core.Presentacion.Controladores;
using Inteldev.Core.Presentacion.Controles;
using Inteldev.Core.Presentacion.Presentadores;
using Inteldev.Core.Presentacion.Presentadores.Interfaces;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Servidor2
{
    public class PresentadorGrillaServidor<TEntidad, TDto, TVista> : DependencyObject
        where TEntidad : Inteldev.Core.Modelo.EntidadMaestro
        where TDto : DTOMaestro, new()
        where TVista : FrameworkElement, new()
    {

        /// <summary>
        /// Propiedad que bindea con el datagrid, el cual se actualiza automaticamente cuando cambia esta colleccion.
        /// </summary>
        public ObservableCollection<TDto> Detalle
        {
            get { return (ObservableCollection<TDto>)GetValue(DetalleProperty); }
            set { SetValue(DetalleProperty, value); }
        }

        public static readonly DependencyProperty DetalleProperty = DependencyProperty.Register("Detalle", typeof(ObservableCollection<TDto>), typeof(PresentadorGrillaServidor<TEntidad, TDto, TVista>));

        public TDto ItemSeleccionado
        {
            get { return (TDto)GetValue(ItemSeleccionadoProperty); }
            set { SetValue(ItemSeleccionadoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemDetalleActual.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSeleccionadoProperty =
            DependencyProperty.Register("ItemSeleccionado", typeof(TDto), typeof(PresentadorGrillaServidor<TEntidad, TDto, TVista>));

        public TDto Objeto
        {
            get { return (TDto)GetValue(ObjetoProperty); }
            set { SetValue(ObjetoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Objeto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjetoProperty =
            DependencyProperty.Register("Objeto", typeof(TDto), typeof(PresentadorGrillaServidor<TEntidad, TDto, TVista>));

        #region Comandos

        public ICommand CmdAgregar { get; set; }
        public ICommand CmdEditar { get; set; }
        public ICommand CmdBorrar { get; set; }
        public ICommand CmdAceptar { get; set; }
        public ICommand CmdCancelar { get; set; }

        #endregion

        #region Implementacion Comandos

        protected bool modoEdicion;

        public virtual bool AgregarItem()
        {
            this.modoEdicion = false;
            this.Inicializar();
            CrearVentana();
            //Detalle.Add(this.Objeto);
            return true;
        }

        public virtual bool Editar()
        {
            this.modoEdicion = true;
            this.Objeto = this.ItemSeleccionado;
            if (Objeto != null)
            {
                CrearVentana();
            }
            return true;
        }

        public virtual bool Aceptar()
        {
            if (!this.modoEdicion)
            {
                //aca tengo que agarrar e insertar la configuracion en la base.
                var result = this.servicio.Grabar(this.Objeto, new Usuario() { Nombre = "ADMIN" }, "");
                this.Objeto.Id = result.getId();
                this.Detalle.Add(this.Objeto);
            }
            CerrarVentana();
            //this.Inicializar();
            return true;
        }

        public virtual bool Cancelar()
        {
            CerrarVentana();
            if (this.Objeto != null)
            {
                //if (this.Objeto.Nombre == null || this.Objeto.Nombre == System.String.Empty)
                //{
                //    this.ItemSeleccionado = Objeto;
                //    this.BorrarItem();
                //}

                if (this.Objeto.Id == 0 && !this.modoEdicion)//agregando
                {
                    this.ItemSeleccionado = Objeto;
                    this.BorrarItem();
                }

                this.Inicializar();
            }
            return true;
        }

        private object BorrarItem()
        {
            if (ItemSeleccionado != null)
            {
                ErrorCarrier result = new ErrorCarrier();
                if (this.Objeto.Id != 0)
                    result = this.servicio.Borrar(this.ItemSeleccionado, new Usuario() { Nombre = "ADMIN" }, "");
                if (result.borroOk)
                    this.Detalle.Remove(this.ItemSeleccionado);
            }
            return true;
        }

        #endregion

        #region  Campos

        protected BaseVentanaDialogo ventana;

        #endregion

        public Type VistaModeloDetalleType { get; set; }
        public object VistaModeloDetalleInstancia { get; set; }

        public void CrearVentana()
        {
            this.ventana = new BaseVentanaDialogo();
            ventana.VistaPrincipal.Content = Activator.CreateInstance<TVista>();
            ventana.DataContext = this;
            if (this.VistaModeloDetalleType != null)
            {
                this.VistaModeloDetalleInstancia = Activator.CreateInstance(this.VistaModeloDetalleType, (this.ItemSeleccionado == null ? this.Objeto : this.ItemSeleccionado));
                ventana.VistaPrincipal.DataContext = this.VistaModeloDetalleInstancia; //asigna datacontext como este presentador.
            }
            ventana.ShowDialog();
            var dpCollecction = this.Detalle;
            this.Detalle = null;
            this.Detalle = dpCollecction;
        }

        public void CerrarVentana()
        {
            this.ventana.Close();
        }

        private IServicioABM<TDto> servicio;
        private IMapeadorGenerico<TEntidad, TDto> mapeador;


        public PresentadorGrillaServidor()
        {
            this.CmdAgregar = new RelayCommand(p => this.AgregarItem());
            this.CmdEditar = new RelayCommand(p => this.Editar(), q => this.PuedeEditar());
            this.CmdBorrar = new RelayCommand(p => this.BorrarItem(), q => this.PuedeEliminar());
            this.CmdAceptar = new RelayCommand(p => this.Aceptar());
            this.CmdCancelar = new RelayCommand(p => this.Cancelar());
            //tengo que instanciar al servicio aca de alguna forma.
            this.servicio = new ServicioABM<TDto, TEntidad>();
            this.mapeador = FabricaNegocios._Resolver<IMapeadorGenerico<TEntidad, TDto>>();
            var dett = this.servicio.ObtenerLista(1, Inteldev.Core.CargarRelaciones.NoCargarNada, "");
            this.Detalle = new ObservableCollection<TDto>();
            foreach (var item in dett)
            {
                this.Detalle.Add(item);
            }
            this.Objeto = this.Detalle.FirstOrDefault();
        }

        public virtual bool PuedeEliminar()
        {
            return true;
        }

        public virtual bool PuedeEditar()
        {
            return false;
        }

        public void Inicializar()
        {
            this.Objeto = Activator.CreateInstance<TDto>();
            this.ItemSeleccionado = null;
            //if (ventana != null)
            //	CerrarVentana();	
        }

    }
}
