using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class DestinoProveedor : DestinoChequeTercero
    {
        public Proveedor Proveedor { get; set; }
        [ForeignKey("Proveedor")]
        public int? ProveedorId { get; set; }
    }
}
