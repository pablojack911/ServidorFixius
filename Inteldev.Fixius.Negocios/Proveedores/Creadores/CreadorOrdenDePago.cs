using Inteldev.Core;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Inteldev.Fixius.Negocios.Proveedores.Mapeadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Extenciones;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
    public class CreadorOrdenDePago : CreadorDTO<Modelo.Proveedores.OrdenDePago,Servicios.DTO.Proveedores.OrdenDePago>
    {
        public CreadorOrdenDePago(ICreador<OrdenDePago> creadorEntidad,IMapeadorGenerico<Modelo.Proveedores.OrdenDePago,Servicios.DTO.Proveedores.OrdenDePago> mapeador, string empresa, string entidad) : base(creadorEntidad,mapeador,empresa,entidad) { }
        /// <summary>
        /// args[0] = proveedorId
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override CreadorCarrier<Servicios.DTO.Proveedores.OrdenDePago> Crear(params int[] args)
        {
            var entidad = new Modelo.Proveedores.OrdenDePago();
            var buscadorDocumentoDeCompra = FabricaNegocios._Resolver<IBuscadorDocumentoDeCompra>();
            var buscadorProveedor = FabricaNegocios._Resolver<IBuscador<Modelo.Proveedores.Proveedor>>();
            entidad.Proveedor = buscadorProveedor.BuscarSimple(args[0]);
            entidad.ProveedorId = args[0];
            var buscadorOrdenDePago = FabricaNegocios._Resolver<IBuscadorOrdenDePago>();
            var documentosDeCompra = buscadorDocumentoDeCompra.BuscaNoAplicados(args[0]);
            //las ordenes de pago pendientes, donde las pongo?
            var ordenesDePago = buscadorOrdenDePago.BuscaNoAplicados(args[0]);
            var mapeadorOrdenDePago = (IMapeadorOrdenDePago)this.Mapeador;
            var dto = this.Mapeador.EntidadToDto(entidad);
            mapeadorOrdenDePago.CargaDocumentoCompra(dto.Detalle,documentosDeCompra);
            mapeadorOrdenDePago.CargaOrdenesDePago(dto.Detalle,ordenesDePago);
            var result = new CreadorCarrier<Servicios.DTO.Proveedores.OrdenDePago>();
            result.SetEntidad(dto);
            return result;
        }
    }
}
