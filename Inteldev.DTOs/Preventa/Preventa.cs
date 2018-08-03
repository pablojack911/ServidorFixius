using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    public class Preventa : DTOMaestro
    {
        [DataMember]
        public Inteldev.Fixius.Servicios.DTO.Preventa.DatosOldPreventa DatosOldPreventa { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        private string foto;

        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                this.OnPropertyChanged("Foto");
            }
        }

        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        //public Coordenada Coordenada { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
