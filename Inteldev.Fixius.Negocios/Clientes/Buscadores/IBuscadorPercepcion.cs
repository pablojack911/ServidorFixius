using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public interface IBuscadorPercepcion
    {
        decimal ObtenerPorcentajeDePercepcion(string Cuit);
    }
}
