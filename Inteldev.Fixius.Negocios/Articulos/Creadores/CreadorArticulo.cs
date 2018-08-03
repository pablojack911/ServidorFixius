using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Creadores
{
    public class CreadorArticulo : CreadorDTO<Modelo.Articulos.Articulo, Servicios.DTO.Articulos.Articulo>
    {
        public CreadorArticulo(ICreador<Modelo.Articulos.Articulo> creadorEntidad,
                                IMapeadorGenerico<Modelo.Articulos.Articulo, Servicios.DTO.Articulos.Articulo> mapeador,
                                string empresa,
                                string entidad)
            : base(creadorEntidad, mapeador, empresa, entidad)
        {

        }

        public override Core.DTO.Carriers.CreadorCarrier<Servicios.DTO.Articulos.Articulo> Crear()
        {
            var articuloCarrier = base.Crear();
            var articulo = articuloCarrier.GetEntidad();
            articulo.DatosOld = new Servicios.DTO.Articulos.DatosOldArticulo();

            return articuloCarrier;
        }
    }
}
