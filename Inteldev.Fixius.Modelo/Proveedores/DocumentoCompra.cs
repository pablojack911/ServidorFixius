using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Tesoreria;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class DocumentoCompra : DocumentoProveedor
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaContable { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public ICollection<ItemsConceptos> ItemsConceptos { get; set; }
        public ICollection<DocumentoProveedor> DocumentosAsociados { get; set; }
        public decimal Aplicado { get; set; }
        public decimal Importe { get; set; }
        public ResponsablesCompras Autoriza { get; set; }
        [ForeignKey("Autoriza")]
        public int? AutorizaId { get; set; }
        public string Motivo { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [NotMapped]
        public CuentaBancaria CuentaBancaria { get; set; }
        [NotMapped]
        public MovimientoBancario MovimientoBancario { get; set; }
        [NotMapped]
        public ConceptoDeMovimientoBancario ConceptoMovimientoBancario { get; set; }
        [NotMapped]
        public List<NotaPendiente> NotasPendientes { get; set; }
        public DocumentoCompra():base()
        {
            this.FechaIngreso = DateTime.Now;
            this.FechaContable = DateTime.Now;
            this.FechaVencimiento = DateTime.Now;
            this.ItemsConceptos = new List<ItemsConceptos>();
            this.DocumentosAsociados = new List<DocumentoProveedor>();
            this.NotasPendientes = new List<NotaPendiente>();
        }
    }
}
