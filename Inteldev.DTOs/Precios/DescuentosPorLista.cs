using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public class DescuentosPorLista:DTOMaestro
    {
        [DataMember]
        public DateTime DesdeFecha { get; set; }
        [DataMember]
        public DateTime HastaFecha { get; set; }
        [DataMember]
        public ListaDePreciosDeVenta Lista { get; set; }
        [DataMember]
        public List<ItemDescuentoPorLista> ItemsDescuentos { get; set; }

        public DescuentosPorLista():base()
        {
            this.DesdeFecha = DateTime.Today;
            this.HastaFecha = DateTime.Today;
        }
    }
}
