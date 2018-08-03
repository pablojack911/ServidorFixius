using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    [ValidadorAtributo(typeof(ValidadorTarjetaMayoristaItem))]
    public class TarjetaMayoristaItem : DTOMaestro
    {
        [DataMember]
        //public TarjetaClienteMayorista TipoTarjeta { get; set; }
        private TarjetaClienteMayorista tipoTarjeta;

        public TarjetaClienteMayorista TipoTarjeta
        {
            get { return tipoTarjeta; }
            set
            {
                tipoTarjeta = value;
                this.OnPropertyChanged("TipoTarjeta");
            }
        }

        [DataMember]
        public int? TipoTarjetaId { get; set; }
        [DataMember]
        public bool Habilitada { get; set; }
        [IgnoreDataMember]
        public DateTime Fecha { get; set; }
        public override string ToString()
        {
            return TipoTarjeta.Nombre;
        }

        public TarjetaMayoristaItem()
        {
            this.Fecha = DateTime.Today;
        }
    }
}
