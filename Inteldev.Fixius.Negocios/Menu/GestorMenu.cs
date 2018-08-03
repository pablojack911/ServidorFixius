using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Menu;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Negocios.Menu;
using Inteldev.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Inteldev.Core.DTO;

namespace Inteldev.Fixius.Negocios.Menu
{

    public class GestorMenu : LogicaDeNegociosBase<OpcionMenu>, IGestorMenu
    {

        private int contadorEntradas;

        protected OpcionMenu raiz;

        public GestorMenu()
            : base()
        {
            this.Crear();
        }

        protected void CargaGeneral()
        {
            raiz = CrearMenu("Raiz");
            var m = agregarEntrada(raiz, "Administración Central");
            agregarEntrada(m, "Tabla de Empresas");
            agregarEntrada(m, "Tabla de Sucursales");
            agregarEntrada(m, "Tabla de Divisiones Comerciales");
            agregarEntrada(m, "Tabla de Perfiles de Usuario");
            agregarEntrada(m, "Tabla de Usuarios");
            agregarEntrada(m, "Auditoria");
            agregarEntrada(m, "Tabla de Provincias");
            agregarEntrada(m, "Tabla de Localidades");
            agregarEntrada(m, "Tabla de Calles");

            var c = agregarEntrada(raiz, "Proveedores");
            agregarEntrada(c, "Maestro de Proveedores");
            var a = agregarEntrada(c, "Tablas de Proveedores");
            agregarEntrada(a, "Responsables de Autorización de Compras");
            agregarEntrada(a, "Tabla de Condiciones de Pago");
            agregarEntrada(a, "Tabla de Condiciones de Entrega");
            agregarEntrada(a, "Tabla Tipos De Proveedor");
            var compras = agregarEntrada(c, "Compras");
            agregarEntrada(compras, "Plantilla de Listas de Precios");
            agregarEntrada(compras, "Tabla de Listas de Precios de Proveedor");
            agregarEntrada(compras, "Simulador De Precios ");
            agregarEntrada(compras, "Orden de Compra");
            agregarEntrada(compras, "Planilla de Abastecimiento");
            agregarEntrada(compras, "Objetivos de Compra");
            agregarEntrada(compras, "Tabla de Colores");
            var cuentas = agregarEntrada(c, "Cuentas a Pagar");
            agregarEntrada(cuentas, "Carga de Comprobantes");
            agregarEntrada(cuentas, "Liquidación de Proveedores");
            agregarEntrada(cuentas, "Ordenes de Pago");

            var articulo = agregarEntrada(raiz, "Artículos");
            agregarEntrada(articulo, "Maestro de Artículos");
            var tablaArt = agregarEntrada(articulo, "Tablas de Artículos");
            agregarEntrada(tablaArt, "Tabla de SKU");
            agregarEntrada(tablaArt, "Tabla de Empaques");
            agregarEntrada(tablaArt, "Tabla de Envases");
            agregarEntrada(tablaArt, "Tabla de Caracteristicas");
            agregarEntrada(tablaArt, "Tabla de Marcas");
            agregarEntrada(tablaArt, "Tabla de Categorias");
            agregarEntrada(tablaArt, "Tabla de Grupos de Artículos");
            //agregarEntrada(tablaArt, "Tabla de Tasas de IVA");
            agregarEntrada(tablaArt, "Tabla de Clases");
            agregarEntrada(tablaArt, "Tabla de Rubros");
            agregarEntrada(tablaArt, "Tabla de Division");
            agregarEntrada(tablaArt, "Tabla de Lineas");
            var tablaAreas = agregarEntrada(articulo, "Areas");
            agregarEntrada(tablaAreas, "Tabla de Areas");
            agregarEntrada(tablaAreas, "Tabla de Sectores");
            agregarEntrada(tablaAreas, "Tabla de Subsectores");
            agregarEntrada(tablaAreas, "Tabla de Familias");
            agregarEntrada(tablaAreas, "Tabla de Subfamilias");

            var eC = agregarEntrada(raiz, "Clientes");
            agregarEntrada(eC, "Maestro de Clientes");
            var tabla = agregarEntrada(eC, "Tablas de Clientes");
            agregarEntrada(tabla, "Tabla de Tarjetas Mayorista");
            agregarEntrada(tabla, "Tabla de Canales");
            agregarEntrada(tabla, "Tabla de Ramos");
            agregarEntrada(tabla, "Tabla de Grupos de Clientes");
            agregarEntrada(tabla, "Tabla de Condiciónes de Pago");

            var p = agregarEntrada(raiz, "Preventa");
            var fuerza = agregarEntrada(p, "Fuerza De Venta");
            agregarEntrada(fuerza, "Geolocalización");
            agregarEntrada(fuerza, "Tabla de Jefes");
            agregarEntrada(fuerza, "Tabla de Supervisores");
            agregarEntrada(fuerza, "Tabla de Preventistas");
            agregarEntrada(fuerza, "Tabla de Operarios de Venta");
            agregarEntrada(fuerza, "Tabla Cargos Fuerza de Venta");
            agregarEntrada(fuerza, "Tabla de Cobradores");
            agregarEntrada(fuerza, "Tabla de Vendedores");

            var rutas = agregarEntrada(p, "Administración de Rutas");
            agregarEntrada(rutas, "GeoRegiones");
            agregarEntrada(rutas, "Regiones");
            agregarEntrada(rutas, "Rutas de Ventas");
            agregarEntrada(rutas, "Zonas Geográficas");

            var pedidos = agregarEntrada(raiz, "Pedidos");
            agregarEntrada(pedidos, "Carga de Pedidos");
            agregarEntrada(pedidos, "Autorizaciones");

            var gp = agregarEntrada(raiz, "Gestión de Precios");
            agregarEntrada(gp, "Listas de Precios");
            agregarEntrada(gp, "Descuentos por Lista");
            agregarEntrada(gp, "Habilitación de Listas");
            agregarEntrada(gp, "Ofertas");
            agregarEntrada(gp, "Convenios");

            var f = agregarEntrada(raiz, "Facturacion");
            agregarEntrada(f, "Emisión de Comprobantes");

            var d = agregarEntrada(raiz, "Deposito");
            agregarEntrada(d, "Tabla de Depositos");
            agregarEntrada(d, "Recepción de Mercaderia");
            agregarEntrada(d, "Devolución de Mercaderia");
            agregarEntrada(d, "ConceptoDeMovimientoDeStock");

            var tesoreria = agregarEntrada(raiz, "Tesoreria");
            agregarEntrada(tesoreria, "Tabla de Bancos");
            agregarEntrada(tesoreria, "Tabla de Conceptos De Movimiento");
            agregarEntrada(tesoreria, "Tabla de Cheques de Terceros");
            agregarEntrada(tesoreria, "Cuentas Bancarias");
            agregarEntrada(tesoreria, "Concepto De Movimiento Bancario");

            var logistica = agregarEntrada(raiz, "Logística y Distribución");
            agregarEntrada(logistica, "Tabla de Transportistas");
            agregarEntrada(logistica, "Armado de Reparto");
            agregarEntrada(logistica, "Hoja de Precarga");
            agregarEntrada(logistica, "Liquidación de Repartos");
            agregarEntrada(logistica, "Zonas Logísticas");
        }

        public virtual void Crear()
        {
            this.CargaGeneral();


        }

        protected OpcionMenu agregarEntrada(OpcionMenu menu, string nombre)
        {
            if (menu.Opciones == null)
                menu.Opciones = new List<OpcionMenu>();
            var opcion = CrearEntradaMenu(nombre);
            menu.Opciones.Add(opcion);
            return opcion;
        }

        protected OpcionMenu CrearMenu(string nombre)
        {
            contadorEntradas++;
            return new OpcionMenu() { Nombre = nombre, Modulo = "", Icono = "", Atajo = "" };
        }

        protected OpcionMenu CrearEntradaMenu(string nombre)
        {
            contadorEntradas++;
            return new OpcionMenu() { Nombre = nombre };
        }

        public virtual List<Inteldev.Core.DTO.Menu.OpcionMenu> Obtener()
        {
            var result = new List<Inteldev.Core.Modelo.Menu.OpcionMenu>();
            result.Add(raiz);
            return Mapeador.Instancia.ListaToDto<Inteldev.Core.DTO.Menu.OpcionMenu, Inteldev.Core.Modelo.Menu.OpcionMenu>(result);
        }

    }
}
