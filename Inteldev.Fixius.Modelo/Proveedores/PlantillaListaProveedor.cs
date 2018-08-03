using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class PlantillaListaProveedor:EntidadMaestro
    {
        [MuchosAMuchos]
        public ICollection<Proveedor> Proveedores { get; set; }
        
        public ICollection<Columna> Columnas { get; set; }
    }
}
