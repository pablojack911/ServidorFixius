using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Logistica
{
    [ValidadorAtributo(typeof(ValidadorZonaGeografica))]
    public class ZonaGeografica : DTOMaestro
    {
        [DataMember]
        private Provincia provincia;

        public Provincia Provincia
        {
            get { return provincia; }
            set
            {
                provincia = value;
                this.OnPropertyChanged("Provincia");
            }
        }

        [DataMember]
        public int? ProvinciaId { get; set; }
        [DataMember]
        private Localidad localidad;

        public Localidad Localidad
        {
            get { return localidad; }
            set
            {
                localidad = value;
                this.OnPropertyChanged("Localidad");
            }
        }

        [DataMember]
        public int? LocalidadId { get; set; }
        [DataMember]
        public List<Coordenada> Vertices { get; set; }
    }
}
