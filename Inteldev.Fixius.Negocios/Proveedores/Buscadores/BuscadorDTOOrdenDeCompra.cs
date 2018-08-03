using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BuscadorDTOOrdenDeCompra : BuscadorDTO<Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra, OrdenDeCompra>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorDTOOrdenDeCompra
    {
        private string empresa;
        private string entidad;
        public BuscadorDTOOrdenDeCompra(IBuscador<Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra> buscador, IMapeadorGenerico<Modelo.Proveedores.OrdenDeCompra, OrdenDeCompra> mapeador, string empresa, string entidad)
            : base(buscador, mapeador)
        {
            this.empresa = empresa;
            this.entidad = entidad;
        }

        public override OrdenDeCompra BuscarSimple(object busqueda, CargarRelaciones cargarEntidades)
        {
            var result = this.BuscadorEntidad.BuscarSimple(busqueda);
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "ListaDePrecios") };
            var buscaLista = (IBuscadorListaDePrecios)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorListaDePrecios), parameters);
            int id = 0;
            int.TryParse(result.ProveedorId.ToString(), out id);
            result.ListaDePrecios = buscaLista.obtenerListaProveedor(id, true);
            parameters[1] = new ParameterOverride("entidad", "Articulo");
            var buscaArticulo = (IBuscadorArticulo)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorArticulo), parameters);
            parameters[1] = new ParameterOverride("entidad", "ObjetivosDeCompra");
            var buscaObjetivos = (IBuscadorObjetivos)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorObjetivos), parameters);
            var articulos = buscaArticulo.obtenerArticulosProveedor(id);
            var objetivos = buscaObjetivos.obtenerObjetivosProveedor(id);
            //var articulos = new List<Articulo>();
            var mapper = (IMapeadorOrdenDeCompra)this.Mapeador;
            return mapper.EntidadToDto(result, articulos, objetivos);
        }

        public List<OrdenDeCompra> BuscarOrdenes(EstadoOrdenDeCompra estado, int ProveedorId)
        {
            var buscador = FabricaNegocios._Resolver<IBuscadorOrdenDeCompra>();
            var result = buscador.BuscarOrdenes((Inteldev.Fixius.Modelo.Proveedores.EstadoOrdenDeCompra)estado, ProveedorId);
            return this.Mapeador.ToListDto(result);
        }
    }
}
