using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorSubfamilia))]
    public class Subfamilia : DTOMaestro
    {
        [DataMember]
        private Familia familia;

        public Familia Familia
        {
            get { return familia; }
            set
            {
                familia = value;
                this.OnPropertyChanged("Familia");
            }
        }

        [DataMember]
        public int FamiliaId { get; set; }
    }
}
