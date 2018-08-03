using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class PlantillaListaProveedor:DTOMaestro
    {
        [DataMember]
		public List<Proveedor> Proveedores { get; set; }
        [DataMember]
		public List<Columna> Columnas { get; set; }
    }
}
