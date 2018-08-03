using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Presentacion;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios;
using Inteldev.Fixius.Negocios.Importadores;
using Inteldev.Fixius.Servicios;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Servidor2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region PROPIEDADES

        private RegistroMapeadores registro;
        private static System.Timers.Timer aTimer;

        public DispatcherTimer Temporizador { get; set; }
        public TimeSpan Tiempo { get; set; }

        #endregion

        public MainWindow()
        {
            #region Temporizador para la actualizacion automatica de datos
            aTimer = new System.Timers.Timer(1000 * 55);
            aTimer.Elapsed += OnTimedEvent;
            //aTimer.Enabled = true;
            aTimer.Start();
            #endregion

            LogManager.Instancia.Mensajes.CollectionChanged += Mensajes_CollectionChanged;
            this.DataContext = this;
            Servidor.Instancia.PuertoHttp = 8000;
            Servidor.Instancia.PuertoTCP = 8081;
            InitializeComponent();
            try
            {
                this.crearHosts();
                var reg = new Inteldev.Fixius.Negocios.RegistroNegocios();
                FabricaNegocios.Instancia.CargarRegistro(reg);

                //  Microsoft.Practices.Unity.ParameterOverride[] para = { new Microsoft.Practices.Unity.ParameterOverride("empresa", null), new Microsoft.Practices.Unity.ParameterOverride("entidad", typeof(Inteldev.Fixius.Modelo.Preventa.Preventista).Name.ToLower()) };
                //  var creprev = FabricaNegocios.Instancia.Resolver(typeof(ICreador<Inteldev.Fixius.Modelo.Preventa.Preventista>),para);

                //esto no me gusta mucho
                Inteldev.Fixius.Servicios.RegistroMapeos mapeos = new Inteldev.Fixius.Servicios.RegistroMapeos();
                mapeos.Configurar();
                var a = FabricaNegocios._Resolver<Inteldev.Core.Negocios.Menu.IGestorMenu>();
                var m = FabricaServicios._Resolver<Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor>();
                this.registro = new RegistroMapeadores();
                foreach (Mapeador item in registro.Mapeadores)
                    this.dataGridMapaeadoresFox.ItemsSource = this.registro.Mapeadores;
                a.Crear();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            this.PresentadorContexto = new PresentadorGrillaServidor<Inteldev.Fixius.Modelo.Contexto, Inteldev.Fixius.Servicios.DTO.Contexto, ItemContexto>();
            this.PresentadorEmpresaContexto = new PresentadorEmpresaContexto();
            this.PresentadorEmpresaEntidad = new PresentadorEmpresaEntidad();
            this.dataGridRegistros.ItemsSource = FabricaNegocios.Instancia.ObtenerRegistro();
        }

        #region EVENTOS

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            //if (e.SignalTime.Hour == 20 && e.SignalTime.Minute == 30)
            //this.Actualizar();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Tiempo = Tiempo.Add(Temporizador.Interval);
            //txtTiempoTranscurrido.Text = Tiempo.Duration().ToString("c");
        }
        void Mensajes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Dispatcher.Invoke(delegate()
            {
                var a = LogManager.Instancia.Mensajes.LastOrDefault();
                this.lstManager.Items.Add(a);
                this.lstManager.ScrollIntoView(lstManager.Items[lstManager.Items.Count - 1]);
            });
        }

        #endregion

        #region PROPIEDADES DE DEPENDENCIA
        public PresentadorEmpresaEntidad PresentadorEmpresaEntidad
        {
            get { return (PresentadorEmpresaEntidad)GetValue(PresentadorEmpresaEntidadProperty); }
            set { SetValue(PresentadorEmpresaEntidadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresentadorEmpresaEntidad.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresentadorEmpresaEntidadProperty =
            DependencyProperty.Register("PresentadorEmpresaEntidad", typeof(PresentadorEmpresaEntidad), typeof(MainWindow));

        public PresentadorGrillaServidor<Inteldev.Fixius.Modelo.Contexto, Inteldev.Fixius.Servicios.DTO.Contexto, ItemContexto> PresentadorContexto
        {
            get { return (PresentadorGrillaServidor<Inteldev.Fixius.Modelo.Contexto, Inteldev.Fixius.Servicios.DTO.Contexto, ItemContexto>)GetValue(PresentadorContextoProperty); }
            set { SetValue(PresentadorContextoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresentadorContexto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresentadorContextoProperty =
            DependencyProperty.Register("PresentadorContexto", typeof(PresentadorGrillaServidor<Inteldev.Fixius.Modelo.Contexto, Inteldev.Fixius.Servicios.DTO.Contexto, ItemContexto>), typeof(MainWindow));

        public PresentadorEmpresaContexto PresentadorEmpresaContexto
        {
            get { return (PresentadorEmpresaContexto)GetValue(PresentadorEmpresaContextoProperty); }
            set { SetValue(PresentadorEmpresaContextoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresentadorEmpresaContexto.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresentadorEmpresaContextoProperty =
            DependencyProperty.Register("PresentadorEmpresaContexto", typeof(PresentadorEmpresaContexto), typeof(MainWindow));

        #endregion

        private void crearHosts()
        {
            Servidor.Instancia.CrearHost(typeof(ServicioUsuario), typeof(IServicioUsuario), "ServicioUsuario");
            Servidor.Instancia.CrearHost(typeof(ServicioMenu), typeof(IServicioMenu), "ServicioMenu");



            Servidor.Instancia.CrearHost(typeof(ServicioPerfilUsuario), typeof(IServicioPerfilUsuario), "ServicioPerfilUsuario");


            Servidor.Instancia.CrearHost(typeof(ServicioABM<Inteldev.Core.DTO.Usuarios.Permiso, Inteldev.Core.Modelo.Usuarios.Permiso>), typeof(IServicioABM<Inteldev.Core.DTO.Usuarios.Permiso>), "ServicioPermiso");


            Servidor.Instancia.CrearHostGenerico(typeof(ServicioBusqueda<Inteldev.Fixius.Modelo.Clientes.Cliente,
                                                                 Inteldev.Fixius.Servicios.DTO.Clientes.Cliente,
                                                                 Inteldev.Fixius.Servicios.DTO.Clientes.ClienteBusqueda>));

            //Organizacion
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Empresa, Inteldev.Core.Modelo.Organizacion.Empresa>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Sucursal, Inteldev.Core.Modelo.Organizacion.Sucursal>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<DivisionComercial, Inteldev.Core.Modelo.Organizacion.DivisionComercial>));

            //Financiero
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento>));

            //Locacion

            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Locacion.Provincia, Inteldev.Core.Modelo.Locacion.Provincia>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Locacion.Calle, Inteldev.Core.Modelo.Locacion.Calle>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Locacion.Localidad, Inteldev.Core.Modelo.Locacion.Localidad>));

            //Articulos
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Articulo, Inteldev.Fixius.Modelo.Articulos.Articulo>));
            Servidor.Instancia.CrearHost(typeof(ServicioObtenerCodigoDisponible<Inteldev.Fixius.Modelo.Articulos.Articulo>), typeof(IServicioObtenerCodigoDisponible), "ServicioObtenerCodigoDisponibleArticulo");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.ArticuloCompuesto, Inteldev.Fixius.Modelo.Articulos.ArticuloCompuesto>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Empaque, Inteldev.Fixius.Modelo.Articulos.Empaque>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Envase, Inteldev.Fixius.Modelo.Articulos.Envase>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.ArticuloEnvase, Inteldev.Fixius.Modelo.Articulos.ArticuloEnvase>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Marca, Inteldev.Fixius.Modelo.Articulos.Marca>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.SKU, Inteldev.Fixius.Modelo.Articulos.SKU>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Caracteristica, Inteldev.Fixius.Modelo.Articulos.Caracteristica>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Area, Inteldev.Fixius.Modelo.Articulos.Area>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Sector, Inteldev.Fixius.Modelo.Articulos.Sector>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Subsector, Inteldev.Fixius.Modelo.Articulos.Subsector>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Familia, Inteldev.Fixius.Modelo.Articulos.Familia>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Subfamilia, Inteldev.Fixius.Modelo.Articulos.Subfamilia>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Categoria, Inteldev.Fixius.Modelo.Articulos.Categoria>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.GrupoArticulo, Inteldev.Fixius.Modelo.Articulos.GrupoArticulo>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Clase, Inteldev.Fixius.Modelo.Articulos.Clase>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Rubro, Inteldev.Fixius.Modelo.Articulos.Rubro>));
            Servidor.Instancia.CrearHost(typeof(ServicioObtenerCodigoDisponible<Inteldev.Fixius.Modelo.Articulos.Rubro>), typeof(IServicioObtenerCodigoDisponible), "ServicioObtenerCodigoDisponibleRubro");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Division, Inteldev.Fixius.Modelo.Articulos.Division>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Articulos.Linea, Inteldev.Fixius.Modelo.Articulos.Linea>));
            Servidor.Instancia.CrearHost(typeof(ServicioObtenerCodigoDisponible<Inteldev.Fixius.Modelo.Articulos.Linea>), typeof(IServicioObtenerCodigoDisponible), "ServicioObtenerCodigoDisponibleLinea");
            Servidor.Instancia.CrearHost(typeof(ServicioValorTasasDeIva), typeof(IServicioValorTasasDeIva), "ServicioValorTasasDeIva");
            //Proveedores
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor, Inteldev.Fixius.Modelo.Proveedores.Proveedor>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.CondicionDePagoProveedor, Inteldev.Fixius.Modelo.Proveedores.CondicionDePagoProveedor>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Entrega, Inteldev.Fixius.Modelo.Proveedores.Entrega>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios, Inteldev.Fixius.Modelo.Proveedores.ListaDePrecios>));
            //Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ColorColumnaPlantilla, Inteldev.Fixius.Modelo.Proveedores.ColorColumnaPlantilla>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.Cliente, Inteldev.Fixius.Modelo.Clientes.Cliente>));
            Servidor.Instancia.CrearHost(typeof(ServicioObtenerCodigoDisponible<Inteldev.Fixius.Modelo.Clientes.Cliente>), typeof(IServicioObtenerCodigoDisponible), "ServicioObtenerCodigoDisponibleCliente");
            Servidor.Instancia.CrearHost(typeof(ServicioRamosDeTarjetas), typeof(IServicioRamosDeTarjetas), "ServicioRamosDeTarjetas");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.Ramo, Inteldev.Fixius.Modelo.Clientes.Ramo>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.Canal, Inteldev.Fixius.Modelo.Clientes.Canal>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.PlantillaListaProveedor, Inteldev.Fixius.Modelo.Proveedores.PlantillaListaProveedor>));
            Servidor.Instancia.CrearHost(typeof(ServicioOrdenDeCompra), typeof(IServicioOrdenDeCompra), "ServicioOrdenDeCompra");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ObjetivosDeCompra, Inteldev.Fixius.Modelo.Proveedores.ObjetivosDeCompra>));
            Servidor.Instancia.CrarHost<ServicioColores, IServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ColorColumnaPlantilla>>("ServicioColorColumnaPlantilla");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Transportista, Inteldev.Fixius.Modelo.Proveedores.Transportista>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.TipoProveedor, Inteldev.Fixius.Modelo.Proveedores.TipoProveedor>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra, Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra>));
            Servidor.Instancia.CrearHost(typeof(ServicioDocumentoDeCompra), typeof(IServicioDocumentoDeCompra), "ServicioDocumentoDeCompra");
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDePago, Inteldev.Fixius.Modelo.Proveedores.OrdenDePago>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ResponsablesCompras, Inteldev.Fixius.Modelo.Proveedores.ResponsablesCompras>));
            //Tesoreria
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Tesoreria.Banco, Inteldev.Fixius.Modelo.Tesoreria.Banco>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Tesoreria.ChequeDeTercero, Inteldev.Fixius.Modelo.Tesoreria.ChequeDeTercero>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Tesoreria.CuentaBancaria, Inteldev.Fixius.Modelo.Tesoreria.CuentaBancaria>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Tesoreria.MovimientoBancario, Inteldev.Fixius.Modelo.Tesoreria.MovimientoBancario>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Tesoreria.ConceptoDeMovimientoBancario, Inteldev.Fixius.Modelo.Tesoreria.ConceptoDeMovimientoBancario>));
            //Stock
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Stock.Deposito, Inteldev.Core.Modelo.Stock.Deposito>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Numerador, Inteldev.Core.Modelo.Numerador>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Motivo, Inteldev.Fixius.Modelo.Proveedores.Motivo>));
            //cliente
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.TarjetaClienteMayorista, Inteldev.Fixius.Modelo.Clientes.TarjetaClienteMayorista>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.GrupoCliente, Inteldev.Fixius.Modelo.Clientes.GrupoCliente>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Stock.Ingreso, Inteldev.Fixius.Modelo.Stock.Ingreso>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Stock.Movimiento, Inteldev.Fixius.Modelo.Stock.Movimiento>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.CargosDeFuerzaDeVenta, Inteldev.Fixius.Modelo.Clientes.CargosDeFuerzaDeVenta>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.GeoRegionDeVenta, Inteldev.Fixius.Modelo.Clientes.GeoRegionDeVenta>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.RegionDeVenta, Inteldev.Fixius.Modelo.Clientes.RegionDeVenta>));
            Servidor.Instancia.CrearHost(typeof(ServicioPercepcion), typeof(IServicioPercepcion), "ServicioPercepcion");
            Servidor.Instancia.CrearHost(typeof(ServicioTarjetas), typeof(IServicioTarjetas), "ServicioTarjetas");
            //Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Core.DTO.Organizacion.DivisionComercial,Inteldev.Core.Modelo.Organizacion.DivisionComercial>));
            Servidor.Instancia.CrearHost(typeof(ServicioRutaDeVenta), typeof(IServicioRutaDeVenta), "ServicioRutaDeVenta");
            Servidor.Instancia.CrearHost(typeof(ServicioPedido), typeof(IServicioPedido), "ServicioPedido");
            Servidor.Instancia.CrearHost(typeof(ServicioDetallePedido), typeof(IServicioDetallePedido), "ServicioDetallePedido");
            //FuerzaDeVenta
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Jefe, Inteldev.Fixius.Modelo.Preventa.Jefe>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Supervisor, Inteldev.Fixius.Modelo.Preventa.Supervisor>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Preventista, Inteldev.Fixius.Modelo.Preventa.Preventista>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Cobrador, Inteldev.Fixius.Modelo.Preventa.Cobrador>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Preventa.Vendedor, Inteldev.Fixius.Modelo.Preventa.Vendedor>));
            //Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.OperariosDePreventa,Inteldev.Fixius.Modelo.Clientes.OperariosDePreventa>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Clientes.CondicionDePagoCliente, Inteldev.Fixius.Modelo.Clientes.CondicionDePagoCliente>));
            Servidor.Instancia.CrearHost(typeof(ServicioCoordenadasClientes), typeof(IServicioCoordenadasClientes), "ServicioCoordenadasClientes");
            //precios de venta
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Precios.ListaDePreciosDeVenta, Inteldev.Fixius.Modelo.Precios.ListaDePreciosDeVenta>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Precios.HabilitaLista, Inteldev.Fixius.Modelo.Precios.HabilitaLista>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Precios.DescuentosPorLista, Inteldev.Fixius.Modelo.Precios.DescuentosPorLista>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Precios.CambioDePreciosDeVenta, Inteldev.Fixius.Modelo.Precios.CambioDePreciosDeVenta>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Precios.Folder, Inteldev.Fixius.Modelo.Precios.Folder>));

            //logistica
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Logistica.ZonaGeografica, Inteldev.Fixius.Modelo.Logistica.ZonaGeografica>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Logistica.ZonaLogistica, Inteldev.Fixius.Modelo.Logistica.ZonaLogistica>));
            //contabilidad
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Contabilidad.TasasDeIva, Inteldev.Fixius.Modelo.Contabilidad.TasasDeIva>));
            Servidor.Instancia.CrearHostGenerico(typeof(ServicioABM<Inteldev.Fixius.Servicios.DTO.Contabilidad.ReferenciaContable, Inteldev.Fixius.Modelo.Contabilidad.ReferenciaContable>));
            Servidor.Instancia.CrearHost(typeof(ServicioRefencia), typeof(IServicioReferencia), "ServicioReferencia");
        }

        IPAddress GetMyExternalIP()
        {
            HttpWebRequest wq = (HttpWebRequest)HttpWebRequest.Create(@"http://whatismyip.org/");
            HttpWebResponse wr = (HttpWebResponse)wq.GetResponse();
            StreamReader sr = new StreamReader(wr.GetResponseStream(), System.Text.Encoding.UTF8);
            IPAddress ip = IPAddress.Parse(sr.ReadToEnd());
            sr.Close();
            wr.Close();
            return ip;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Servidor.Instancia.AbrirServicios();
            this.txtIp.Text = Servidor.Instancia.DireccionIP;
            this.txtPuerto.Text = Servidor.Instancia.PuertoTCP.ToString();
            button1.IsEnabled = false;
            button2.IsEnabled = true;
            MessageBox.Show(string.Format("Servidor abierto en IP {0}", this.txtIp.Text), "Alerta", MessageBoxButton.OK);
            WindowState = WindowState.Minimized;
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Servidor.Instancia.CerrarCervicios();
            button1.IsEnabled = true;
            button2.IsEnabled = false;
        }

        private void btnActualizarBD(object sender, RoutedEventArgs e) //ActualizarBD
        {
            btnActualizar.IsEnabled = false;
            Main.Focus();
            this.Actualizar();
            btnActualizar.IsEnabled = true;
        }

        private void Actualizar()
        {
            aTimer.Stop();
            //TEMPORIZADOR
            Temporizador = new System.Windows.Threading.DispatcherTimer();
            Temporizador.Tick += new EventHandler(dispatcherTimer_Tick);
            Temporizador.Interval = new TimeSpan(0, 0, 1);
            Tiempo = new TimeSpan();
            Temporizador.Start();
            LogManager.Instancia.AgregarMensaje("Comenzando importación de datos.");

            ImportadorDatos importa = new ImportadorDatos(this.registro);
            try
            {
                var hilo = new Thread(
                    new ThreadStart(() =>
                    {

                        importa.Procesar();
                        LogManager.Instancia.AgregarMensaje("¡Importacion Finalizada!");
                        Temporizador.Stop();
                        aTimer.Start();
                        LogManager.Instancia.Resetear();
                    })
                    );
                hilo.IsBackground = true;
                hilo.Start();

            }
            catch (Exception exc)
            {
                Mensajes.Error(exc);
            }
        }
    }
}
