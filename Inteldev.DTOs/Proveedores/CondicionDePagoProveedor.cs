using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Fixius.Servicios.DTO.Clientes;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class CondicionDePagoProveedor : DTOMaestro
    {
        public CondicionDePagoProveedor()
        {
            this.Proveedores = new List<Proveedor>();
        }
        [DataMember]
        public int Dias { get; set; }
        [DataMember]
        public List<Proveedor> Proveedores { get; set; }
        [DataMember]
        public decimal Porcentaje { get; set; }
    }
}
