using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Negocios.Menu;
using Inteldev.Core.Negocios.Usuarios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Core.Patrones;
using Inteldev.Fixius.DataSwitch;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Financiero;
using Inteldev.Fixius.Modelo.Logistica;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Modelo.Preventa;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Articulos.Borradores;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Inteldev.Fixius.Negocios.Articulos.Creadores;
using Inteldev.Fixius.Negocios.Articulos.Grabadores;
using Inteldev.Fixius.Negocios.Articulos.GrabadoresFox;
using Inteldev.Fixius.Negocios.Articulos.Numeradores;
using Inteldev.Fixius.Negocios.Articulos.Validadores;
using Inteldev.Fixius.Negocios.Busquedas;
using Inteldev.Fixius.Negocios.Busquedas.Bloques;
using Inteldev.Fixius.Negocios.Clientes;
using Inteldev.Fixius.Negocios.Clientes.Borradores;
using Inteldev.Fixius.Negocios.Clientes.Buscadores;
using Inteldev.Fixius.Negocios.Clientes.Creadores;
using Inteldev.Fixius.Negocios.Clientes.Grabadores;
using Inteldev.Fixius.Negocios.Clientes.GrabadoresFox;
using Inteldev.Fixius.Negocios.Clientes.Numeradores;
using Inteldev.Fixius.Negocios.Contabilidad;
using Inteldev.Fixius.Negocios.Fiscales;
using Inteldev.Fixius.Negocios.Importadores;
using Inteldev.Fixius.Negocios.Logistica.GrabadoresFox;
using Inteldev.Fixius.Negocios.Menu;
using Inteldev.Fixius.Negocios.Organizacion;
using Inteldev.Fixius.Negocios.Precios;
using Inteldev.Fixius.Negocios.Preventa;
using Inteldev.Fixius.Negocios.Preventa.Buscadores;
using Inteldev.Fixius.Negocios.Preventa.BuscadoresDTO;
using Inteldev.Fixius.Negocios.Preventa.Grabadores;
using Inteldev.Fixius.Negocios.Preventa.GrabadoresFox;
using Inteldev.Fixius.Negocios.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Borradores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Inteldev.Fixius.Negocios.Proveedores.Consultadores;
using Inteldev.Fixius.Negocios.Proveedores.Creadores;
using Inteldev.Fixius.Negocios.Proveedores.Grabadores;
using Inteldev.Fixius.Negocios.Proveedores.GrabadoresFox;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Negocios.Proveedores.Mapeadores;
using Inteldev.Fixius.Negocios.Proveedores.Numeradores;
using Inteldev.Fixius.Negocios.Stock;
using Inteldev.Fixius.Negocios.Stock.GrabadoresFox;
using Inteldev.Fixius.Negocios.Stock.Mapeadores;
using Inteldev.Fixius.Negocios.Tesoreria;
using Inteldev.Fixius.Negocios.Usuarios;
using Inteldev.Fixius.Negocios.Validadores;
using System.Data.Entity;



