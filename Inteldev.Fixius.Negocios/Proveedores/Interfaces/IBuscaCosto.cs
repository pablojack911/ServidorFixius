using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscaCosto<TEntidad>
		where TEntidad : class
	{
		Dictionary<int, decimal> BuscaCosto();
	}
}
