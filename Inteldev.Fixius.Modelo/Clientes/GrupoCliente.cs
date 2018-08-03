using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class GrupoCliente : EntidadMaestro
    {
        public GrupoCliente()
        {
            this.Clientes = new List<Cliente>();
        }

        public ICollection<Cliente> Clientes { get; set; }

        public bool Estadisticos { get; set; }

        public bool Financieros { get; set; }

        public bool Precios { get; set; }
    }
}
