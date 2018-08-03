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
    [ValidadorAtributo(typeof(ValidadorSector))]
    public class Sector : DTOMaestro
    {
        [DataMember]
        private Area area;

        public Area Area
        {
            get { return area; }
            set
            {
                area = value;
                this.OnPropertyChanged("Area");
            }
        }

        [DataMember]
        public int AreaId { get; set; }
    }
}
