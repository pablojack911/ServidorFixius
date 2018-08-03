using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores
{
    public class ItemLetra
    {
        public TipoDocumento documento { get; set; }
        public CondicionAnteIVA condicionAnteIVAEmpresa { get; set; }
        public CondicionAnteIVA condicionAnteIVAProveedor { get; set; }
    }
}
