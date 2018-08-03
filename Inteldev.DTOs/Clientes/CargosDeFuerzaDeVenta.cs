using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class CargosDeFuerzaDeVenta : DTOMaestro
    {
        [DataMember]
        public List<CargosDeFuerzaDeVenta> CargosHijos { get; set; }
    }
}
