using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Clientes;
using Inteldev.Fixius.Negocios.Preventa.Buscadores;
using Inteldev.Fixius.Negocios.Preventa.BuscadoresDTO;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioCoordenadasClientes : ServicioABM<DTO.Preventa.CoordenadaCliente, Modelo.Preventa.CoordenadaCliente>, IServicioCoordenadasClientes
    {
        public Core.DTO.Carriers.GrabadorCarrier GrabarLista(List<DTO.Preventa.CoordenadaCliente> coordenadasClientes, Usuario usuario, string empresa)
        {
            var gc = new List<GrabadorCarrier>();
            foreach (var item in coordenadasClientes)
            {
                gc.Add(this.Grabar(item, usuario, empresa));
            }
            var gcGeneral = new GrabadorCarrier();
            foreach (var item in gc)
            {
                if (item.getError())
                {
                    if (gcGeneral.getMensaje() == string.Empty)
                        gcGeneral.setMensaje(item.getMensaje());
                    else
                        gcGeneral.setMensaje(gcGeneral.getMensaje() + item.getMensaje());
                    gcGeneral.setError(true);
                }
            }
            if (gcGeneral.getMensaje() == string.Empty)
                gcGeneral.setMensaje("Grabado Correctamente.");
            return gcGeneral;
        }

        //public DTO.Preventa.CoordenadaCliente ObtenerPorCliente(string codigo)
        //{
        //    throw new NotImplementedException();
        //if (buscadorPreventista != null)
        //{
        //    para[1] = new ParameterOverride("entidad", "CoordenadaCliente");
        //    var buscador = (IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    var parametros = new ListaParametrosDeBusqueda();
        //    foreach (var item in ruta.Clientes)
        //    {
        //        var dto = buscador.BuscarPorCodigo<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente>(item.Codigo, Core.CargarRelaciones.CargarTodo, parametros.Parametros);
        //        if (dto != null)
        //        {
        //            coordenadas.Add(dto);
        //        }
        //    }
        //}
        //}

        public ICollection<DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasPorPreventista(Preventista preventista, DateTime dia, string empresa)
        {
            var coordenadas = new List<CoordenadaCliente>();
            var clientes = new List<Inteldev.Fixius.Servicios.DTO.Clientes.Cliente>();
            var parametros = new ListaParametrosDeBusqueda();

            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", empresa);
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscadorCoordenada = (BuscadorCoordenadaClienteDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorCoordenadaClienteDTO), para);

            coordenadas = buscadorCoordenada.ObtenerCoordenadasDeClientes(preventista.Id, dia);

            return coordenadas;
        }

        public ICollection<DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasPorPreventista(string codigoPreventista, DateTime dia, string empresa)
        {
            var coordenadas = new List<CoordenadaCliente>();
            var clientes = new List<Inteldev.Fixius.Servicios.DTO.Clientes.Cliente>();
            var parametros = new ListaParametrosDeBusqueda();

            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", empresa);
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscadorCoordenada = (BuscadorCoordenadaClienteDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorCoordenadaClienteDTO), para);

            coordenadas = buscadorCoordenada.ObtenerCoordenadasDeClientes(codigoPreventista, dia);

            return coordenadas;
        }



        //public ICollection<DTO.Preventa.CoordenadaCliente> ObtenerCoordenadasPorPreventista(Preventista preventista, DateTime dia, string empresa)
        //{
        //    var coordenadas = new List<CoordenadaCliente>();
        //    var clientes = new List<Inteldev.Fixius.Servicios.DTO.Clientes.Cliente>();
        //    var parametros = new ListaParametrosDeBusqueda();

        //    var para = new ParameterOverride[2];
        //    para[0] = new ParameterOverride("empresa", empresa);
        //    para[1] = new ParameterOverride("entidad", "RutaDeVenta");

        //    var buscadorRuta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);

        //    para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

        //    var buscadorCoordenada = (IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);

        //    if (buscadorRuta != null)
        //    {
        //        clientes = buscadorRuta.ObtenerClientes(preventista, dia);
        //        foreach (var item in clientes)
        //        {
        //            var dto = buscadorCoordenada.BuscarPorCodigo<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente>(item.Codigo, Core.CargarRelaciones.CargarTodo, parametros.Parametros);
        //            if (dto != null)
        //            {
        //                coordenadas.Add(dto);
        //            }
        //        }
        //    }
        //    return coordenadas;
        //}

        //public Core.DTO.Carriers.ErrorCarrier Borrar(DTO.Preventa.CoordenadaCliente ODto, Core.DTO.Usuarios.Usuario Usuario, string empresa)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var borrador = (IBorradorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBorradorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    var result = borrador.Borrar(ODto, Usuario);
        //    return result;
        //}

        //public Core.DTO.Carriers.CreadorCarrier<DTO.Preventa.CoordenadaCliente> Crear(string empresa)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var creador = (ICreadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(ICreadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    return creador.Crear();
        //}

        //public Core.DTO.Carriers.CreadorCarrier<DTO.Preventa.CoordenadaCliente> CrearConParametros(string empresa, params int[] args)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var creador = (ICreadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(ICreadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    return creador.Crear(args);
        //}

        //public bool EsValido(DTO.Preventa.CoordenadaCliente Entidad)
        //{
        //    throw new NotImplementedException();
        //}

        //public GrabadorCarrier Grabar(DTO.Preventa.CoordenadaCliente ODto, Core.DTO.Usuarios.Usuario Usuario, string empresa)
        //{
        //    //var antes = DateTime.Now;
        //    if (Usuario == null)
        //    {
        //        Usuario = new Usuario();
        //        Usuario.Nombre = "Anonymous";
        //    }
        //    GrabadorCarrier grabadorhel = new GrabadorCarrier();
        //    if (ODto != null)
        //    {
        //        ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //        var grabador = (IGrabadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IGrabadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //        if (grabador == null)
        //        {
        //            grabadorhel.setError(true);
        //            grabadorhel.setMensaje("No se pudo guardar.\nCódigo de error: 0xSABM_G");
        //        }
        //        else
        //            grabadorhel = grabador.Grabar(ODto, Usuario);
        //    }
        //    else
        //    {
        //        grabadorhel.setError(true);
        //        grabadorhel.setMensaje("No se pudo guardar.\nCódigo de error: 0xSABM_ODtoNull");
        //        //necesito mejor descripcion del error. 
        //    }
        //    return grabadorhel;
        //}

        //public IList<DTO.Preventa.CoordenadaCliente> ObtenerLista(object param, Core.CargarRelaciones cargaEntidades, string empresa)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var buscador = (IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    return buscador.BuscarLista(param, cargaEntidades).ToList();
        //}

        //public DTO.Preventa.CoordenadaCliente ObtenerPorCodigo(object codigo, Core.CargarRelaciones cargarEntidades, string empresa, Core.DTO.ListaParametrosDeBusqueda parametros = null)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var buscador = (IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    var dto = buscador.BuscarPorCodigo<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente>(codigo, cargarEntidades, parametros == null ? null : parametros.Parametros);
        //    return dto;
        //}

        //public DTO.Preventa.CoordenadaCliente ObtenerPorId(int id, Core.CargarRelaciones cargarEntidades, string empresa)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var buscador = (IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    var dto = buscador.BuscarSimple(id, cargarEntidades);
        //    return dto;
        //}

        //public List<Core.DTO.ResultadoBusqueda<DTO.Preventa.CoordenadaCliente>> ObtenerResultados(string busqueda, string empresa, Core.DTO.ListaParametrosDeBusqueda parametros = null)
        //{
        //    ParameterOverride[] para = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "CoordenadaCliente") };
        //    var buscaResultados = (IContextoDeBusqueda<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>)FabricaNegocios.Instancia.Resolver(typeof(IContextoDeBusqueda<Inteldev.Fixius.Modelo.Preventa.CoordenadaCliente, Inteldev.Fixius.Servicios.DTO.Preventa.CoordenadaCliente>), para);
        //    //a cambiar el contexto de busqueda para que acepte parametros
        //    var resultado = buscaResultados.Buscar(busqueda, parametros);
        //    return resultado;
        //}

        public ICollection<CoordenadaCliente> ActualizarCoordenadasClientes()
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscador = (IBuscadorFoxConfigZona)FabricaNegocios.Instancia.Resolver<IBuscadorFoxConfigZona>();
            var listaCoordenadaClientes = buscador.BuscarClientes();
            if (listaCoordenadaClientes.Count > 0)
                return listaCoordenadaClientes;
            return new List<CoordenadaCliente>();
        }

        public ICollection<CoordenadaCliente> ActualizarCoordenadasClientes(List<string> codigosClientes)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscador = (IBuscadorFoxConfigZona)FabricaNegocios.Instancia.Resolver<IBuscadorFoxConfigZona>();
            var listaCoordenadaClientes = buscador.BuscarClientes(codigosClientes);
            if (listaCoordenadaClientes.Count > 0)
                return listaCoordenadaClientes;
            return new List<CoordenadaCliente>();
        }

        public ICollection<CoordenadaCliente> ObtenerCoordenadasClientesInvalidas()
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscadorCoordenada = (BuscadorCoordenadaClienteDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorCoordenadaClienteDTO), para);

            var coordenadas = buscadorCoordenada.BuscarClientesConCoordenadasInvalidas();
            return coordenadas;
        }

        public ICollection<CoordenadaCliente> ObtenerCoordenadasClientesPorZona(List<string> codigosClientes)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "CoordenadaCliente");

            var buscadorCoordenada = (BuscadorCoordenadaClienteDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorCoordenadaClienteDTO), para);

            var coordenadas = buscadorCoordenada.BuscarCoordenadasClientes(codigosClientes);
            return coordenadas;
        }
    }
}
