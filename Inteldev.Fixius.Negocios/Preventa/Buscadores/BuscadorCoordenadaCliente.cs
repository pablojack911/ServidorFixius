using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Preventa;
using Inteldev.Fixius.Negocios.Clientes;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.Buscadores
{
    public class BuscadorCoordenadaCliente : BuscadorGenerico<CoordenadaCliente>, IBuscadorCoordenadaCliente
    {
        public BuscadorCoordenadaCliente(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        public List<CoordenadaCliente> ObtenerCoordenadas(int? preventistaId, DateTime dia)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "RutaDeVenta");
            var buscadorRuta = (BuscadorRutaDeVenta)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<RutaDeVenta>), para);

            var coordenadas = new List<CoordenadaCliente>();

            if (buscadorRuta != null)
            {
                var codigosClientes = new List<String>();
                var rutas = buscadorRuta.CrearConsulta(preventistaId, dia);

                foreach (var r in rutas.ToList())
                {
                    codigosClientes.AddRange(r.Clientes.Select(c => c.Codigo));
                }

                //foreach (var cod in codigosClientes)
                //{
                //    var coord = this.ConsultaSimple(Core.CargarRelaciones.CargarTodo).FirstOrDefault(cc => cc.Codigo.Equals(cod));
                //    if (coord != null)
                //        coordenadas.Add(coord);
                //}

                coordenadas = this.Contexto.Consultar<CoordenadaCliente>(Core.CargarRelaciones.NoCargarNada).Where(c => codigosClientes.Contains(c.Codigo)).ToList();

            }
            return coordenadas;
        }

        public List<CoordenadaCliente> ObtenerCoordenadas(string codigoPreventista, DateTime dia)
        {
            var preventista = this.Contexto.Consultar<Preventista>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Codigo == codigoPreventista);
            if (preventista != null)
            {
                var preventistaId = preventista.Id;
                return this.ObtenerCoordenadas(preventistaId, dia);
            }
            return new List<CoordenadaCliente>();
        }

        public List<CoordenadaCliente> ObtenerClientesConCoordenadasInvalidas()
        {
            return this.Contexto.Consultar<CoordenadaCliente>(Core.CargarRelaciones.NoCargarNada).Where(c => c.Latitud >= 0 || c.Longitud >= 0).ToList();
        }


        public List<CoordenadaCliente> ObtenerCoordenadasClientes(List<string> codigosClientes)
        {
            var query = this.Contexto.Consultar<CoordenadaCliente>(Core.CargarRelaciones.NoCargarNada);
            var clientes = from c in query
                           where codigosClientes.Contains(c.Codigo)
                           select c;
            return clientes.ToList();
        }
    }
}
