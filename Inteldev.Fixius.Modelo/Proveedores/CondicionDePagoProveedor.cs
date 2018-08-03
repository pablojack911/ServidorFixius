using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Core.Modelo.Organizacion;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class CondicionDePagoProveedor : EntidadMaestro
    {
        public CondicionDePagoProveedor()
        {
            this.Proveedores = new List<Proveedor>();
        }
        public int Dias { get; set; }

        public ICollection<Proveedor> Proveedores { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
