using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Clientes;
using Inteldev.Fixius.Negocios.Clientes.Grabadores;
using Inteldev.Fixius.Servicios.DTO.Clientes;
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
    public class ServicioRutaDeVenta : ServicioABM<RutaDeVenta, Inteldev.Fixius.Modelo.Clientes.RutaDeVenta>, IServicioRutaDeVenta
    {
        public List<Cliente> ObtenerListaClientes(Preventista preventista, DateTime dia)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            //var buscadorRutaDeVenta = FabricaNegocios._Resolver<IBuscadorRutaDeVentaDTO>();// resuelve mal.. faltan los parameter
            var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);

            return buscadorRutaDeVenta.ObtenerClientes(preventista, dia);
        }

        public void GrabarVertices(string codigoRuta, ICollection<Core.DTO.Locacion.Coordenada> coordenadasVertices)
        {
            //GrabadorCarrier gc = new GrabadorCarrier();
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            //var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>), para);
            //var ruta = buscadorRutaDeVenta.BuscarPorCodigo<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta>(codigoRuta, Core.CargarRelaciones.NoCargarNada, new List<Core.DTO.ParametrosMiniBusca>());
            //if (ruta != null)
            //{
            //}
            var grabadorRutaDeVenta = (GrabadorRutaDeVenta)FabricaNegocios.Instancia.Resolver(typeof(GrabadorRutaDeVenta), para);
            para[1] = new ParameterOverride("entidad", "Coordenada");
            var mapeadorCoordenada = (MapeadorGenerico<Inteldev.Core.Modelo.Locacion.Coordenada, Inteldev.Core.DTO.Locacion.Coordenada>)FabricaNegocios.Instancia.Resolver(typeof(MapeadorGenerico<Inteldev.Core.Modelo.Locacion.Coordenada, Inteldev.Core.DTO.Locacion.Coordenada>), para);
            grabadorRutaDeVenta.GrabarCoordenadas(codigoRuta, mapeadorCoordenada.ToListEntidad(coordenadasVertices));
            //return gc;
        }

        public List<Core.DTO.Locacion.Coordenada> ObtenerVertices(string codigo, string empresa, string division)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);
            return buscadorRutaDeVenta.ObtenerCoordenadas(codigo, empresa, division);
        }


        public List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime dia)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);
            var x = buscadorRutaDeVenta.ObtenerRutasDelDia(preventista, dia);
            return x;
        }

        public List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime dia)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);
            var x = buscadorRutaDeVenta.ObtenerRutasDelDia(codigoPreventista, dia);
            return x;
        }

        public List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRutaDeVenta = (BuscadorRutaDeVentaDTO)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorRutaDeVentaDTO), para);
            var x = buscadorRutaDeVenta.ObtenerClientesPorZona(codigoZona, empresa, division);
            return x;
        }
    }
}
