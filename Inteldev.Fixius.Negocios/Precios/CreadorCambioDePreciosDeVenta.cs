using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using Inteldev.Fixius.Servicios.DTO.Precios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Precios
{
    public class CreadorCambioDePreciosDeVenta : CreadorDTO<Modelo.Precios.CambioDePreciosDeVenta, Servicios.DTO.Precios.CambioDePreciosDeVenta>
    {
        public CreadorCambioDePreciosDeVenta(ICreador<Modelo.Precios.CambioDePreciosDeVenta> creador,
                                    IMapeadorGenerico<Modelo.Precios.CambioDePreciosDeVenta,
                                                      Servicios.DTO.Precios.CambioDePreciosDeVenta> mapeador, string empresa, string entidad)
            : base(creador, mapeador, empresa, entidad)
        {
        }
        /// <summary>
        /// args[0] = tipo
        /// args[1] = folder
        /// args[2] = areaID
        /// args[3] = sectorID
        /// args[4] = subsectorID
        /// args[5] = familiaID
        /// args[6] = subFamiliaID
        /// args[7] = marcaID
        /// args[8] = listaID
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override CreadorCarrier<Servicios.DTO.Precios.CambioDePreciosDeVenta> Crear(params int[] args)
        {
            /*
             * el datatable tiene como columnas el articulo, costo, CFU, las dos columnas por cada unidad de negocio (precio y margen)
             * */
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Precios.CambioDePreciosDeVenta>();
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            var creadorItem = (ICreadorItemCambioDePrecioDeVenta<ListaDePreciosDetalle>)FabricaNegocios.Instancia.Resolver(typeof(ICreadorItemCambioDePrecioDeVenta<ListaDePreciosDetalle>), parameters);
            var result = new Inteldev.Fixius.Modelo.Precios.CambioDePreciosDeVenta();
            result.ItemsCambioDePrecioDeVenta = creadorItem.CreaItems(args[1], args[2], args[3], args[4], args[5], args[6], args[7]);
            var dto = this.Mapeador.EntidadToDto(result);
            dto.TipoDeCambio = (Inteldev.Fixius.Servicios.DTO.Precios.TipoCambioDePreciosDeVenta)args[0];
            creadorCarrier.SetEntidad(dto);
            return creadorCarrier;
        }

    }
}
