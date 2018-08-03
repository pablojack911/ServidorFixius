using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class CargosDeFuerzaDeVenta : EntidadMaestro
    {
        [MuchosAMuchos]
        public ICollection<CargosDeFuerzaDeVenta> CargosHijos { get; set; }
    }
}
