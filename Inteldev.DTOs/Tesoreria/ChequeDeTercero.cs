using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class ChequeDeTercero : DTOMaestro
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaEfectivizacion { get; set; }
        [DataMember]
        public decimal Importe { get; set; }
        [DataMember]
        public Banco Banco { get; set; }
        [DataMember]
        public int? BancoId { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string Titular { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public Sucursal Sucursal { get; set; }
        [DataMember]
        public int? SucursalId { get; set; }
        [DataMember]
        public List<MovimientoChequeTercero> MovimientoChequeTercero { get; set; }
    }
}
