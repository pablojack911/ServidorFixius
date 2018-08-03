using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Creadores
{
    /// <summary>
    /// Creador para Linea
    /// </summary>
    public class CreadorLinea : CreadorDTO<Fixius.Modelo.Articulos.Linea, Fixius.Servicios.DTO.Articulos.Linea>
    {
        public CreadorLinea(ICreador<Fixius.Modelo.Articulos.Linea> creadorEntidad,
            IMapeadorGenerico<Fixius.Modelo.Articulos.Linea, Fixius.Servicios.DTO.Articulos.Linea> mapeador,
            string empresa, string entidad)
            : base(creadorEntidad, mapeador, empresa, entidad)
        {

        }
    }
}
