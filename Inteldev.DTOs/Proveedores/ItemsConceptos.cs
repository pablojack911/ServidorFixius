using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class ItemsConceptos : DTOBase, INotifyPropertyChanged
    {
        [DataMember]
        private TipoConcepto tipo;
        public TipoConcepto Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Tipo"));
            }
        }
        [DataMember]
        private decimal debe;

        public decimal Debe
        {
            get { return debe; }
            set
            {
                debe = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Debe"));
            }
        }


        [DataMember]
        private decimal haber;

        public decimal Haber
        {
            get { return haber; }
            set
            {
                haber = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Haber"));
            }
        }

        [DataMember]
        private ConceptoDeMovimiento concepto;

        public ConceptoDeMovimiento Concepto
        {
            get { return concepto; }
            set
            {
                concepto = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Concepto"));
                }
            }
        }
        [DataMember]
        public int? ConceptoId { get; set; }

        //[DataMember]
        //public int HashNeto { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
