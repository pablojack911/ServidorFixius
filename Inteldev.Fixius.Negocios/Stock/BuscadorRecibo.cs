using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock
{
	public class BuscadorRecibo : BuscadorGenerico<Inteldev.Fixius.Modelo.Stock.ReciboStock>, Inteldev.Fixius.Negocios.Stock.IBuscadorRecibo
	{
		public BuscadorRecibo(string empresa, string entidad) : base(empresa, entidad) { }
		public ReciboStock BuscaReciboIngreso(int ingresoId)
		{
			return this.Contexto.Consultar<ReciboStock>(CargarRelaciones.CargarCollecciones)
				.Where(p => p.IngresoId == ingresoId).FirstOrDefault();
		}
	}
}
