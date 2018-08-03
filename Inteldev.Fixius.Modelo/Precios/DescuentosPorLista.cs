using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Precios
{
    public class DescuentosPorLista:EntidadMaestro
    {
        public DateTime DesdeFecha { get; set; }
        public DateTime HastaFecha { get; set; }
        public ListaDePreciosDeVenta Lista { get; set; }
        public ICollection<ItemDescuentoPorLista> ItemsDescuentos { get; set; }

        public DescuentosPorLista():base()
        {
            this.DesdeFecha = DateTime.Today;
            this.HastaFecha = DateTime.Today;
        }
    }
}
