using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Contabilidad;
using Inteldev.Fixius.Modelo.Financiero;
using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Logistica;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Modelo.Preventa;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Stock;
using Inteldev.Fixius.Modelo.Tesoreria;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

//using Inteldev.Core.Modelo.Auditoria;


namespace Inteldev.Fixius.Datos
{
    /// <summary>
    /// Implementacion del contexto de Inteldev.Core
    /// Define los contextos.
    /// </summary>
    /// 

    public class ContextoGenerico : DbContextBase
    {

        public ContextoGenerico()
            : base()
        {
            Database.Initialize(false);
            //base.Configuration.AutoDetectChangesEnabled = false;
            //Database.SetInitializer<ContextoGenerico>(new MigrateDatabaseToLatestVersion<ContextoGenerico, Migrations.Configuration>());
        }
        //"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico; Integrated Security=SSPI"
        public ContextoGenerico(string connectionString)
            : base(connectionString)
        {
            //Database.SetInitializer<ContextoGenerico>(new DropCreateDatabaseIfModelChanges<ContextoGenerico>()); //ACTUAL

            Database.SetInitializer<ContextoGenerico>(new MigrateDatabaseToLatestVersion<ContextoGenerico, Migrations.Configuration>());
            Database.Initialize(false);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoGenerico, Migrations.Configuration>());

            //Database.SetInitializer<ContextoGenerico>(new DropCreateDatabaseAlways<ContextoGenerico>());

            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.AutoDetectChangesEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.ComplexType<DiasDeSemana>();
            modelBuilder.Entity<Proveedor>().HasMany(p => p.Telefonos).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Proveedor>().HasMany(p => p.Contactos).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<CambioDePreciosDeVenta>().HasMany(p => p.ItemsCambioDePrecioDeVenta).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<DatosOldArticulo>().HasOptional(p => p.ArticuloEnvase).WithMany().HasForeignKey(c => c.ArticuloEnvaseId);

            modelBuilder.Entity<Cliente>().HasMany(p => p.ConfiguraCreditos).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Cliente>().HasMany(p => p.ObservacionCliente).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Cliente>().HasMany(p => p.TarjetasCliente).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Cliente>().HasMany(p => p.Telefonos).WithOptional().WillCascadeOnDelete(true);
            modelBuilder.Entity<Cliente>().HasOptional(p => p.ZonaGeografica).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Articulo>().HasMany(p => p.ArticulosCompuestos).WithOptional().WillCascadeOnDelete(true);

            modelBuilder.Entity<Envase>().HasMany(p => p.Articulos).WithOptional().WillCascadeOnDelete(true);

            modelBuilder.Entity<RutaDeVenta>().HasOptional(p => p.DatosOld).WithMany().WillCascadeOnDelete(true);

            modelBuilder.Entity<ItemsConceptos>().Property(i => i.Debe).HasPrecision(18, 3);
            modelBuilder.Entity<ItemsConceptos>().Property(i => i.Haber).HasPrecision(18, 3);

            modelBuilder.Entity<Preventa>().HasOptional(p => p.DatosOldPreventa).WithMany().WillCascadeOnDelete(true);

            //modelBuilder.Entity<ListaDePrecios>().MapToStoredProcedures();
            //modelBuilder.Entity<ListaDePreciosDetalle>().MapToStoredProcedures();
            //modelBuilder.Entity<ListaDePreciosColumna>().MapToStoredProcedures();
            //modelBuilder.Entity<Auditoria>().MapToStoredProcedures();
            //modelBuilder.Entity<DetalleAuditoria>().MapToStoredProcedures();

            //modelBuilder.Entity<Permiso>().HasOptional(t => t.PerfilUsuario).WithOptionalPrincipal(u => u.Permisos);
            //modelBuilder.Entity<PerfilUsuario>().HasRequired(t => t.Permisos).WithRequiredPrincipal(p=>p.PerfilUsuario);
            //modelBuilder.Entity<Observacion>().Property(f => f.FechaHora).HasColumnType("datetime").HasPrecision(0);
        }

        //Auditoria
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<DetalleAuditoria> DetalleAuditoria { get; set; }
        // Organizacion
        //public DbSet<Empresa> Empresas { get; set; }

        // Locacion


        public DbSet<Localidad> Localidades { get; set; } //PASAR A ContextoInicial??
        public DbSet<Provincia> Provincias { get; set; } //PASAR A ContextoInicial??
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Calle> Calles { get; set; } //PASAR A ContextoInicial??
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Coordenada> Coordenadas { get; set; }
        public DbSet<ColorColumnaPlantilla> Colores { get; set; }

        //Financiero
        public DbSet<ConceptoDeMovimiento> ConceptosDeMovimientos { get; set; }

        //Usuarios
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Permiso> Permisos { get; set; }
        //public DbSet<PerfilUsuario> Perfiles { get; set; }

