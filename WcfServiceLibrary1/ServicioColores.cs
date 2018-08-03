using Inteldev.Core.Negocios;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
	public class ServicioColores : ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.ColorColumnaPlantilla,Inteldev.Fixius.Modelo.Proveedores.ColorColumnaPlantilla>
	{
		public override IList<DTO.Proveedores.ColorColumnaPlantilla> ObtenerLista(object param, Core.CargarRelaciones cargarEntidades,string empresa)
		{
			var colores = base.ObtenerLista(param,cargarEntidades,empresa);
			if (colores != null && colores.Count != 0)
			{
				return colores;
			}
			else
			{
				var result = new List<ColorColumnaPlantilla>();
				foreach (string item in Enum.GetNames(typeof(Inteldev.Fixius.Servicios.DTO.Proveedores.TipoColumna)))
				{
					var color = this.Crear(empresa).GetEntidad();
					color.Columna = (Inteldev.Fixius.Servicios.DTO.Proveedores.TipoColumna) Enum.Parse(typeof(Inteldev.Fixius.Servicios.DTO.Proveedores.TipoColumna), item);
					color.ColorColumna = "255,255,255";
					result.Add(color);
				}
				return result;
			}
		}	
	}
}
