using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class ArticuloEnvase : DTOMaestro
    {
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
        public int Cantidad { get; set; }
        [DataMember]
        public decimal PrecioUnitario { get; set; }
        [DataMember]
        public bool Fraccion { get; set; }
        [IgnoreDataMember]
        public string CodigoEnvase { get; set; }
    }
}
