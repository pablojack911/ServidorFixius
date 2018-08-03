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
    [ValidadorAtributo(typeof(ValidadorSubsector))]
    public class Subsector : DTOMaestro
    {
        [DataMember]
        private Sector sector;

        public Sector Sector
        {
            get { return sector; }
            set
            {
                sector = value;
                this.OnPropertyChanged("Sector");
            }
        }

        [DataMember]
        public int SectorId { get; set; }
    }
}
