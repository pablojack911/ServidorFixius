using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Logistica
{
    public class ZonaLogistica : EntidadMaestro
    {
        public ICollection<Cliente> Clientes { get; set; }

        public ZonaLogistica()
        {
            this.Clientes = new List<Cliente>();
        }
    }
}
