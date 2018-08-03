using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class DatosOldEnvases : DTOBase
    {
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        private Articulo articulo;

        public Articulo Articulo
        {
            get { return articulo; }
            set
            {
                articulo = value;
                this.OnPropertyChanged("Articulo");
            }
        }

        [DataMember]
        public int? ArticuloId { get; set; }
        [DataMember]
        public bool EsCerveza { get; set; }
    }
}
