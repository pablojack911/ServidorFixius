using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class Linea : EntidadMaestro
    {
        public string NombreBreve { get; set; }
        public ConceptoDeMovimiento ConceptoDeMovimiento { get; set; }
        [ForeignKey("ConceptoDeMovimiento")]
        public int? ConceptoDeMovimientoId { get; set; }
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [ForeignKey("CondicionDePago")]
        public int? CondicionDePagoId { get; set; }
        public int Reposicion { get; set; }
        public int StockCritico { get; set; }
        public decimal Acuerdo1 { get; set; }
        public decimal Acuerdo2 { get; set; }
        public decimal Acuerdo3 { get; set; }
        public decimal Acuerdo4 { get; set; }
        public string Empresa { get; set; }
        public bool AdmiteConvenio { get; set; }
        public bool IncluirEnEstadistica { get; set; }
        public bool PrecargaSeparada { get; set; }
        public bool NoValorizar { get; set; }
        public bool PermiteOCAbierta { get; set; }
        public bool MonitorearObjetivos { get; set; }
        public bool IncluirDeposito3 { get; set; }
    }
}
