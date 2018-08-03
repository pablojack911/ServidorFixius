using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    /// <summary>
    /// DTO para TarjetaClienteMayorista
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorTarjetaClienteMayorista))]
    public class TarjetaClienteMayorista : DTOMaestro
    {
        [DataMember]
        //public string Desde { get; set; }
        private string desde;

        public string Desde
        {
            get { return desde; }
            set
            {
                desde = value;
                this.OnPropertyChanged("Desde");
                this.OnPropertyChanged("Hasta");
            }
        }

        [DataMember]
        //public string Hasta { get; set; }
        private string hasta;

        public string Hasta
        {
            get { return hasta; }
            set
            {
                hasta = value;
                this.OnPropertyChanged("Hasta");
                this.OnPropertyChanged("Desde");
            }
        }

        [DataMember]
        public TarjetaClienteMayorista Hereda { get; set; }
        [DataMember]
        public int? HeredaId { get; set; }
        [DataMember]
        public List<Ramo> Ramos { get; set; }
        [DataMember]
        public TipoDeTarjetaMayorista Uso { get; set; }
        
    }
    public enum TipoDeTarjetaMayorista : int
    {
        [EnumMember]
        Clientes = 0,
        [Description("Uso Interno")]
        [EnumMember]
        UsoInterno = 1
    }
}
