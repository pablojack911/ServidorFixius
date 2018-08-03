using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Inteldev.Fixius.Modelo.Articulos;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class RegistroMapeadores
    {
        public ObservableCollection<Mapeador> Mapeadores { get; set; }

        public RegistroMapeadores()
        {
            this.Mapeadores = new ObservableCollection<Mapeador>();
            var empresa = "01";
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", empresa);
            //INICIO MAPEADORES

            parameters[1] = new ParameterOverride("entidad", "PadronIIBB");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Padron IIBB", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorPadronIIBB), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Empresa");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Empresa", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorEmpresaFox), parameters), Seleccionado = true });

            #region Mapeador Locacion

            //parameters[1] = new ParameterOverride("entidad", "Calle");
            //this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Calle", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorCallesFox), parameters), Seleccionado = true });

            //parameters[1] = new ParameterOverride("entidad", "Localidad");
            //this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Localidad", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorLocalidadFox), parameters), Seleccionado = true });

            #endregion

            #region Mapeadores Simples (Codigo, Nombre)
            //parameters[1] = new ParameterOverride("entidad", "Zonas Geograficas");
            //this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Zonas Geograficas", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorZonasGeograficasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Zonas Logisticas");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Zonas Logísticas", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorZonasLogisticasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Deposito");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Deposito", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorDepositosFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "ListaDePreciosDeVenta");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Lista De Precios De Venta", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorListaDePreciosDeVentaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Empaque");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Empaques", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorEmpaquesFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Caracteristica");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Caracteristicas", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorCaracteristicasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Marca");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Marcas", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorMarcasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Clase");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Clases", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorClasesFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Division");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Divisiones Articulo", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorDivisionesArticuloFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Banco");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Bancos", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorBancosFox), parameters), Seleccionado = true });

            //parameters[1] = new ParameterOverride("entidad", "DivisionComercial");
            //this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador DivicionComercial", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorDivisionesComerciales), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Canal");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Canal", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorCanalesFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Ramo");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Ramo", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorRamosFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "ConceptosDeMovimiento");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Conceptos De Movimiento", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorConceptosDeMovimientoFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "TipoProveedor");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Tipo Proveedor", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorTipoProveedorFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Transportista");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Transportista", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorTransportistasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "GrupoCliente");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Grupo Cliente", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorGrupoClienteFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Area");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Area", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Area>), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Sector");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Sector", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Sector>), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Subsector");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Subsector", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Subsector>), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Familia");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Familia", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Familia>), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Subfamilia");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Subfamilia", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Subfamilia>), parameters), Seleccionado = true });
            #endregion

            #region Mapeador entidad Preventa

            parameters[1] = new ParameterOverride("entidad", "GeoRegionDeVenta");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador GeoRegion de Venta", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorGeoRegionDeVentaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "RegionDeVenta");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Region De Venta", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorRegionDeVentaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Preventista");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Preventista", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorPreventistasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Cobrador");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Cobradores", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorCobradoresFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Vendedor");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Vendedor", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorVendedoresFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Supervisor");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Supervisores", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorSupervisoresFox), parameters), Seleccionado = true });

            #endregion

            #region Mapeadores Complejos

            parameters[1] = new ParameterOverride("entidad", "TarjetaClienteMayorista");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador TarjetaClienteMayorista", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorTarjetasClienteMayoristaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "HeredaTarjetaClienteMayorista");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador HeredaTarjetaClienteMayorista", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorHeredaTarjetasClienteMayoristaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "CondicionDePagoCliente");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador CondicionDePagoCliente", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorCondicionesDePagoClienteFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Linea");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Linea", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorLineaFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Rubro");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Rubro", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorRubrosFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Cliente");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Cliente", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorClientesFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "RutaDeVenta");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador RutaDeVenta", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorRutaVentasFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Proveedor");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Proveedores", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorProveedoresFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "ReferenciaContable");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Referencia Contable", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorReferenciaContableFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Articulo");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Articulo", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorArticulosFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Articulo Compuesto");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Articulo Compuesto", Objeto = FabricaNegocios.Instancia.Resolver(typeof(MapeadorArticulosCompuestosFox), parameters), Seleccionado = true });

            parameters[1] = new ParameterOverride("entidad", "Envase");
            this.Mapeadores.Add(new Mapeador() { Nombre = "Mapeador Envase", Objeto = FabricaNegocios.Instancia.Resolver(typeof(IMapeadorFox<Envase>), parameters), Seleccionado = true });

            #endregion
        }
    }
}