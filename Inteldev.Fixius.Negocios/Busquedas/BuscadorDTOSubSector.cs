using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas
{
	public class BuscadorDTOSubSector : BuscadorDTO<Subsector,Servicios.DTO.Articulos.Subsector>
	{
		public BuscadorDTOSubSector(IBuscador<Subsector> buscadorEntidad, IMapeadorGenerico<Subsector, Servicios.DTO.Articulos.Subsector> mapeador)
			:base(buscadorEntidad,mapeador)
		{
		}

		public override List<Servicios.DTO.Articulos.Subsector> BuscarLista(object param, CargarRelaciones cargarEntidades)
		{
			int id = 0;
			int.TryParse(param.ToString(), out id);
			return this.Mapeador.ToListDto(this.BuscadorEntidad.BuscarLista(e => e.Sector.Id == id,cargarEntidades).ToList());
		}

	}
}
