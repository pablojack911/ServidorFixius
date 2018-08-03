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
	public class BuscadorDTOFamilia : BuscadorDTO<Familia, Servicios.DTO.Articulos.Familia>
	{

		public BuscadorDTOFamilia(IBuscador<Familia> buscadorEntidad, IMapeadorGenerico<Familia, Servicios.DTO.Articulos.Familia> mapeador)
			:base(buscadorEntidad,mapeador)
		{
		}

		public override List<Servicios.DTO.Articulos.Familia> BuscarLista(object param, CargarRelaciones cargarEntidades)
		{
			int id = 0;
			int.TryParse(param.ToString(), out id);
			return this.Mapeador.ToListDto(this.BuscadorEntidad.BuscarLista(e => e.Subsector.Id == id, cargarEntidades).ToList());
		}

	}
}
