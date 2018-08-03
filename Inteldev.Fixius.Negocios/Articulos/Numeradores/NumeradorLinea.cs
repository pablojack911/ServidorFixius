using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Numeradores
{
    public class NumeradorLinea : Numerador<Linea>
    {
        public NumeradorLinea(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }

        public override string ProximoCodigo(Linea entidad = null)
        {
            return this.ProximoCodigoDisponibleSoloNumero(1, this.TamañoMaximo);
        }
    }
}
