using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Core.DTO.Auditoria;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class ObservacionProveedor : Observacion
    {
        public ObservacionProveedor()
        {
            this.FechaHora = DateTime.Now;
        }
    }
}
