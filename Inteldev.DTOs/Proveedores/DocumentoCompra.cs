using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Tesoreria;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    //[Inteldev.Core.DTO.Validaciones.ValidadorAtributo(typeof(Validadores.ValidadorDocumentoCompra))]
    public class DocumentoCompra : DocumentoProveedor
    {
        [DataMember]
        private DateTime fechaIngreso;
        [IncluirEnBuscador]
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set
            {
                this.fechaIngreso = value;
                this.OnPropertyChanged("FechaIngreso");
            }
        }
        [DataMember]
        public DateTime FechaContable { get; set; }
        [DataMember]
        private DateTime fechaVencimiento;
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set
            {
                this.fechaVencimiento = value;
                this.OnPropertyChanged("FechaVencimiento");
            }
        }
        [DataMember]
        public FormaDePago FormaDePago { get; set; }
        [DataMember]
        public List<ItemsConceptos> ItemsConceptos { get; set; }
        [DataMember]
        public List<DocumentoProveedor> DocumentosAsociados { get; set; }
        [DataMember]
        private TipoDocumento tipoDocumento { get; set; }
        [IncluirEnBuscador]
        public TipoDocumento TipoDocumento
        {
            get { return tipoDocumento; }
            set
            {
                tipoDocumento = value;
                this.OnPropertyChanged("TipoDocumento");
            }
        }
        [DataMember]
        public decimal Aplicado { get; set; }
        [DataMember]
        private decimal importe;
        [IncluirEnBuscador]
        public decimal Importe
        {
            get { return importe; }
            set
            {
                importe = value;
                this.OnPropertyChanged("Importe");
            }
        }


        [DataMember]
        public ResponsablesCompras Autoriza { get; set; }
        [DataMember]
        public int? AutorizaId { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public CuentaBancaria CuentaBancaria { get; set; }
        [DataMember]
        public MovimientoBancario MovimientoBancario { get; set; }
        [DataMember]
        public ConceptoDeMovimientoBancario ConceptoMovimientoBancario { get; set; }
        [DataMember]
        public List<NotaPendiente> NotasPendientes { get; set; }
    }
}
