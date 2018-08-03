using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    /// <summary>
    /// DTO para Ramo
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorRamo))]
    public class Ramo : DTOMaestro
    {
        /// <summary>
        /// Canal
        /// </summary>
        [DataMember]
        //public Canal Canal { get; set; }
        private Canal canal;

        public Canal Canal
        {
            get { return canal; }
            set
            {
                canal = value;
                this.OnPropertyChanged("Canal");
            }
        }

        /// <summary>
        /// Id de Canal
        /// </summary>
        [DataMember]
        public int? CanalId { get; set; }
        [DataMember]
        public TarjetaClienteMayorista Tarjeta { get; set; }
        [DataMember]
        public int? TarjetaId { get; set; }
    }
}
