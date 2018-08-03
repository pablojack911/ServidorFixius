using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Numeradores
{
    public class NumeradorTransportista : Numerador<Transportista>
    {
        public NumeradorTransportista(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        public override string ProximoCodigo(Transportista entidad = null)
        {
            return this.ProximoCodigoDisponibleConPrefijo("F", "1", this.TamañoMaximo - 1); //el -1 es por el prefijo que le quita un lugar al código
        }
    }
}
