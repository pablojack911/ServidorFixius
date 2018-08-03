using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Creadores
{
    public class CreadorRutaDeVenta : CreadorGenerico<Modelo.Clientes.RutaDeVenta>
    {
        public CreadorRutaDeVenta(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }

        protected override void CargarDatos(Modelo.Clientes.RutaDeVenta Entidad)
        {
            Entidad.DatosOld = new Modelo.Clientes.DatosOldRutaDeVenta();
        }
    }
}
