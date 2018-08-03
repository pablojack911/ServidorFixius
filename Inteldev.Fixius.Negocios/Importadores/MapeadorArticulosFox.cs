using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Contabilidad;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorArticulosFox : MapeadorFox<Articulo>
    {

        BuscadorSubfamilia buscadorSubfamilia;
        BuscadorFamilia buscadorFamilia;
        BuscadorSubsector buscadorSubsector;
        BuscadorSector buscadorSector;
        public MapeadorArticulosFox(IDao con, string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.Inicializador("Articulo", "select * from articulo where codigo<>' ' and empty(entero) and empty(entero2) AND !EMPTY(descrip) ORDER BY codigo", "codigo", con);

            //Buscador para SubFamilia 
            ParameterOverride[] parSubFlia = new ParameterOverride[2];
            parSubFlia[0] = new ParameterOverride("empresa", empresa);
            parSubFlia[1] = new ParameterOverride("entidad", "familia");
            this.buscadorSubfamilia = (BuscadorSubfamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subfamilia>), parSubFlia);

            //Buscador para Familia 
            ParameterOverride[] parFlia = new ParameterOverride[2];
            parFlia[0] = new ParameterOverride("empresa", empresa);
            parFlia[1] = new ParameterOverride("entidad", "familia");
            this.buscadorFamilia = (BuscadorFamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Familia>), parFlia);

            //Buscador para Subsector
            ParameterOverride[] parSubSec = new ParameterOverride[2];
            parSubSec[0] = new ParameterOverride("empresa", empresa);
            parSubSec[1] = new ParameterOverride("entidad", "Subsector");
            this.buscadorSubsector = (BuscadorSubsector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Articulos.Subsector>), parSubSec);

            //Instanciacion del buscador para Sector
            ParameterOverride[] parSector = new ParameterOverride[2];
            parSector[0] = new ParameterOverride("empresa", empresa);
            parSector[1] = new ParameterOverride("entidad", "Sector");
            this.buscadorSector = (BuscadorSector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Articulos.Sector>), parSubSec);
        }
        protected override Articulo Mapear(Articulo entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["descrip"].ToString().Trim();
            entidad.NombreBreve = registro["descrip_ticket"].ToString().Trim();
            entidad.CodigoDelProveedor = registro["codigoorig"].ToString().Trim();

            entidad.Proveedor = this.BuscarEntidadPorCodigo<Proveedor>(registro["proveedor"].ToString().Trim());

            entidad.Marca = this.BuscarEntidadPorCodigo<Marca>(registro["marca"].ToString().Trim());

            entidad.Empaque = this.BuscarEntidadPorCodigo<Empaque>(registro["empaque"].ToString().Trim());

            var estado = registro["estado"].ToString().Trim();
            if (estado == "1")
                entidad.Estado = EstadoArticulo.Activo;
            else
                if (estado == "2")
                    entidad.Estado = EstadoArticulo.Suspendido;
                else
                    entidad.Estado = EstadoArticulo.Inactivo;

            entidad.Caracteristica = this.BuscarEntidadPorCodigo<Caracteristica>(registro["caracteristica"].ToString().Trim());

            entidad.VentaPorPeso = this.ObtenerBoolDeString(registro["ventaporpeso"].ToString().Trim());
            entidad.EsEnvase = this.ObtenerBoolDeString(registro["esenvase"].ToString().Trim());

            #region Area-Sector-SubSector-Familia-SubFamilia

            var codigoArea = registro["area"].ToString().Trim();
            var codigoSector = registro["sector"].ToString().Trim();
            var codigoSubsector = registro["subsector"].ToString().Trim();
            var codigoFamilia = registro["familia"].ToString().Trim();
            var codigoSubfamilia = registro["subfamilia"].ToString().Trim();

            entidad.Area = this.BuscarEntidadPorCodigo<Area>(codigoArea);

            if (entidad.Area != null) //seguimos con la carga de datos si area no es null
            {
                entidad.Sector = buscadorSector.ObtenerSector(codigoSector, codigoArea);
                if (entidad.Sector != null) //seguimos hacia abajo
                {
                    entidad.Subsector = buscadorSubsector.ObtenerSubsector(codigoSubsector, entidad.Sector.Id);
                    if (entidad.Subsector != null) //seguimos hacia abajo
                    {
                        entidad.Familia = buscadorFamilia.ObtenerFamilia(codigoFamilia, entidad.Subsector.Id);
                        if (entidad.Familia != null) //ultimo escalón
                        {
                            entidad.Subfamilia = buscadorSubfamilia.ObtenerSubfamilia(codigoSubfamilia, entidad.Familia.Id);
                        }
                    }
                }
            }

            #endregion

            entidad.Envase = this.BuscarEntidadPorCodigo<Envase>(registro["vacio"].ToString().Trim());

            var tasaIva = registro["modiva"].ToString().Trim();
            if (tasaIva == "1")
                entidad.TasaDeIVA = EnumTasas.General;
            else
                entidad.TasaDeIVA = EnumTasas.Reducida;

            #region Lista Codigos DUN

            var pallet = registro["cant_palet"].ToString().Trim();
            var cantbase = registro["cant_base"].ToString().Trim();
            var altura = registro["altura"].ToString().Trim();

            this.MapearCodigosDun(entidad, pallet, cantbase, altura);

            #endregion

            #region Lista Codigos EAN

            var bulto = registro["unidxbult"].ToString().Trim();
            var pack = registro["fraccion"].ToString().Trim();

            this.MapearCodigosEan(entidad, bulto, pack);

            #endregion

            #region DatosOld

            if (entidad.DatosOld == null)
                entidad.DatosOld = new DatosOldArticulo();
            entidad.DatosOld.Linea = this.BuscarEntidadPorCodigo<Linea>(registro["linea"].ToString().Trim());

            entidad.DatosOld.Rubro = this.BuscarEntidadPorCodigo<Rubro>(registro["rubro"].ToString().Trim());

            entidad.DatosOld.Clase = this.BuscarEntidadPorCodigo<Clase>(registro["clase"].ToString().Trim());

            entidad.DatosOld.Division = this.BuscarEntidadPorCodigo<Division>(registro["divunilever"].ToString().Trim());

            entidad.DatosOld.SKU = this.BuscarEntidadPorCodigo<SKU>(registro["sku"].ToString().Trim());

            entidad.DatosOld.ArticuloEnvase = this.BuscarEntidadPorCodigo<Articulo>(registro["env_art"].ToString().Trim());

            var minimovta = registro["minimovta"].ToString().Trim();
            entidad.DatosOld.MinimoDeVenta = minimovta == "" ? 0 : Int32.Parse(minimovta);

            entidad.DatosOld.ContenidoPorUnidad = registro["contenido"].ToString().Trim();

            entidad.DatosOld.ExcluirConvenioClienteZ = this.ObtenerBoolDeString(registro["exclu_tomadesc"].ToString().Trim());
            entidad.DatosOld.NoValorizar = this.ObtenerBoolDeString(registro["novalorizar"].ToString().Trim());
            entidad.DatosOld.ControlStock = this.ObtenerBoolDeString(registro["ctrl_stock"].ToString().Trim());
            entidad.DatosOld.NoVenderPorPreventa = this.ObtenerBoolDeString(registro["nopreventa"].ToString().Trim());
            entidad.DatosOld.ExclusivoMayorista = this.ObtenerBoolDeString(registro["exclu_ciers"].ToString().Trim());
            entidad.DatosOld.NoIncluirEnPreventa = this.ObtenerBoolDeString(registro["preventa"].ToString().Trim());
            entidad.DatosOld.NoRecibirPedidos = this.ObtenerBoolDeString(registro["continua"].ToString().Trim());
            entidad.DatosOld.NoRecibirPedidosCadenas = this.ObtenerBoolDeString(registro["suspcad"].ToString().Trim());
            entidad.DatosOld.NoRecibirPedidosInterior = this.ObtenerBoolDeString(registro["nopediint"].ToString().Trim());
            entidad.DatosOld.BultosMasterEnBorrador = this.ObtenerBoolDeString(registro["prec_mpkg"].ToString().Trim());
            entidad.DatosOld.PuedeComprar = this.ObtenerBoolDeString(registro["compra"].ToString().Trim());
            entidad.DatosOld.PuedeVenderEnCadenas = this.ObtenerBoolDeString(registro["cadena"].ToString().Trim());
            entidad.DatosOld.PedirREBA = this.ObtenerBoolDeString(registro["alcohol"].ToString().Trim());
            entidad.DatosOld.MostrarEnListadoDeCriticos = this.ObtenerBoolDeString(registro["pesar"].ToString().Trim());

            var margenPrev = registro["margen_prev"].ToString().Trim();
            entidad.DatosOld.MargenPreventa = margenPrev == "" ? 0 : Decimal.Parse(margenPrev);
            var margenMay = registro["margen_may"].ToString().Trim();
            entidad.DatosOld.MargenMayorista = margenMay == "" ? 0 : Decimal.Parse(margenMay);

            #endregion

            return entidad;
        }

        private void MapearCodigosEan(Articulo entidad, string bulto, string pack)
        {
            var drEan = dao.EjecutarConsulta("select codigo from cbarras where articulo='" + entidad.Codigo + "' and tipo = 2");
            var listaCodigoEan = new List<CodigoEan>();
            while (drEan.Read())
            {
                var ean = new CodigoEan()
                {
                    CodigoDeBarra = drEan.GetString(0),
                    UnidadesPorBulto = bulto == "" ? 0 : Int32.Parse(bulto),
                    UnidadesPorPack = pack == "" ? 0 : Int32.Parse(pack)
                };
                listaCodigoEan.Add(ean);
            }


            listaCodigoEan.ForEach(c =>
            {
                if (entidad.CodigoEAN.Any(ean => ean.CodigoDeBarra == c.CodigoDeBarra)) //existe y actualizo la prop Habilitada.
                {
                    entidad.CodigoEAN.FirstOrDefault(ean => ean.CodigoDeBarra == c.CodigoDeBarra).UnidadesPorBulto = c.UnidadesPorBulto;
                    entidad.CodigoEAN.FirstOrDefault(ean => ean.CodigoDeBarra == c.CodigoDeBarra).UnidadesPorPack = c.UnidadesPorPack;
                }
                else
                    entidad.CodigoEAN.Add(c);
            });

            List<CodigoEan> eansBorados = new List<CodigoEan>();

            entidad.CodigoEAN.ToList().ForEach(ean =>
            {
                if (!listaCodigoEan.Any(t => t.CodigoDeBarra == ean.CodigoDeBarra))
                    eansBorados.Add(ean);
            });

            eansBorados.ForEach(eanb => entidad.CodigoEAN.Remove(eanb));
            
            drEan.Close();
            drEan.Dispose();
            //dao.Desconectar();
        }

        private void MapearCodigosDun(Articulo entidad, string pallet, string cantbase, string altura)
        {
            var drDun = dao.EjecutarConsulta("select codigo from cbarras where articulo='" + entidad.Codigo + "' and tipo = 1");
            var listaCodigosDun = new List<CodigoDun>();
            while (drDun.Read())
            {
                var dun = new CodigoDun()
                {
                    CodigoDeBarra = drDun.GetString(0),
                    UnidadesPorAltura = altura == "" ? 0 : Int32.Parse(altura),
                    UnidadesPorBase = cantbase == "" ? 0 : Int32.Parse(cantbase),
                    UnidadesPorPallet = altura == "" ? 0 : Int32.Parse(pallet)
                };
                listaCodigosDun.Add(dun);
            }

            listaCodigosDun.ForEach(c =>
            {
                if (entidad.CodigoDUN.Any(dun => dun.CodigoDeBarra == c.CodigoDeBarra)) //existe y actualizo la prop Habilitada.
                {
                    entidad.CodigoDUN.FirstOrDefault(dun => dun.CodigoDeBarra == c.CodigoDeBarra).UnidadesPorAltura = c.UnidadesPorAltura;
                    entidad.CodigoDUN.FirstOrDefault(dun => dun.CodigoDeBarra == c.CodigoDeBarra).UnidadesPorBase = c.UnidadesPorBase;
                    entidad.CodigoDUN.FirstOrDefault(dun => dun.CodigoDeBarra == c.CodigoDeBarra).UnidadesPorPallet = c.UnidadesPorPallet;
                }
                else
                    entidad.CodigoDUN.Add(c);
            });

            List<CodigoDun> dunsBorrados = new List<CodigoDun>();

            entidad.CodigoDUN.ToList().ForEach(dun =>
            {
                if (!listaCodigosDun.Any(t => t.CodigoDeBarra == dun.CodigoDeBarra))
                    dunsBorrados.Add(dun);
            });

            dunsBorrados.ForEach(dunb => entidad.CodigoDUN.Remove(dunb));
            
            drDun.Close();
            drDun.Dispose();
            //dao.Desconectar();
        }


        public override bool CompararParaBorrar(Core.Modelo.EntidadMaestro entidad)
        {
            var arti = entidad as Articulo;

            return arti.ArticulosCompuestos.Count == 0;
        }
    }
}
