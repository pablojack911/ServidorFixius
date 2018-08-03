using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core;

namespace Inteldev.Fixius.Negocios.Busquedas
{
	public class BuscadorDTOSector : BuscadorDTO<Sector,Servicios.DTO.Articulos.Sector>
	{
		public BuscadorDTOSector(IBuscador<Sector> buscadorEntidad, IMapeadorGenerico<Sector, Servicios.DTO.Articulos.Sector> mapeador)
			:base(buscadorEntidad,mapeador)
		{
		}

		public override List<Servicios.DTO.Articulos.Sector> BuscarLista(object param, CargarRelaciones cargarEntidades)
		{
			int id = 0;
			int.TryParse(param.ToString(),out id);
			return this.Mapeador.ToListDto(this.BuscadorEntidad.BuscarLista(e => e.Area.Id == id, cargarEntidades).ToList());
		}
	}
}
