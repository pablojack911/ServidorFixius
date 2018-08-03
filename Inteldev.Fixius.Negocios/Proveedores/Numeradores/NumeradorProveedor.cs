using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Numeradores
{
    public class NumeradorProveedor : Numerador<Proveedor>
    {
        public NumeradorProveedor(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }

        public override string ProximoCodigo(Proveedor entidad = null)
        {
            return this.ProximoCodigoDisponibleSoloNumero(20000, this.TamañoMaximo);
        }
    }
}
