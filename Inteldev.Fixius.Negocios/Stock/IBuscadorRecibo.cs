using Inteldev.Core.Negocios;
using System;
namespace Inteldev.Fixius.Negocios.Stock
{
	public interface IBuscadorRecibo : IBuscador<Inteldev.Fixius.Modelo.Stock.ReciboStock>
	{
		Inteldev.Fixius.Modelo.Stock.ReciboStock BuscaReciboIngreso(int ingresoId);
	}
}
