using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    public class ArticuloCompuesto : DTOMaestro
    {
        [DataMember]
        public Articulo ArticuloComponente { get; set; }
        [DataMember]
        public int? ArticuloComponenteId { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
    }
}
