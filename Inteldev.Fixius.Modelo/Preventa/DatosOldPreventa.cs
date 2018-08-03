using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class DatosOldPreventa : EntidadBase
    {
        public bool Inactivo { get; set; }
        public bool EsSupervisor { get; set; }

    }
}