namespace Inteldev.Fixius.Negocios
{
    public class RegistroNegocios : Inteldev.Core.Patrones.RegistroFabrica
    {
        public override void Configurar()
        {
            DbConfiguration.SetConfiguration(new DbConf());
            this.Registrar(typeof(IDbContext), typeof(ContextoGenerico));
            this.Registrar(typeof(ILogin), typeof(Login));

            this.Registrar(typeof(ICreadorItemCambioDePrecioDeVenta<ListaDePreciosDetalle>), typeof(CreadorItemCambioDePrecioDeVenta<ListaDePreciosDetalle>));
            this.Registrar(typeof(IBuscaCosto<ListaDePreciosDetalle>), typeof(BuscadorListaDePreciosDetalle<ListaDePreciosDetalle>));

            this.Registrar(typeof(IBorradorDTO<,>), typeof(BorradorDTO<,>));

            this.Registrar(typeof(IPoneLetra), typeof(PoneLetra));
            this.Registrar(typeof(Inteldev.Core.DataSwitch.IDataSwitch<>), typeof(DataSwitch<>));
            //busquedas especificas

            //this.Registrar(typeof(IBlockDeBusqueda<Articulo>),typeof(BloqueArticulo));
            this.Registrar(typeof(IBlockDeBusqueda<DocumentoCompra>), typeof(BloqueComprobanteDeCompra));
            this.Registrar(typeof(IBlockDeBusqueda<Cliente>), typeof(BlockDeBusquedaCliente));
            this.Registrar(typeof(IBlockDeBusqueda<Proveedor>), typeof(BlockDeBusquedaProveedor));

            //busquedas
            this.Registrar(typeof(IBlockDeBusqueda<>), typeof(BlockDeBusquedaGenerico<>));
            this.Registrar(typeof(IGestorMenu), typeof(GestorMenu));
            this.Registrar(typeof(IMenuHelper), typeof(MenuHelper));
            this.Registrar(typeof(IMenuPreventa), typeof(MenuPreventa));
            this.Registrar(typeof(IMenuGestion), typeof(MenuGestion));
            this.Registrar(typeof(IMenuLogistica), typeof(MenuLogistica));
            this.Registrar(typeof(IMenuMayorista), typeof(MenuMayorista));
            this.Registrar(typeof(IMenuRepresentaciones), typeof(MenuRepresentaciones));
            this.Registrar(typeof(IContextoDeBusqueda<,>), typeof(ContextoDeBusqueda<,>));
            //this.Registrar(typeof(IBlockDeBusqueda<Cliente>), typeof(BlockCliente));

            this.Registrar(typeof(IBuscadorPercepcion), typeof(BuscadorPercepcionPorPadron));

            //consultador
            this.Registrar(typeof(IConsultador<>), typeof(ConsultadorFacturaProveedor));

            //contabilidad
            this.Registrar(typeof(IRegistroMapeoTasaConcepto), typeof(RegistroMapeoTasaConcepto));

            this.Registrar(typeof(IBuscadorFoxConfigZona), typeof(BuscadorFoxConfigZona), new InyectaValor("conexion", typeof(DaoFoxReal)));



            #region Creadores DTO

            this.Registrar(typeof(ICreadorDTO<,>), typeof(CreadorDTO<,>));
            this.Registrar(typeof(ICreadorDTO<Modelo.Proveedores.DocumentoCompra, Servicios.DTO.Proveedores.DocumentoCompra>), typeof(CreadorDocumentoCompra));
            this.Registrar(typeof(ICreadorDTO<Inteldev.Fixius.Modelo.Stock.Movimiento, Inteldev.Fixius.Servicios.DTO.Stock.Movimiento>), typeof(CreadorMovimiento));
            this.Registrar(typeof(ICreadorDTO<Inteldev.Fixius.Modelo.Articulos.Articulo, Inteldev.Fixius.Servicios.DTO.Articulos.Articulo>), typeof(CreadorArticulo));
            this.Registrar(typeof(ICreadorDTO<Cliente, Servicios.DTO.Clientes.Cliente>), typeof(CreadorCliente));
            this.Registrar(typeof(ICreadorDTO<Modelo.Proveedores.ListaDePrecios, Servicios.DTO.Proveedores.ListaDePrecios>), typeof(CreadorListaDePrecios));
            this.Registrar(typeof(ICreadorDTO<Modelo.Proveedores.OrdenDeCompra, Servicios.DTO.Proveedores.OrdenDeCompra>), typeof(CreadorOrdenDeCompra));
            this.Registrar(typeof(ICreadorDTO<Modelo.Precios.CambioDePreciosDeVenta, Servicios.DTO.Precios.CambioDePreciosDeVenta>), typeof(CreadorCambioDePreciosDeVenta));
            this.Registrar(typeof(ICreadorDTO<Inteldev.Fixius.Modelo.Stock.Ingreso, Inteldev.Fixius.Servicios.DTO.Stock.Ingreso>), typeof(CreadorIngreso));
            this.Registrar(typeof(ICreadorDTO<Modelo.Proveedores.OrdenDePago, Servicios.DTO.Proveedores.OrdenDePago>), typeof(CreadorOrdenDePago));
            this.Registrar(typeof(ICreadorDTO<Modelo.Proveedores.DevolucionDeMercaderia, Servicios.DTO.Proveedores.DevolucionDeMercaderia>), typeof(CreadorDevolucionDeMercaderia));
            this.Registrar(typeof(ICreadorDTO<Modelo.Articulos.Linea, Servicios.DTO.Articulos.Linea>), typeof(CreadorLinea));

            #endregion

            #region Buscadores DTO

            this.Registrar(typeof(IBuscadorDTO<,>), typeof(BuscadorDTO<,>));
            this.Registrar(typeof(IBuscadorDTO<Permiso, Inteldev.Core.DTO.Usuarios.Permiso>), typeof(BuscadorDTOPermiso));
            this.Registrar(typeof(IBuscadorDTO<Modelo.Articulos.Sector, Inteldev.Fixius.Servicios.DTO.Articulos.Sector>), typeof(BuscadorDTOSector));
            this.Registrar(typeof(IBuscadorDTO<Modelo.Articulos.Subsector, Servicios.DTO.Articulos.Subsector>), typeof(BuscadorDTOSubSector));
            this.Registrar(typeof(IBuscadorDTO<Modelo.Articulos.Familia, Servicios.DTO.Articulos.Familia>), typeof(BuscadorDTOFamilia));
            this.Registrar(typeof(IBuscadorDTO<Modelo.Articulos.Subfamilia, Servicios.DTO.Articulos.Subfamilia>), typeof(BuscadorDTOSubFamilia));
            this.Registrar(typeof(IBuscadorDTO<OrdenDeCompra, Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra>), typeof(BuscadorDTOOrdenDeCompra));
            this.Registrar(typeof(IBuscadorDTOOrdenDeCompra), typeof(BuscadorDTOOrdenDeCompra));
            this.Registrar(typeof(IBuscadorRutaDeVentaDTO), typeof(BuscadorRutaDeVentaDTO));
            this.Registrar(typeof(IBuscadorCoordenadaClienteDTO), typeof(BuscadorCoordenadaClienteDTO));
            this.Registrar(typeof(IBuscadorDTO<Proveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor>), typeof(BuscadorDTOProveedor));

            #endregion

            #region Grabadores DTO

            this.Registrar(typeof(IGrabadorDTO<,>), typeof(GrabadorDTO<,>));
            this.Registrar(typeof(IGrabadorDTO<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>), typeof(GrabadorIngreso));

            #endregion



            #region Creadores

            this.Registrar(typeof(ICreador<>), typeof(CreadorGenerico<>));
            this.Registrar(typeof(ICreador<Preventista>), typeof(CreadorPreventista));
            this.Registrar(typeof(ICreador<Supervisor>), typeof(CreadorSupervisor));
            this.Registrar(typeof(ICreador<Jefe>), typeof(CreadorJefe));
            //this.Registrar(typeof(ICreador<Preventa>), typeof(CreadorPreventa));
            this.Registrar(typeof(ICreador<RutaDeVenta>), typeof(CreadorRutaDeVenta));
            this.Registrar(typeof(ICreador<Usuario>), typeof(CreadorUsuario));

            #endregion

            #region Buscadores

            this.Registrar(typeof(IBuscador<RutaDeVenta>), typeof(BuscadorRutaDeVenta));
            this.Registrar(typeof(IBuscadorComprobante), typeof(BuscadorComprobante));
            this.Registrar(typeof(IBuscador<OrdenDeCompraDetalle>), typeof(BuscadorOrdenDeCompraDetalle));
            this.Registrar(typeof(IBuscador<>), typeof(BuscadorGenerico<>));
            this.Registrar(typeof(IBuscador<Cliente>), typeof(BuscadorCliente));
            this.Registrar(typeof(IBuscadorArticulo), typeof(BuscadorArticulo));
            this.Registrar(typeof(IBuscadorObjetivos), typeof(BuscadorObjetivos));
            this.Registrar(typeof(IBuscadorListaDePrecios), typeof(BuscadorListaDePrecios));
            this.Registrar(typeof(IBuscadorRecibo), typeof(BuscadorRecibo));
            this.Registrar(typeof(IBuscadorLetra), typeof(BuscadorLetra));
            //this.Registrar(typeof(IBuscadorRutaDeVenta), typeof(BuscadorRutaDeVenta));
            this.Registrar(typeof(IBuscador<ListaDePreciosDetalle>), typeof(BuscadorListaDePreciosDetalle<ListaDePreciosDetalle>));
            this.Registrar(typeof(IBuscadorOrdenDeCompraDetalle), typeof(BuscadorOrdenDeCompraDetalle));
            this.Registrar(typeof(IBuscadorOrdenDeCompra), typeof(BuscadorOrdenDeCompra));
            this.Registrar(typeof(IBuscador<Modelo.Proveedores.ListaDePrecios>), typeof(BuscadorListaDePrecios));
            this.Registrar(typeof(IBuscadorDocumentoDeCompra), typeof(BuscadorDocumentoDeCompra));
            this.Registrar(typeof(IBuscadorTasa), typeof(BuscadorTasa));
            this.Registrar(typeof(IBuscador<TarjetaClienteMayorista>), typeof(BuscadorTarjetaClienteMayorista));
            this.Registrar(typeof(IBuscador<Sector>), typeof(BuscadorSector));
            this.Registrar(typeof(IBuscador<Subsector>), typeof(BuscadorSubsector));
            this.Registrar(typeof(IBuscador<Familia>), typeof(BuscadorFamilia));
            this.Registrar(typeof(IBuscador<Subfamilia>), typeof(BuscadorSubfamilia));
            //this.Registrar(typeof(IBuscadorCoordenadaCliente), typeof(BuscadorCoordenadaCliente));
            this.Registrar(typeof(IBuscador<CoordenadaCliente>), typeof(BuscadorCoordenadaCliente));

            #endregion


            #region Numerador: Cantidad de espacios en el codigo de la entidad

            this.Registrar(typeof(INumerador<>),
                           typeof(Numerador<>),
                           new InyectaValor("TamañoMaximo", 3)); //por defecto

            this.Registrar(typeof(INumerador<RutaDeVenta>),
                           typeof(Numerador<RutaDeVenta>),
                           new InyectaValor("TamañoMaximo", 4));

            //this.Registrar(typeof(INumerador<Proveedor>),
            //               typeof(Numerador<Proveedor>),
            //               new InyectaValor("TamañoMaximo", 5));
            this.Registrar(typeof(INumerador<Proveedor>),
                           typeof(NumeradorProveedor),
                           new InyectaValor("TamañoMaximo", 5));

            this.Registrar(typeof(INumerador<Cliente>),
                           typeof(NumeradorCliente),
                           new InyectaValor("TamañoMaximo", 5));

            this.Registrar(typeof(INumerador<ConceptoDeMovimiento>),
                           typeof(Numerador<ConceptoDeMovimiento>),
                           new InyectaValor("TamañoMaximo", 5));

            this.Registrar(typeof(INumerador<Empresa>),
                           typeof(Numerador<Empresa>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Articulo>),
                           typeof(Numerador<Articulo>),
                           new InyectaValor("TamañoMaximo", 13));

            this.Registrar(typeof(INumerador<Division>),
                           typeof(Numerador<Division>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Provincia>),
                           typeof(Numerador<Provincia>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Localidad>),
                           typeof(Numerador<Localidad>),
                           new InyectaValor("TamañoMaximo", 4));

            this.Registrar(typeof(INumerador<Calle>),
                           typeof(Numerador<Calle>),
                           new InyectaValor("TamañoMaximo", 10));

            this.Registrar(typeof(INumerador<ListaDePreciosDeVenta>),
                          typeof(Numerador<ListaDePreciosDeVenta>),
                          new InyectaValor("TamañoMaximo", 4));

            this.Registrar(typeof(INumerador<Preventista>),
                           typeof(Numerador<Preventista>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Jefe>),
                           typeof(Numerador<Jefe>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Supervisor>),
                           typeof(Numerador<Supervisor>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Cobrador>),
                           typeof(Numerador<Cobrador>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Vendedor>),
                           typeof(Numerador<Vendedor>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<CondicionDePagoCliente>),
                          typeof(Numerador<CondicionDePagoCliente>),
                          new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<ZonaGeografica>),
                          typeof(Numerador<ZonaGeografica>),
                          new InyectaValor("TamañoMaximo", 4));

