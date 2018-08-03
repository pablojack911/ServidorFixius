using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using System.Data;
using System.Collections.ObjectModel;


namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class ListaDePrecios : DTOMaestro
    {
        [DataMember]
        public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
        [DataMember]
        public DateTime Vigencia { get; set; }
        [DataMember]
        public List<ObservacionProveedor> Observaciones { get; set; }
        [DataMember]
        public DataTable Detalle { get; set; }
        [DataMember]
        public List<Columna> Columnas { get; set; }
    }
}
