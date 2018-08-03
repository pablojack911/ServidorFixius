using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios
{
    public class RegistroMapeos : RegistroDeMapeos
    {
        public override void Configurar()
        {
            this.ConfigurarMenu();
            this.ConfigurarArticulos();
            this.ConfigurarAuditoria();
            this.ConfigurarClientes();
            this.ConfigurarFinanciero();
            this.ConfigurarFiscal();
            this.ConfigurarLocacion();
            this.ConfigurarOrganizacion();
            this.ConfigurarProveedores();
            this.ConfigurarUsuarios();
            this.ConfigurarStock();
            this.ConfigurarListas();
            this.ConfigurarTesoreria();
            this.ConfigurarLogistica();
            this.ConfigurarContabilidad();
            this.ConfigurarPreventa();

            AutoMapper.Mapper.CreateMap<string, Empresa>().ConvertUsing<StringEmpresaConverter>();
            AutoMapper.Mapper.CreateMap<string, Sucursal>().ConvertUsing<StringSucursalConverter>();

            AutoMapper.Mapper.CreateMap<Core.DTO.Documento, Core.Modelo.Documento>()
                .ForMember(src => src.Empresa, conf => conf.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(x => x.Empresa.Codigo))
                .ForMember(src => src.Sucursal, conf => conf.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(x => x.Sucursal.Codigo));
            AutoMapper.Mapper.CreateMap<Core.Modelo.Documento, Core.DTO.Documento>()
                .ForMember(src => src.Empresa, conf => conf.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(x => x.Empresa))
                .ForMember(src => src.Empresa, conf => conf.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(x => x.Sucursal));
            //this.MapeoDtoToEntidad<Core.DTO.Documento, Core.Modelo.Documento>()
            //    .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));
            //this.MapeoEntidadToDto<Core.Modelo.Documento, Core.DTO.Documento>()
            //    .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));

            this.RegistrarBiDefault<Core.Modelo.ParametrosMiniBusca, Core.DTO.ParametrosMiniBusca>();
            this.RegistrarBiDefault<Fixius.Modelo.ConfiguraEmpresa, Fixius.Servicios.DTO.ConfiguraEmpresa>();
            this.RegistrarBiDefault<Fixius.Modelo.Contexto, Fixius.Servicios.DTO.Contexto>();
            this.RegistrarBiDefault<Fixius.Modelo.RelacionEmpresaEntidad, Fixius.Servicios.DTO.RelacionEmpresaEntidad>();
            //Mapper.AssertConfigurationIsValid();
        }

        private void ConfigurarPreventa()
        {
            this.RegistrarBiDefault<Modelo.Preventa.Pedido, Servicios.DTO.Preventa.Pedido>();
            this.MapeoDtoToEntidad<Servicios.DTO.Preventa.DetallePedido, Modelo.Preventa.DetallePedido>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.MapeoEntidadToDto<Modelo.Preventa.DetallePedido, Servicios.DTO.Preventa.DetallePedido>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Fixius.Modelo.Preventa.DatosOldPreventa, Fixius.Servicios.DTO.Preventa.DatosOldPreventa>();
            this.RegistrarBiDefault<Fixius.Modelo.Preventa.CoordenadaCliente, Servicios.DTO.Preventa.CoordenadaCliente>();
        }

        private void ConfigurarContabilidad()
        {
            //this.RegistrarBiDefault<Modelo.Contabilidad.ReferenciaContable, Servicios.DTO.Contabilidad.ReferenciaContable>();
            this.MapeoDtoToEntidad<Servicios.DTO.Contabilidad.ReferenciaContable, Modelo.Contabilidad.ReferenciaContable>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.MapeoEntidadToDto<Modelo.Contabilidad.ReferenciaContable, Servicios.DTO.Contabilidad.ReferenciaContable>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Contabilidad.Imputaciones, Inteldev.Core.DTO.Contabilidad.Imputaciones>();
            this.RegistrarBiDefault<Modelo.Contabilidad.TasasDeIva, Inteldev.Fixius.Servicios.DTO.Contabilidad.TasasDeIva>();
        }

        private void ConfigurarLogistica()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Coordenada, Inteldev.Core.DTO.Locacion.Coordenada>();
            this.RegistrarBiDefault<Modelo.Logistica.ZonaGeografica, Servicios.DTO.Logistica.ZonaGeografica>();
            this.RegistrarBiDefault<Modelo.Logistica.ZonaLogistica, Servicios.DTO.Logistica.ZonaLogistica>();
        }

        private void ConfigurarTesoreria()
        {
            this.RegistrarBiDefault<Modelo.Tesoreria.Banco, Servicios.DTO.Tesoreria.Banco>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Tesoreria.Valor, Inteldev.Core.DTO.Tesoreria.Valor>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Tesoreria.Efectivo, Inteldev.Core.DTO.Tesoreria.Efectivo>();
            this.RegistrarBiDefault<Modelo.Tesoreria.ChequePropio, Servicios.DTO.Tesoreria.ChequePropio>();
            this.MapeoDtoToEntidad<Servicios.DTO.Tesoreria.ChequeDeTercero, Modelo.Tesoreria.ChequeDeTercero>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.MapeoEntidadToDto<Modelo.Tesoreria.ChequeDeTercero, Servicios.DTO.Tesoreria.ChequeDeTercero>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Modelo.Tesoreria.MovimientoChequeTercero, Servicios.DTO.Tesoreria.MovimientoChequeTercero>();
            this.RegistrarBiDefault<Modelo.Tesoreria.DestinoChequeBanco, Servicios.DTO.Tesoreria.DestinoChequeBanco>();
            this.RegistrarBiDefault<Modelo.Tesoreria.DestinoChequeTercero, Servicios.DTO.Tesoreria.DestinoChequeTercero>();
            this.RegistrarBiDefault<Modelo.Tesoreria.DestinoProveedor, Servicios.DTO.Tesoreria.DestinoProveedor>();
            this.RegistrarBiDefault<Modelo.Tesoreria.OrigenChequeTercero, Servicios.DTO.Tesoreria.OrigenChequeTercero>();
            this.RegistrarBiDefault<Modelo.Tesoreria.OrigenChequeTerceroCliente, Servicios.DTO.Tesoreria.OrigenChequeTerceroCliente>();
            this.MapeoEntidadToDto<Modelo.Tesoreria.CuentaBancaria, Servicios.DTO.Tesoreria.CuentaBancaria>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.MapeoDtoToEntidad<Servicios.DTO.Tesoreria.CuentaBancaria, Modelo.Tesoreria.CuentaBancaria>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Modelo.Tesoreria.MovimientoBancario, DTO.Tesoreria.MovimientoBancario>();
            this.RegistrarBiDefault<Modelo.Tesoreria.ConceptoDeMovimientoBancario, DTO.Tesoreria.ConceptoDeMovimientoBancario>();
        }

        private void ConfigurarListas()
        {
            this.MapeoDtoToEntidad<Servicios.DTO.Precios.HabilitaLista, Modelo.Precios.HabilitaLista>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.MapeoEntidadToDto<Modelo.Precios.HabilitaLista, Servicios.DTO.Precios.HabilitaLista>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Precios.ListaDePreciosDeVenta, Inteldev.Fixius.Servicios.DTO.Precios.ListaDePreciosDeVenta>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Precios.ItemListaDePrecioDeVenta, Inteldev.Fixius.Servicios.DTO.Precios.ItemListaDePreciosDeVenta>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Precios.DescuentosPorLista, Inteldev.Fixius.Servicios.DTO.Precios.DescuentosPorLista>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Precios.ItemDescuentoPorLista, Inteldev.Fixius.Servicios.DTO.Precios.ItemDescuentoPorLista>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Precios.Descuento, Inteldev.Fixius.Servicios.DTO.Precios.Descuento>();
        }

        private void ConfigurarStock()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Stock.Deposito, Inteldev.Core.DTO.Stock.Deposito>();
            //this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Stock.ReciboStock, Inteldev.Fixius.Servicios.DTO.Stock.ReciboStock>(); // map empresa y sucursal
            this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Stock.ReciboStock, Inteldev.Fixius.Modelo.Stock.ReciboStock>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));
            this.MapeoEntidadToDto<Inteldev.Fixius.Modelo.Stock.ReciboStock, Inteldev.Fixius.Servicios.DTO.Stock.ReciboStock>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Stock.Movimiento, Inteldev.Fixius.Servicios.DTO.Stock.Movimiento>();
            this.MapeoEntidadToDto<Inteldev.Fixius.Modelo.Stock.Ingreso, Inteldev.Fixius.Servicios.DTO.Stock.Ingreso>()
                .ForMember(p => p.Items, q => q.Ignore());
            this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Stock.Ingreso, Inteldev.Fixius.Modelo.Stock.Ingreso>()
                .ForMember(p => p.Items, q => q.Ignore())
                .ForMember(p => p.ItemsNoIngresados, q => q.Ignore());
            this.MapeoDtoToEntidad<Modelo.Stock.ItemNoIngresado, Servicios.DTO.Stock.ItemNoIngresado>()
                .ForMember(p => p.ItemsNoIngresados, q => q.Ignore());
            this.MapeoEntidadToDto<Modelo.Stock.ItemNoIngresado, Servicios.DTO.Stock.ItemNoIngresado>()
                .ForMember(p => p.ItemsNoIngresados, q => q.Ignore());
            this.MapeoDtoToEntidad<Servicios.DTO.Stock.Movimiento, Modelo.Stock.Movimiento>().ForMember(p => p.DetalleMovimiento, q => q.Ignore());
            this.RegistrarBiDefault<Modelo.Proveedores.ItemsConceptos, Servicios.DTO.Proveedores.ItemsConceptos>();
            this.RegistrarBiDefault<Modelo.Stock.ConceptoDeMovimientoDeStock, Servicios.DTO.Stock.ConceptoDeMovimientoDeStock>();
        }

        private void ConfigurarMenu()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Menu.OpcionMenu, Inteldev.Core.DTO.Menu.OpcionMenu>();
        }

        #region Articulos

        private void ConfigurarArticulos()
        {
            this.RegistrarBiDefault<Modelo.Articulos.SKU, Servicios.DTO.Articulos.SKU>();
            this.RegistrarBiDefault<Modelo.Articulos.ObservacionArticulo, DTO.Articulos.ObservacionArticulo>();
            this.RegistrarBiDefault<Modelo.Articulos.Articulo, Inteldev.Fixius.Servicios.DTO.Articulos.Articulo>();
            this.RegistrarBiDefault<Modelo.Articulos.ArticuloCompuesto, Inteldev.Fixius.Servicios.DTO.Articulos.ArticuloCompuesto>();
            this.RegistrarBiDefault<Modelo.Articulos.Caracteristica, Inteldev.Fixius.Servicios.DTO.Articulos.Caracteristica>();
            this.RegistrarBiDefault<Modelo.Articulos.CodigoDun, Inteldev.Fixius.Servicios.DTO.Articulos.CodigoDun>();
            this.RegistrarBiDefault<Modelo.Articulos.CodigoEan, Inteldev.Fixius.Servicios.DTO.Articulos.CodigoEan>();
            this.RegistrarBiDefault<Modelo.Articulos.Empaque, Inteldev.Fixius.Servicios.DTO.Articulos.Empaque>();
            this.RegistrarBiDefault<Modelo.Articulos.Envase, Inteldev.Fixius.Servicios.DTO.Articulos.Envase>();
            this.RegistrarBiDefault<Modelo.Articulos.ArticuloEnvase, Inteldev.Fixius.Servicios.DTO.Articulos.ArticuloEnvase>();

            this.RegistrarBiDefault<Modelo.Articulos.GrupoArticulo, Inteldev.Fixius.Servicios.DTO.Articulos.GrupoArticulo>();
            this.RegistrarBiDefault<Modelo.Articulos.Marca, Inteldev.Fixius.Servicios.DTO.Articulos.Marca>();
            this.RegistrarBiDefault<Modelo.Articulos.UnidadDeMedida, Inteldev.Fixius.Servicios.DTO.Articulos.UnidadDeMedida>();
            this.RegistrarBiDefault<Modelo.Articulos.Categoria, Inteldev.Fixius.Servicios.DTO.Articulos.Categoria>();

            this.RegistrarBiDefault<Modelo.Articulos.Area, DTO.Articulos.Area>();
            this.RegistrarBiDefault<Modelo.Articulos.Sector, DTO.Articulos.Sector>();
            this.RegistrarBiDefault<Modelo.Articulos.Subsector, DTO.Articulos.Subsector>();
            this.RegistrarBiDefault<Modelo.Articulos.Familia, DTO.Articulos.Familia>();
            this.RegistrarBiDefault<Modelo.Articulos.Subfamilia, DTO.Articulos.Subfamilia>();
            this.RegistrarBiDefault<Modelo.Articulos.Clase, DTO.Articulos.Clase>();
            this.RegistrarBiDefault<Modelo.Articulos.Rubro, Servicios.DTO.Articulos.Rubro>();
            this.RegistrarBiDefault<Modelo.Articulos.Division, Servicios.DTO.Articulos.Division>();
            this.MapeoEntidadToDto<Modelo.Articulos.Linea, Servicios.DTO.Articulos.Linea>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            this.MapeoDtoToEntidad<Servicios.DTO.Articulos.Linea, Modelo.Articulos.Linea>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.RegistrarBiDefault<Modelo.Articulos.DatosOldArticulo, Servicios.DTO.Articulos.DatosOldArticulo>();
            //this.RegistrarBiDefault<Modelo.Articulos.DatosOldEnvases, Servicios.DTO.Articulos.DatosOldEnvases>();
            //this.ConfigurarArea();
            //this.ConfigurarSector();
            //this.ConfigurarSubSector();
            //this.ConfigurarFamilia();
            //this.ConfigurarSubFamilia();

        }

        private void ConfigurarArea()
        {
            //this.MapeoEntidadToDto<Modelo.Articulos.Area, DTO.Articulos.Area>()
            //	.ForMember(p => p.Nodos, opt => opt.MapFrom(a => a.Sectores))
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(1));

            //this.MapeoDtoToEntidad<DTO.Articulos.Area, Modelo.Articulos.Area>() 
            //	.ForMember(p => p.Sectores, opt => opt.MapFrom(a => a.Nodos));
        }

        private void ConfigurarSector()
        {
            this.MapeoEntidadToDto<Modelo.Articulos.Sector, DTO.Articulos.Sector>();
            //.ForMember(p => p.Area, o => o.Ignore());
            //.ForMember(p => p.Nodos, o => o.MapFrom(s => s.Subsectores))
            //.ForMember(p => p.Padre, opt => opt.Ignore())
            //.ForMember(p => p.Nivel, opt => opt.UseValue<int>(2));

            this.MapeoDtoToEntidad<DTO.Articulos.Sector, Modelo.Articulos.Sector>()
                .ForMember(p => p.Area, o => o.Ignore());
            //	.ForMember(p => p.Subsectores, o => o.MapFrom(s => s.Nodos));

            //this.MapeoEntidadToDto<Modelo.Articulos.Sector, DTO.Articulos.Sector>()
            //   .ForMember(p => p.Nodos, o => o.MapFrom(s => s.Subsectores))
            //   .ForMember(p => p.Padre, opt => opt.Ignore())
            //   .ForMember(p => p.Nivel, opt => opt.UseValue<int>(2));

            //this.MapeoDtoToEntidad<DTO.Articulos.Sector, Modelo.Articulos.Sector>()
            //	.ForMember(p => p.Subsectores, o => o.MapFrom(s => s.Nodos));
        }

        private void ConfigurarSubSector()
        {
            this.MapeoEntidadToDto<Modelo.Articulos.Subsector, DTO.Articulos.Subsector>();
            //.ForMember(p=> p.Sector, o=> o.Ignore());
            //	.ForMember(p => p.Nodos, o => o.MapFrom(s => s.Familias))
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(3));

            this.MapeoDtoToEntidad<DTO.Articulos.Subsector, Modelo.Articulos.Subsector>()
                .ForMember(p => p.Sector, o => o.Ignore());
            //	.ForMember(p => p.Familias, o => o.MapFrom(s => s.Nodos));

            //this.MapeoEntidadToDto<Modelo.Articulos.Subsector, DTO.Articulos.Subsector>()
            //	.ForMember(p => p.Nodos, opt => opt.MapFrom(s => s.Familias))
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(3));

            //this.MapeoDtoToEntidad<DTO.Articulos.Subsector, Modelo.Articulos.Subsector>()
            //	.ForMember(p => p.Familias, opt => opt.MapFrom(s => s.Nodos));
        }

        private void ConfigurarFamilia()
        {
            this.MapeoEntidadToDto<Modelo.Articulos.Familia, DTO.Articulos.Familia>();
            //.ForMember(p=>p.Subsector, O=>O.Ignore());
            //	.ForMember(p => p.Nodos, o => o.MapFrom(s => s.Subfamilias))
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(4));

            this.MapeoDtoToEntidad<DTO.Articulos.Familia, Modelo.Articulos.Familia>()
                .ForMember(p => p.Subsector, o => o.Ignore());
            //	.ForMember(p => p.Subfamilias, o => o.MapFrom(s => s.Nodos));

            //this.MapeoEntidadToDto<Modelo.Articulos.Familia, DTO.Articulos.Familia>()
            //	.ForMember(p => p.Nodos, opt => opt.MapFrom(s => s.Subfamilias))
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(4));

            //this.MapeoDtoToEntidad<DTO.Articulos.Familia, Modelo.Articulos.Familia>()
            //	.ForMember(p => p.Subfamilias, opt => opt.MapFrom(s => s.Nodos));
        }

        private void ConfigurarSubFamilia()
        {
            this.MapeoEntidadToDto<Modelo.Articulos.Subfamilia, DTO.Articulos.Subfamilia>();
            //.ForMember(p=>p.Familia,o=>o.Ignore());
            //	.ForMember(p => p.Nodos, o => o.Ignore())
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(5));

            this.MapeoDtoToEntidad<DTO.Articulos.Subfamilia, Modelo.Articulos.Subfamilia>()
                .ForMember(p => p.Familia, o => o.Ignore());

            //this.MapeoEntidadToDto<Modelo.Articulos.Subfamilia, DTO.Articulos.Subfamilia>()
            //	.ForMember(p => p.Nodos, o => o.Ignore())
            //	.ForMember(p => p.Padre, opt => opt.Ignore())
            //	.ForMember(p => p.Nivel, opt => opt.UseValue<int>(5));

            //this.MapeoDtoToEntidad<DTO.Articulos.Subfamilia, Modelo.Articulos.Subfamilia>();
        }

        #endregion

        #region Auditoria

        public void ConfigurarAuditoria()
        {
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.ObservacionProveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.ObservacionProveedor>();
        }

        #endregion

        #region Clientes

        public void ConfigurarClientes()
        {
            this.RegistrarBiDefault<Modelo.Clientes.Canal, DTO.Clientes.Canal>();
            this.RegistrarBiDefault<Modelo.Clientes.Cliente, DTO.Clientes.Cliente>();
            this.RegistrarBiDefault<Modelo.Clientes.GrupoCliente, DTO.Clientes.GrupoCliente>();
            this.RegistrarBiDefault<Modelo.Clientes.ObservacionCliente, DTO.Clientes.ObservacionCliente>();
            this.RegistrarBiDefault<Modelo.Clientes.Ramo, DTO.Clientes.Ramo>();
            this.RegistrarBiDefault<Modelo.Clientes.TarjetaClienteMayorista, DTO.Clientes.TarjetaClienteMayorista>();
            this.RegistrarBiDefault<Modelo.Clientes.TarjetaMayoristaItem, DTO.Clientes.TarjetaMayoristaItem>();
            this.RegistrarBiDefault<Core.Modelo.Organizacion.EmpresaCodigo, Core.DTO.Organizacion.EmpresaCodigo>();
            this.MapeoEntidadToDto<Modelo.Clientes.DatosOldCliente, Servicios.DTO.Clientes.DatosOldCliente>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));


            this.MapeoEntidadToDto<Modelo.Clientes.Cliente, Servicios.DTO.Clientes.ClienteBusqueda>();



            this.MapeoDtoToEntidad<Servicios.DTO.Clientes.DatosOldCliente, Modelo.Clientes.DatosOldCliente>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            this.MapeoEntidadToDto<Core.Modelo.Organizacion.DivisionComercial, Core.DTO.Organizacion.DivisionComercial>()
                .ForMember(p => p.Empresas, q => q.ResolveUsing(typeof(EmpresaResolverDTOColleccion)).FromMember(p => p.Empresas));
            this.MapeoDtoToEntidad<Core.DTO.Organizacion.DivisionComercial, Core.Modelo.Organizacion.DivisionComercial>()
                .ForMember(p => p.Empresas, q => q.ResolveUsing(typeof(EmpresaResolverEntidadColleccion)).FromMember(p => p.Empresas));
            this.RegistrarBiDefault<Modelo.Preventa.Jefe, Servicios.DTO.Preventa.Jefe>();
            this.RegistrarBiDefault<Modelo.Preventa.Supervisor, Servicios.DTO.Preventa.Supervisor>();
            this.RegistrarBiDefault<Modelo.Preventa.Preventista, Servicios.DTO.Preventa.Preventista>();
            this.RegistrarBiDefault<Modelo.Preventa.Cobrador, Servicios.DTO.Preventa.Cobrador>();
            this.RegistrarBiDefault<Modelo.Preventa.Vendedor, Servicios.DTO.Preventa.Vendedor>();
            this.RegistrarBiDefault<Modelo.Clientes.CargosDeFuerzaDeVenta, Servicios.DTO.Clientes.CargosDeFuerzaDeVenta>();
            //this.RegistrarBiDefault<Modelo.Clientes.OperariosDePreventa, Servicios.DTO.Clientes.OperariosDePreventa>();
            this.MapeoEntidadToDto<Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>()
                .ForMember(destino => destino.Empresa, option => option.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(r => r.Empresa));
            this.MapeoDtoToEntidad<Servicios.DTO.Clientes.RutaDeVenta, Modelo.Clientes.RutaDeVenta>()
                .ForMember(destino => destino.Empresa, optio => optio.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(r => r.Empresa));
            this.RegistrarBiDefault<Modelo.Clientes.DatosOldRutaDeVenta, Servicios.DTO.Clientes.DatosOldRutaDeVenta>();
            this.RegistrarBiDefault<Modelo.Clientes.DiasDeSemana, Servicios.DTO.Clientes.DiasDeSemana>();
            this.RegistrarBiDefault<Modelo.Clientes.ConfiguraCredito, Servicios.DTO.Clientes.ConfiguraCredito>();
            this.RegistrarBiDefault<Modelo.Clientes.CondicionDePagoCliente, Servicios.DTO.Clientes.CondicionDePagoCliente>();
            this.RegistrarBiDefault<Modelo.Clientes.DatosOldCondicionDePagoCliente, Servicios.DTO.Clientes.DatosOldCondicionDePagoCliente>();
            this.RegistrarBiDefault<Modelo.Preventa.Preventa, Servicios.DTO.Preventa.Preventa>();
            this.RegistrarBiDefault<Modelo.Clientes.RegionDeVenta, Servicios.DTO.Clientes.RegionDeVenta>();
            this.RegistrarBiDefault<Modelo.Clientes.GeoRegionDeVenta, Servicios.DTO.Clientes.GeoRegionDeVenta>();
        }

        #endregion

        #region Financiero

        public void ConfigurarFinanciero()
        {
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento>();
        }

        #endregion

        #region Fiscal

        public void ConfigurarFiscal()
        {
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB, Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA, Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIva>();
        }

        #endregion

        #region Locacion

        public void ConfigurarLocacion()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Contacto, Inteldev.Core.DTO.Locacion.Contacto>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Localidad, Inteldev.Core.DTO.Locacion.Localidad>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Provincia, Inteldev.Core.DTO.Locacion.Provincia>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Telefono, Inteldev.Core.DTO.Locacion.Telefono>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Calle, Inteldev.Core.DTO.Locacion.Calle>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Locacion.Domicilio, Inteldev.Core.DTO.Locacion.Domicilio>();
        }

        #endregion

        #region Organizacion

        public void ConfigurarOrganizacion()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Organizacion.UnidadeDeNegocio, Inteldev.Core.DTO.Organizacion.UnidadeDeNegocio>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Organizacion.Sucursal, Inteldev.Core.DTO.Organizacion.Sucursal>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Organizacion.DivisionComercial, Inteldev.Core.DTO.Organizacion.DivisionComercial>();
        }

        #endregion

        #region Proveedores

        public void ConfigurarProveedores()
        {
            this.RegistrarBiDefault<Modelo.Proveedores.ObservacionProveedor, DTO.Proveedores.ObservacionProveedor>();
            this.RegistrarBiDefault<Modelo.Proveedores.CondicionDePagoProveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.CondicionDePagoProveedor>();
            this.RegistrarBiDefault<Modelo.Proveedores.Entrega, Inteldev.Fixius.Servicios.DTO.Proveedores.Entrega>();
            this.RegistrarBiDefault<Modelo.Proveedores.EstadoProveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.EstadoProveedor>();
            this.RegistrarBiDefault<Modelo.Proveedores.FormaDePago, Inteldev.Fixius.Servicios.DTO.Proveedores.FormaDePago>();
            this.RegistrarBiDefault<Modelo.Proveedores.ListaDePrecios, Inteldev.Fixius.Servicios.DTO.Proveedores.ListaDePrecios>();
            this.RegistrarBiDefault<Modelo.Proveedores.Proveedor, DTO.Proveedores.Proveedor>();
            this.RegistrarBiDefault<Modelo.Proveedores.PlantillaListaProveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.PlantillaListaProveedor>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.Objetivos, Inteldev.Fixius.Servicios.DTO.Proveedores.Objetivos>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.ObjetivosDeCompra, Inteldev.Fixius.Servicios.DTO.Proveedores.ObjetivosDeCompra>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.ColorColumnaPlantilla, Inteldev.Fixius.Servicios.DTO.Proveedores.ColorColumnaPlantilla>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Auditoria.Observacion, Inteldev.Core.DTO.Auditoria.Observacion>();
            this.MapeoEntidadToDto<Modelo.Proveedores.DevolucionDeMercaderia, Servicios.DTO.Proveedores.DevolucionDeMercaderia>().ForMember(p => p.Detalle, q => q.Ignore());
            this.MapeoDtoToEntidad<Servicios.DTO.Proveedores.DevolucionDeMercaderia, Modelo.Proveedores.DevolucionDeMercaderia>().ForMember(p => p.Detalle, q => q.Ignore());
            this.ConfigurarColumnas();
            this.ConfigurarListaDePrecios();
            this.ConfigurarOrdenDeCompra();
            this.RegistrarBiDefault<Modelo.Proveedores.Motivo, Servicios.DTO.Proveedores.Motivo>();
            this.RegistrarBiDefault<Modelo.Proveedores.Transportista, Servicios.DTO.Proveedores.Transportista>();
            this.RegistrarBiDefault<Modelo.Proveedores.DatosOldProveedor, Servicios.DTO.Proveedores.DatosOldProveedor>();
            this.RegistrarBiDefault<Modelo.Proveedores.TipoProveedor, Servicios.DTO.Proveedores.TipoProveedor>();

            AutoMapper.Mapper.CreateMap<DTO.Proveedores.DocumentoProveedor, Modelo.Proveedores.DocumentoProveedor>()
                    .IncludeBase<Core.DTO.Documento, Core.Modelo.Documento>();
            AutoMapper.Mapper.CreateMap<Modelo.Proveedores.DocumentoProveedor, DTO.Proveedores.DocumentoProveedor>()
                .IncludeBase<Core.Modelo.Documento, Core.DTO.Documento>();

            //this.RegistrarBiDefault<Modelo.Proveedores.DocumentoProveedor, Servicios.DTO.Proveedores.DocumentoProveedor>();
            //this.MapeoDtoToEntidad<Servicios.DTO.Proveedores.DocumentoProveedor, Modelo.Proveedores.DocumentoProveedor>()
            //   .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //this.MapeoDtoToEntidad<Servicios.DTO.Proveedores.DocumentoProveedor, Modelo.Proveedores.DocumentoProveedor>()
            //   .ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));

            //this.MapeoEntidadToDto<Modelo.Proveedores.DocumentoProveedor, Servicios.DTO.Proveedores.DocumentoProveedor>()
            //    .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //this.MapeoEntidadToDto<Modelo.Proveedores.DocumentoProveedor, Servicios.DTO.Proveedores.DocumentoProveedor>()
            //    .ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));

            this.RegistrarBiDefault<Modelo.Proveedores.OrdenDePago, Servicios.DTO.Proveedores.OrdenDePago>();
            this.RegistrarBiDefault<Modelo.Proveedores.Aplicacion, Servicios.DTO.Proveedores.Aplicacion>();

            this.MapeoDtoToEntidad<Servicios.DTO.Proveedores.OrdenDePago, Modelo.Proveedores.OrdenDePago>()
                .ForMember(p => p.Aplicaciones, q => q.Ignore())
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));
            this.MapeoEntidadToDto<Modelo.Proveedores.OrdenDePago, Servicios.DTO.Proveedores.OrdenDePago>()
                .ForMember(p => p.Detalle, q => q.Ignore())
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));

            AutoMapper.Mapper.CreateMap<DTO.Proveedores.DocumentoCompra, Modelo.Proveedores.DocumentoCompra>()
                    .IncludeBase<DTO.Proveedores.DocumentoProveedor, Modelo.Proveedores.DocumentoProveedor>();
            AutoMapper.Mapper.CreateMap<Modelo.Proveedores.DocumentoCompra, DTO.Proveedores.DocumentoCompra>()
                .IncludeBase<Modelo.Proveedores.DocumentoProveedor, DTO.Proveedores.DocumentoProveedor>();

            //this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra, Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>();
            //this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra, Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra>()
            //   .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra, Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra>()
            //    .ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));
            //this.MapeoEntidadToDto<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra, Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>()
            //    .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //this.MapeoEntidadToDto<Inteldev.Fixius.Modelo.Proveedores.DocumentoCompra, Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>()
            //    .ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));
            //this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra, Modelo.Proveedores.DocumentoCompra>()
            //    .IncludeBase<Core.DTO.Documento, Core.Modelo.Documento>();
            //this.MapeoEntidadToDto<Modelo.Proveedores.DocumentoCompra,Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>()
            //    .IncludeBase<Core.Modelo.Documento,Core.DTO.Documento>();


            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.ProntoPago, Inteldev.Fixius.Servicios.DTO.Proveedores.ProntoPago>();
            this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.ResponsablesCompras, Inteldev.Fixius.Servicios.DTO.Proveedores.ResponsablesCompras>();
            //this.RegistrarBiDefault<Inteldev.Fixius.Modelo.Proveedores.NotaPendiente, Inteldev.Fixius.Servicios.DTO.Proveedores.NotaPendiente>();
            this.MapeoDtoToEntidad<Inteldev.Fixius.Servicios.DTO.Proveedores.NotaPendiente, Inteldev.Fixius.Modelo.Proveedores.NotaPendiente>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverDTO)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverDTO)).FromMember(p => p.Sucursal));
            this.MapeoEntidadToDto<Inteldev.Fixius.Modelo.Proveedores.NotaPendiente, Inteldev.Fixius.Servicios.DTO.Proveedores.NotaPendiente>()
                .ForMember(p => p.Empresa, q => q.ResolveUsing(typeof(EmpresaResolverEntidad)).FromMember(p => p.Empresa));
            //.ForMember(p => p.Sucursal, q => q.ResolveUsing(typeof(SucursalResolverEntidad)).FromMember(p => p.Sucursal));

        }

        private void ConfigurarOrdenDeCompra()
        {
            this.MapeoEntidadToDto<Modelo.Proveedores.OrdenDeCompraDetalle, DTO.Proveedores.OrdenDeCompraDetalle>()
                .ForAllMembers(m => m.Ignore());
            this.MapeoEntidadToDto<Modelo.Proveedores.OrdenDeCompra, DTO.Proveedores.OrdenDeCompra>()
                .ForMember(m => m.Detalle, c => c.Ignore())
                .ForMember(m => m.Columnas, c => c.Ignore());
            this.MapeoDtoToEntidad<DTO.Proveedores.OrdenDeCompra, Modelo.Proveedores.OrdenDeCompra>()
                .ForMember(m => m.Detalle, c => c.Ignore());
            this.RegistrarBiDefault<Modelo.Proveedores.OrdenDeCompra, DTO.Proveedores.OrdenDeCompra>();
        }

        private void ConfigurarColumnas()
        {
            this.MapeoEntidadToDto<Modelo.Proveedores.Columna, DTO.Proveedores.Columna>()
                .ForMember(m => m.Id, c => c.MapFrom(d => d.Id))
                .ForMember(m => m.Nombre, c => c.MapFrom(d => d.Nombre))
                .ForMember(m => m.Orden, c => c.MapFrom(d => d.Orden))
                .ForMember(m => m.TipoColumna, c => c.MapFrom(d => Enum.Parse(typeof(DTO.Proveedores.TipoColumna), d.TipoColumna)));

            this.MapeoDtoToEntidad<DTO.Proveedores.Columna, Modelo.Proveedores.Columna>()
                .ForMember(m => m.Id, c => c.MapFrom(d => d.Id))
                .ForMember(m => m.Nombre, c => c.MapFrom(d => d.Nombre))
                .ForMember(m => m.Orden, c => c.MapFrom(d => d.Orden))
                .ForMember(m => m.TipoColumna, c => c.MapFrom(d => d.TipoColumna.ToString()));
        }

        private void ConfigurarListaDePrecios()
        {
            this.MapeoEntidadToDto<Modelo.Proveedores.ListaDePrecios, DTO.Proveedores.ListaDePrecios>()
                .ForMember(m => m.Id, c => c.MapFrom(d => d.Id))
                .ForMember(m => m.Nombre, c => c.MapFrom(d => d.Nombre))
                .ForMember(m => m.Proveedor, c => c.MapFrom(d => d.Proveedor))
                .ForMember(m => m.Vigencia, c => c.MapFrom(d => d.Vigencia))
                .ForMember(m => m.Observaciones, c => c.MapFrom(d => d.Observaciones))
                .ForMember(m => m.Columnas, c => c.Ignore())
                .ForMember(m => m.Detalle, c => c.Ignore());

            this.MapeoDtoToEntidad<DTO.Proveedores.ListaDePrecios, Modelo.Proveedores.ListaDePrecios>()
                .ForMember(m => m.Id, c => c.MapFrom(d => d.Id))
                .ForMember(m => m.Nombre, c => c.MapFrom(d => d.Nombre))
                .ForMember(m => m.Proveedor, c => c.MapFrom(d => d.Proveedor))
                .ForMember(m => m.Vigencia, c => c.MapFrom(d => d.Vigencia))
                .ForMember(m => m.Observaciones, c => c.Ignore())
                .ForMember(m => m.Detalle, c => c.Ignore());


            this.RegistrarBiDefault<Modelo.Proveedores.ObservacionProveedor, DTO.Proveedores.ObservacionProveedor>();

        }
        #endregion

        #region Usuarios

        private void ConfigurarUsuarios()
        {
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Usuarios.Usuario, Inteldev.Core.DTO.Usuarios.Usuario>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Usuarios.PerfilUsuario, Inteldev.Core.DTO.Usuarios.PerfilUsuario>();
            this.RegistrarBiDefault<Inteldev.Core.Modelo.Usuarios.Permiso, Inteldev.Core.DTO.Usuarios.Permiso>();
        }

        #endregion
    }
}
