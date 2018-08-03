using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorFamilia))]
    public class Familia : DTOMaestro
    {
        [DataMember]
        private Subsector subsector;

        public Subsector Subsector
        {
            get { return subsector; }
            set
            {
                subsector = value;
                this.OnPropertyChanged("Subsector");
            }
        }

        [DataMember]
        public int SubsectorId { get; set; }
    }
}
