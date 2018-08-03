using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes
{
    public class BuscadorRutaDeVentaDTO : BuscadorDTO<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>, IBuscadorRutaDeVentaDTO
    {
        public BuscadorRutaDeVentaDTO(IBuscador<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta> buscadoEntidad, IMapeadorGenerico<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta> mapeador)
            : base(buscadoEntidad, mapeador) { }

        public List<Cliente> ObtenerClientes(Preventista preventista, DateTime fecha)
        {
            var mapeadorPreventista = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.Preventista, Inteldev.Fixius.Servicios.DTO.Preventa.Preventista>>();
            var buscadorRutadeVenta = (IBuscadorRutaDeVenta)this.BuscadorEntidad;
            var result = buscadorRutadeVenta.ObtenerClientes(mapeadorPreventista.DtoToEntidad(preventista), fecha);
            var mapeadorCliente = FabricaNegocios._Resolver<IMapeadorGenerico<Modelo.Clientes.Cliente, Servicios.DTO.Clientes.Cliente>>();
            return mapeadorCliente.ToListDto(result);
        }

        public new List<Modelo.Clientes.RutaDeVenta> BuscarLista(object param, Core.CargarRelaciones cargarEntidades)
        {
            throw new NotImplementedException();
        }

        public new Modelo.Clientes.RutaDeVenta BuscarPorCodigo<TMaestro>(object busqueda, Core.CargarRelaciones cargarEntidades, List<Core.DTO.ParametrosMiniBusca> parametros) where TMaestro : Core.Modelo.EntidadMaestro
        {
            throw new NotImplementedException();
        }

        public new Modelo.Clientes.RutaDeVenta BuscarSimple(object busqueda, Core.CargarRelaciones cargarEntidades)
        {
            throw new NotImplementedException();
        }

        public List<Core.DTO.Locacion.Coordenada> ObtenerCoordenadas(string codigo, string empresa, string division)
        {
            var mapeadorCoordenada = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Core.Modelo.Locacion.Coordenada, Inteldev.Core.DTO.Locacion.Coordenada>>();
            var buscadorRutadeVenta = (IBuscadorRutaDeVenta)this.BuscadorEntidad;
            var result = buscadorRutadeVenta.ObtenerCoordenadas(codigo, empresa, division).ToList();
            var x = mapeadorCoordenada.ToListDto(result);
            return x;
        }

        public List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime fecha)
        {
            var mapeadorPreventista = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.Preventista, Inteldev.Fixius.Servicios.DTO.Preventa.Preventista>>();
            var buscadorRutadeVenta = (IBuscadorRutaDeVenta)this.BuscadorEntidad;
            var result = buscadorRutadeVenta.ObtenerRutasDelDia(mapeadorPreventista.DtoToEntidad(preventista), fecha);
            var x = this.Mapeador.ToListDto(result);
            return x;
        }

        public List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime fecha)
        {
            //var mapeadorPreventista = FabricaNegocios._Resolver<IMapeadorGenerico<Inteldev.Fixius.Modelo.Preventa.Preventista, Inteldev.Fixius.Servicios.DTO.Preventa.Preventista>>();
            var buscadorRutadeVenta = (IBuscadorRutaDeVenta)this.BuscadorEntidad;
            buscadorRutadeVenta.CargarEntidadesRelacionadas = Core.CargarRelaciones.CargarTodo;
            var result = buscadorRutadeVenta.ObtenerRutasDelDia(codigoPreventista, fecha);
            var x = this.Mapeador.ToListDto(result);
            return x;
        }


        public List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division)
        {
            var buscadorRutadeVenta = (IBuscadorRutaDeVenta)this.BuscadorEntidad;
            return buscadorRutadeVenta.ObtenerClientesPorZona(codigoZona, empresa, division);
        }
    }
}
