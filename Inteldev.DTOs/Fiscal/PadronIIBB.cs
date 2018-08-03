using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Fiscal
{
    public class PadronIIBB : DTOMaestro
    {
        [DataMember]
        public string FechaPublicacion { get; set; }
        [DataMember]
        public string FechaDesde { get; set; }
        [DataMember]
        public string FechaHasta { get; set; }
        [DataMember]
        public string CUIT { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string CambioAliCuota { get; set; }
        [DataMember]
        public Decimal Percepcion { get; set; }
        [DataMember]
        public Decimal Retencion { get; set; }
        [DataMember]
        public int GrupoPercepcion { get; set; }
        [DataMember]
        public int GrupoRetencion { get; set; }
    }

}