            this.Registrar(typeof(INumerador<ZonaLogistica>),
                           typeof(Numerador<ZonaLogistica>),
                           new InyectaValor("TamañoMaximo", 4));
            //this.Registrar(typeof(INumerador<TarjetaMayoristaItem>),
            //               typeof(Numerador<TarjetaMayoristaItem>),
            //               new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<TarjetaClienteMayorista>),
                           typeof(Numerador<TarjetaClienteMayorista>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<RegionDeVenta>),
                           typeof(Numerador<RegionDeVenta>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<GeoRegionDeVenta>),
                           typeof(Numerador<GeoRegionDeVenta>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<SKU>),
                           typeof(Numerador<SKU>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Envase>),
                           typeof(Numerador<Envase>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Area>),
                           typeof(Numerador<Area>),
                           new InyectaValor("TamañoMaximo", 2));

            this.Registrar(typeof(INumerador<Subfamilia>),
                           typeof(NumeradorSubfamilia),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Familia>),
                           typeof(NumeradorFamilia),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Subsector>),
                           typeof(NumeradorSubsector),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Sector>),
                           typeof(NumeradorSector),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Linea>),
                           typeof(NumeradorLinea),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Rubro>),
                           typeof(NumeradorRubro),
                           new InyectaValor("TamañoMaximo", 3));

            this.Registrar(typeof(INumerador<Transportista>),
                           typeof(NumeradorTransportista),
                           new InyectaValor("TamañoMaximo", 5));

            this.Registrar(typeof(INumerador<Sucursal>),
                           typeof(Numerador<Sucursal>),
                           new InyectaValor("TamañoMaximo", 2));
            #endregion


            #region Grabador SQL Server

            this.Registrar(typeof(IGrabador<>), typeof(GrabadorGenerico<>));
            //this.Registrar(typeof(IGrabador<PerfilUsuario>), typeof(GrabadorPerfil));
            //this.Registrar(typeof(IGrabador<ListaDePrecios>),typeof(GrabadorListaDePrecios));
            this.Registrar(typeof(IGrabador<Modelo.Proveedores.Proveedor>), typeof(GrabadorProveedor));
            this.Registrar(typeof(IGrabador<Modelo.Proveedores.DocumentoCompra>), typeof(GrabadorDocumentoCompra));
            this.Registrar(typeof(IGrabador<Modelo.Clientes.RutaDeVenta>), typeof(GrabadorRutaDeVenta));
            this.Registrar(typeof(IGrabador<Modelo.Clientes.Cliente>), typeof(GrabadorCliente));
            this.Registrar(typeof(IGrabador<TarjetaClienteMayorista>), typeof(GrabadorTarjetaClienteMayorista));
            this.Registrar(typeof(IGrabador<DivisionComercial>), typeof(GrabadorDivisionComercial));
            this.Registrar(typeof(IGrabador<Core.Modelo.Usuarios.PerfilUsuario>), typeof(GrabadorPerfilUsuario));
            this.Registrar(typeof(IGrabador<GrupoCliente>), typeof(GrabadorGrupoCliente));
            this.Registrar(typeof(IGrabador<Modelo.Articulos.Articulo>), typeof(GrabadorArticulo));
            this.Registrar(typeof(IGrabador<Modelo.Articulos.Envase>), typeof(GrabadorEnvase));
            this.Registrar(typeof(IGrabador<Modelo.Preventa.Supervisor>), typeof(GrabadorSupervisor));

            #endregion

            #region Borradores SQL Server

            this.Registrar(typeof(IBorrador<>), typeof(BorradorGenerico<>));
            this.Registrar(typeof(IBorrador<Modelo.Clientes.Cliente>), typeof(BorradorCliente));
            this.Registrar(typeof(IBorrador<RutaDeVenta>), typeof(BorradorRutaDeVenta));
            this.Registrar(typeof(IBorrador<Proveedor>), typeof(BorradorProveedor));
            this.Registrar(typeof(IBorrador<Articulo>), typeof(BorradorArticulo));
            this.Registrar(typeof(IBorrador<Envase>), typeof(BorradorEnvase));

            this.Registrar(typeof(IBorrador<Sector>), typeof(BorradorSector));
            this.Registrar(typeof(IBorrador<Subsector>), typeof(BorradorSubsector));
            this.Registrar(typeof(IBorrador<Familia>), typeof(BorradorFamilia));
            this.Registrar(typeof(IBorrador<Subfamilia>), typeof(BorradorSubfamilia));

            #endregion

            #region Accesos a Visual Fox Pro

            //this.Registrar(typeof(IDao), typeof(DaoFoxReal));
            this.Registrar(typeof(IDao), typeof(DaoFoxPrueba));

            #endregion

            #region Grabadores Fox PRUEBA

            this.Registrar(typeof(IGrabadorFox<Core.Modelo.Locacion.Localidad>), typeof(GrabadorFoxLocalidad), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Core.Modelo.Locacion.Calle>), typeof(GrabadorFoxCalle), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Tesoreria.Banco>), typeof(GrabadorFoxBancos), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Canal>), typeof(GrabadorFoxCanal), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Ramo>), typeof(GrabadorFoxRamo), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Cliente>), typeof(GrabadorFoxClienteDoblePrueba)); //MODIFICAR INTERNAMENTE! NUMERADOR CLIENTE Y GRABADOR FOX CLIENTE (GRABAR CODIGO IDS) TAMBIEN
            this.Registrar(typeof(IGrabadorFox<GrupoCliente>), typeof(GrabadorFoxGrupoCliente), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<GeoRegionDeVenta>), typeof(GrabadorFoxGeoRegionDeVenta), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<RegionDeVenta>), typeof(GrabadorFoxRegionDeVenta), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<RutaDeVenta>), typeof(GrabadorFoxRutaDeVenta), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //actualmente en prueba
            //this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.DocumentoCompra>), typeof(GrabadorFoxDocumentoCompra), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Inteldev.Core.Modelo.Stock.Deposito>), typeof(GrabadorFoxDeposito), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Proveedor>), typeof(GrabadorFoxProveedor), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Proveedor>), typeof(GrabadorFoxProveedorDoblePrueba));

            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Articulo>), typeof(GrabadorFoxArticulo), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Envase>), typeof(GrabadorFoxEnvase), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Linea>), typeof(GrabadorFoxLinea), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Rubro>), typeof(GrabadorFoxRubro), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Empaque>), typeof(GrabadorFoxEmpaque), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Caracteristica>), typeof(GrabadorFoxCaracteristica), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Marca>), typeof(GrabadorFoxMarcas), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Clase>), typeof(GrabadorFoxClase), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Division>), typeof(GrabadorFoxDivision), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Area>), typeof(GrabadorFoxArea), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Sector>), typeof(GrabadorFoxSector), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Subsector>), typeof(GrabadorFoxSubsector), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Familia>), typeof(GrabadorFoxFamilia), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Subfamilia>), typeof(GrabadorFoxSubfamilia), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.Transportista>), typeof(GrabadorFoxTransportista), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.TipoProveedor>), typeof(GrabadorFoxTipoProveedor), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            this.Registrar(typeof(IGrabadorFox<Modelo.Logistica.ZonaLogistica>), typeof(GrabadorFoxZonaLogistica), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Logistica.ZonaGeografica>), typeof(GrabadorFoxZonaGeografica), new InyectaValor("Dao", typeof(DaoFoxPrueba)));


            this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Cobrador>), typeof(GrabadorFoxCobrador), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Preventista>), typeof(GrabadorFoxPreventista), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Supervisor>), typeof(GrabadorFoxSupervisor), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Vendedor>), typeof(GrabadorFoxVendedor), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            #endregion

            #region Grabadores Fox REAL

            //this.Registrar(typeof(IGrabadorFox<Core.Modelo.Locacion.Localidad>), typeof(GrabadorFoxLocalidad), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Core.Modelo.Locacion.Calle>), typeof(GrabadorFoxCalle), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Tesoreria.Banco>), typeof(GrabadorFoxBancos), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Canal>), typeof(GrabadorFoxCanal), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Ramo>), typeof(GrabadorFoxRamo), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Cliente>), typeof(GrabadorFoxClienteDobleReal));
            //this.Registrar(typeof(IGrabadorFox<GrupoCliente>), typeof(GrabadorFoxGrupoCliente), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<GeoRegionDeVenta>), typeof(GrabadorFoxGeoRegionDeVenta), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<RegionDeVenta>), typeof(GrabadorFoxRegionDeVenta), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<RutaDeVenta>), typeof(GrabadorFoxRutaDeVenta), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //actualmente en prueba
            //this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.DocumentoCompra>), typeof(GrabadorFoxDocumentoCompra), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Inteldev.Core.Modelo.Stock.Deposito>), typeof(GrabadorFoxDeposito), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Proveedor>), typeof(GrabadorFoxProveedor), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Proveedor>), typeof(GrabadorFoxProveedoresDobleReal));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Articulo>), typeof(GrabadorFoxArticulo), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Envase>), typeof(GrabadorFoxEnvase), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Linea>), typeof(GrabadorFoxLinea), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Rubro>), typeof(GrabadorFoxRubro), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Empaque>), typeof(GrabadorFoxEmpaque), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Caracteristica>), typeof(GrabadorFoxCaracteristica), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Marca>), typeof(GrabadorFoxMarcas), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Clase>), typeof(GrabadorFoxClase), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Division>), typeof(GrabadorFoxDivision), new InyectaValor("Dao", typeof(DaoFoxReal)));

            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Area>), typeof(GrabadorFoxArea), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Sector>), typeof(GrabadorFoxSector), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Subsector>), typeof(GrabadorFoxSubsector), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Familia>), typeof(GrabadorFoxFamilia), new InyectaValor("Dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Articulos.Subfamilia>), typeof(GrabadorFoxSubfamilia), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            //this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.Transportista>), typeof(GrabadorFoxTransportista), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Proveedores.TipoProveedor>), typeof(GrabadorFoxTipoProveedor), new InyectaValor("Dao", typeof(DaoFoxReal)));

            //this.Registrar(typeof(IGrabadorFox<Modelo.Logistica.ZonaLogistica>), typeof(GrabadorFoxZonaLogistica), new InyectaValor("Dao", typeof(DaoFoxPrueba)));

            //this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Cobrador>), typeof(GrabadorFoxCobrador), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Preventista>), typeof(GrabadorFoxPreventista), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Supervisor>), typeof(GrabadorFoxSupervisor), new InyectaValor("Dao", typeof(DaoFoxReal)));
            //this.Registrar(typeof(IGrabadorFox<Modelo.Preventa.Vendedor>), typeof(GrabadorFoxVendedor), new InyectaValor("Dao", typeof(DaoFoxReal)));
            #endregion

            #region MapeadorFox

            this.Registrar(typeof(IMapeadorFox<Area>), typeof(MapeadorAreasFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IMapeadorFox<Sector>), typeof(MapeadorSectoresFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IMapeadorFox<Subsector>), typeof(MapeadorSubSectoresFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IMapeadorFox<Familia>), typeof(MapeadorFamiliasFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IMapeadorFox<Subfamilia>), typeof(MapeadorSubfamiliasFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));

            //this.Registrar(typeof(IMapeadorFox<Articulo>), typeof(MapeadorArticulosFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            //this.Registrar(typeof(IMapeadorFox<Articulo>), typeof(MapeadorArticulosCompuestosFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));
            this.Registrar(typeof(IMapeadorFox<Envase>), typeof(MapeadorEnvasesFox), new InyectaValor("dao", typeof(DaoFoxPrueba)));


            #endregion

            #region Validadores

            this.Registrar(typeof(IValidador<RutaDeVenta>), typeof(ValidadorRutaDeVenta));
            this.Registrar(typeof(IValidador<>), typeof(ValidadorGenerico<>));
            this.Registrar(typeof(IValidador<DivisionComercial>), typeof(ValidadorDivisionComercial));
            this.Registrar(typeof(IValidador<GeoRegionDeVenta>), typeof(ValidadorGeoRegionDeVenta));
            this.Registrar(typeof(IValidador<RegionDeVenta>), typeof(ValidadorRegionDeVenta));
            this.Registrar(typeof(IValidador<Sector>), typeof(ValidadorSector));
            this.Registrar(typeof(IValidador<Subsector>), typeof(ValidadorSubsector));
            this.Registrar(typeof(IValidador<Familia>), typeof(ValidadorFamilia));
            this.Registrar(typeof(IValidador<Subfamilia>), typeof(ValidadorSubfamilia));
            //this.Registrar(typeof(IValidador<Cliente>), typeof(ValidadorCliente));

            #endregion

            #region Mapeadores Genericos: Encargados de pasar de Entidades a DTOs y viceversa

            this.Registrar(typeof(IMapeadorGenerico<,>), typeof(MapeadorGenerico<,>));
            this.Registrar(typeof(IMapeadorGenerico<Modelo.Precios.CambioDePreciosDeVenta, Servicios.DTO.Precios.CambioDePreciosDeVenta>), typeof(MapeadorCambioDePreciosDeVenta));
            this.Registrar(typeof(IMapeadorGenerico<Inteldev.Fixius.Modelo.Stock.Ingreso, Inteldev.Fixius.Servicios.DTO.Stock.Ingreso>), typeof(MapeadorIngreso));
            this.Registrar(typeof(IMapeadorGenerico<Modelo.Proveedores.ListaDePrecios, Servicios.DTO.Proveedores.ListaDePrecios>), typeof(MapeadorListaDePrecios));
            this.Registrar(typeof(IMapeadorGenerico<Modelo.Proveedores.OrdenDeCompra, Servicios.DTO.Proveedores.OrdenDeCompra>), typeof(MapeadorOrdenDeCompra));
            this.Registrar(typeof(IMapeadorGenerico<Modelo.Stock.Ingreso, Servicios.DTO.Stock.Ingreso>), typeof(MapeadorIngreso));
            //this.Registrar(typeof(IMapeadorGenerico<Modelo.Proveedores.OrdenDePago,Servicios.DTO.Proveedores.OrdenDePago>),typeof(MapeadorOrdenDePago));
            this.Registrar(typeof(IMapeadorGenerico<Modelo.Proveedores.OrdenDePago, Servicios.DTO.Proveedores.OrdenDePago>), typeof(MapeadorOrdenDePagoDataTable));

            #endregion


        }
    }
}
