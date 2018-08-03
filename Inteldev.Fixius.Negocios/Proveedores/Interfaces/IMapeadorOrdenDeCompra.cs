using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using System;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
    public interface IMapeadorOrdenDeCompra : IMapeadorGenerico<Modelo.Proveedores.OrdenDeCompra, Servicios.DTO.Proveedores.OrdenDeCompra>
    {
        Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra entidad, Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra dto, System.Collections.Generic.List<Inteldev.Fixius.Modelo.Articulos.Articulo> articulos, ObjetivosDeCompra objetivos);
        Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra EntidadToDto(Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra entidad, System.Collections.Generic.List<Inteldev.Fixius.Modelo.Articulos.Articulo> articulos, ObjetivosDeCompra objetivos);
        //System.Collections.Generic.List<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra> ToListDto(System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra> listaEntidades);
        //System.Collections.Generic.List<Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra> ToListEntidad(System.Collections.Generic.List<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra> listaDto);
    }
}