        //Articulos
        public DbSet<SKU> SKU { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<ArticuloCompuesto> ArticulosCompuestos { get; set; }
        public DbSet<Empaque> Empaques { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<Envase> Envases { get; set; }
        public DbSet<ArticuloEnvase> ArticulosEnvase { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Subsector> SubSectores { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Subfamilia> SubFamilia { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<DevolucionDeMercaderia> DevolucionDeMercaderia { get; set; }
        public DbSet<DetalleDevolucionMercaderia> DetalleDevolucionDeMercaderia { get; set; }
        public DbSet<ObservacionArticulo> ObservacionesArticulo { get; set; }
        public DbSet<Clase> Clase { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<DatosOldArticulo> DatosOldArticulo { get; set; }
        //Proveedores
        public DbSet<CondicionDePagoProveedor> CondicionesDePagos { get; set; }
        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ObservacionProveedor> ObservacionesProveedor { get; set; }
        public DbSet<PlantillaListaProveedor> PlantillasListaProveedor { get; set; }
        public DbSet<Columna> Columnas { get; set; }
        public DbSet<OrdenDeCompra> OrdenDeCompra { get; set; }
        public DbSet<ListaDePrecios> ListasDePrecios { get; set; }
        public DbSet<ListaDePreciosColumna> ListasDePrecioColumnas { get; set; }
        public DbSet<ListaDePreciosDetalle> ListasDePrecioDetalles { get; set; }
        public DbSet<ListaDePreciosObservacion> LisaDePrecioObservaciones { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Objetivos> Objetivos { get; set; }
        public DbSet<ObjetivosDeCompra> ObjetivosDeCompra { get; set; }
        public DbSet<NotaDeDebitoDeVenta> NotaDeDebitoDeVenta { get; set; }
        public DbSet<DatosOldProveedor> DatosOldProveedor { get; set; }
        public DbSet<DatosOldCliente> DatosOldCliente { get; set; }
        public DbSet<TipoProveedor> TipoProveedor { get; set; }
        public DbSet<ProntoPago> ProntoPago { get; set; }
        public DbSet<ResponsablesCompras> ResponsableAutorizacionCompras { get; set; }
        public DbSet<NotaPendiente> NotasPendientes { get; set; }
        //Clientes
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Canal> Canales { get; set; }
        public DbSet<Ramo> Ramos { get; set; }
        public DbSet<TarjetaClienteMayorista> TarjetasClienteMayorista { get; set; }
        public DbSet<TarjetaMayoristaItem> TarjetasMayoristaItem { get; set; }
        public DbSet<GrupoCliente> GupoClientes { get; set; }
        public DbSet<ObservacionCliente> ObservacionesCliente { get; set; }
        public DbSet<DivisionComercial> DivisionComercial { get; set; }
        public DbSet<EmpresaCodigo> EmpresaCodigo { get; set; }
        public DbSet<GeoRegionDeVenta> GeoRegionDeVenta { get; set; }
        public DbSet<RegionDeVenta> RegionDeVenta { get; set; }
        public DbSet<RutaDeVenta> RutaDeVenta { get; set; }

        //public DbSet<OperariosDePreventa> OperariosDePreventa { get; set; }
        public DbSet<Transportista> Transportista { get; set; }
        public DbSet<ConfiguraCredito> ConfiguraCreditos { get; set; }
        public DbSet<CondicionDePagoCliente> CondicionDePagoCliente { get; set; }
        //Stock
        public DbSet<Deposito> Deposito { get; set; }


        //Precios
        public DbSet<ListaDePreciosDeVenta> ListasDePreciosDeVenta { get; set; }
        public DbSet<ItemListaDePrecioDeVenta> ItemsListaDePrecioDeVenta { get; set; }
        public DbSet<HabilitaLista> HabilitacionesDeListas { get; set; }

        public DbSet<DescuentosPorLista> DescuentosPorLista { get; set; }
        public DbSet<ItemDescuentoPorLista> ItemDescuentoPorLista { get; set; }
        public DbSet<Descuento> Descuento { get; set; }

        public DbSet<CambioDePreciosDeVenta> CambiosDePreciosDeVenta { get; set; }
        public DbSet<ItemCambioDePrecioDeVenta> ItemsCambioDePreciosDeVenta { get; set; }

        public DbSet<Folder> Folders { get; set; }

        //organización
        public DbSet<Sucursal> Sucursales { get; set; }

        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<DocumentoCompra> Facturas { get; set; }
        public DbSet<DocumentoProveedor> DocumentosProveedor { get; set; }
        public DbSet<ItemIngreso> ItemsIngreso { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        //public DbSet<Modelo.Stock.ReciboStock> Recibos { get; set; }
        public DbSet<Numerador> Numeradores { get; set; }
        public DbSet<DetalleMovimiento> DetalleMovimiento { get; set; }
        public DbSet<Documento> Documentos { get; set; }

        //tesoreria
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ChequeDeTercero> ChequesDeTercero { get; set; }
        public DbSet<MovimientoChequeTercero> MovimientosChequeTerceros { get; set; }
        public DbSet<CuentaBancaria> CuentaBancaria { get; set; }
        public DbSet<MovimientoBancario> MovimientoBancario { get; set; }
        public DbSet<ConceptoDeMovimientoBancario> CocneptoMovimientoBancario { get; set; }

        //logistica
        public DbSet<ZonaGeografica> ZonasGeograficas { get; set; }
        public DbSet<ZonaLogistica> ZonasLogisticas { get; set; }

        public DbSet<ReferenciaContable> ReferenciasContables { get; set; }

        //preventa
        //public DbSet<Preventa> Preventistas { get; set; }
        public DbSet<Preventista> Preventistas { get; set; }
        public DbSet<Cobrador> Cobradores { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Supervisor> Supervisores { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<CargosDeFuerzaDeVenta> CargosDeFuerzaDeVenta { get; set; }
        public DbSet<CoordenadaCliente> CoordenadasClientes { get; set; }

        //fiscal
        public DbSet<PadronIIBB> PadronIIBB { get; set; }

    }

}
