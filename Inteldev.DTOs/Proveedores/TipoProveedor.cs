using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class TipoProveedor : DTOMaestro
    {
        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
