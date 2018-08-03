using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Modelo.Auditoria;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class ObservacionProveedor : Observacion
    {
        public ObservacionProveedor()
            : base()
        {
            this.FechaHora = DateTime.Now;
        }
    }
}
