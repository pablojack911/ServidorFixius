using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorLinea))]
    public class Linea : DTOMaestro
    {
        [DataMember]
        public string NombreBreve { get; set; }
        [DataMember]
        public ConceptoDeMovimiento ConceptoDeMovimiento { get; set; }
        [DataMember]
        public int? ConceptoDeMovimientoId { get; set; }
        [DataMember]
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [DataMember]
        public int? CondicionDePagoId { get; set; }
        [DataMember]
        public int Reposicion { get; set; }
        [DataMember]
        public int StockCritico { get; set; }
        [DataMember]
        public decimal Acuerdo1 { get; set; }
        [DataMember]
        public decimal Acuerdo2 { get; set; }
        [DataMember]
        public decimal Acuerdo3 { get; set; }
        [DataMember]
        public decimal Acuerdo4 { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }// Empresa o String
        [DataMember]
        public bool AdmiteConvenio { get; set; }
        [DataMember]
        public bool IncluirEnEstadistica { get; set; }
        [DataMember]
        public bool PrecargaSeparada { get; set; }
        [DataMember]
        public bool NoValorizar { get; set; }
        [DataMember]
        public bool PermiteOCAbierta { get; set; }
        [DataMember]
        public bool MonitorearObjetivos { get; set; }
        [DataMember]
        public bool IncluirDeposito3 { get; set; }
    }
}
