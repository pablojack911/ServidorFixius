using Inteldev.Core.DTO.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class OrdenDePago : DocumentoProveedor
    {
        [DataMember]
        public DataTable Detalle { get; set; }
        [DataMember]
        public List<Valor> Valores { get; set; }
        [DataMember]
        public decimal Importe { get; set; }
        [DataMember]
        public decimal Aplicado { get; set; }
    }
}
