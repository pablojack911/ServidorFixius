using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Presentacion;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Servidor2
{
    public class PresentadorEmpresaContexto : DependencyObject
    {
        private IServicioABM<Inteldev.Core.DTO.Organizacion.Empresa> servicioEmpresa;
        private IServicioABM<Inteldev.Fixius.Servicios.DTO.ConfiguraEmpresa> servicioConfiguraEmpresa;
        private IServicioABM<Inteldev.Fixius.Servicios.DTO.Contexto> servicioContexto;

        public PresentadorEmpresaContexto()
        {
            this.servicioConfiguraEmpresa = new ServicioABM<Inteldev.Fixius.Servicios.DTO.ConfiguraEmpresa, Inteldev.Fixius.Modelo.ConfiguraEmpresa>();
            this.servicioEmpresa = new ServicioABM<Inteldev.Core.DTO.Organizacion.Empresa, Inteldev.Core.Modelo.Organizacion.Empresa>();
            this.servicioContexto = new ServicioABM<Inteldev.Fixius.Servicios.DTO.Contexto, Inteldev.Fixius.Modelo.Contexto>();
            this.Items = new ObservableCollection<ConfiguraEmpresa>();
            var configuraciones = this.servicioConfiguraEmpresa.ObtenerLista(1, Inteldev.Core.CargarRelaciones.CargarEntidades, "");
            foreach (var item in configuraciones)
            {
                this.Items.Add(item);
            }
            var empresas = this.servicioEmpresa.ObtenerLista(1, Inteldev.Core.CargarRelaciones.CargarEntidades, "");
            foreach (var item in empresas)
            {
                if (this.Items.FirstOrDefault(p => p.Empresa.Id == item.Id) == null)
                    this.Items.Add(new ConfiguraEmpresa() { Empresa = item, Contexto = new Contexto() });
            }
            var contextos = this.servicioContexto.ObtenerLista(1, Inteldev.Core.CargarRelaciones.CargarEntidades, "");
            this.Contextos = new ObservableCollection<Contexto>();



            foreach (var item in contextos)
            {
                this.Contextos.Add(item);
            }
            foreach (var item in this.Items)
            {
                item.PropertyChanged += item_PropertyChanged;
            }
            //this.Items.CollectionChanged += Items_CollectionChanged;
        }

        //void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
        //    {
        //        var index = e.NewStartingIndex + 1;
        //        var oldItems = e.OldItems.Cast<ConfiguraEmpresa>();
        //        var item = oldItems.ElementAt(index);
        //        var result = this.servicioConfiguraEmpresa.Borrar(item, new Usuario() { Nombre = "Admin" }, "");
        //    }
        //}








        void item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var configuraEmpresa = (ConfiguraEmpresa)sender;
            var usuario = new Usuario() { Nombre = "ADMIN" };
            if (e.PropertyName == "Contexto")
            {
                var result = this.servicioConfiguraEmpresa.Grabar(configuraEmpresa, usuario, "");
                if (configuraEmpresa.Id == 0)
                {
                    //actualizar items
                    var item = this.Items.FirstOrDefault(p => p.Empresa.Codigo == configuraEmpresa.Empresa.Codigo);
                    this.Items.Remove(item);
                    item.Id = result.getId();
                    this.Items.Add(item);
                }
            }

        }

        public ObservableCollection<Contexto> Contextos
        {
            get { return (ObservableCollection<Contexto>)GetValue(ContextosProperty); }
            set { SetValue(ContextosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contextos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextosProperty =
            DependencyProperty.Register("Contextos", typeof(ObservableCollection<Contexto>), typeof(PresentadorEmpresaContexto));



        public ObservableCollection<ConfiguraEmpresa> Items
        {
            get { return (ObservableCollection<ConfiguraEmpresa>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<ConfiguraEmpresa>), typeof(PresentadorEmpresaContexto));

    }
}
