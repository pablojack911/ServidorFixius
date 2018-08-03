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
	public class BuscadorDTOSubFamilia : BuscadorDTO<Subfamilia, Servicios.DTO.Articulos.Subfamilia>
	{

		public BuscadorDTOSubFamilia(IBuscador<Subfamilia> buscadorEntidad, IMapeadorGenerico<Subfamilia, Servicios.DTO.Articulos.Subfamilia> mapeador)
			:base(buscadorEntidad,mapeador)
		{
		}

		public override List<Servicios.DTO.Articulos.Subfamilia> BuscarLista(object param, CargarRelaciones cargarEntidades)
		{
			int id = 0;
			int.TryParse(param.ToString(), out id);
			return this.Mapeador.ToListDto(this.BuscadorEntidad.BuscarLista(e => e.Familia.Id == id, cargarEntidades).ToList());
		}
	}
}
