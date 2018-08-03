using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class Banco : EntidadMaestro
    {
        public Banco()
        {
            this.Proveedores = new List<Proveedor>();
        }
        public List<Proveedor> Proveedores { get; set; }
    }
}
