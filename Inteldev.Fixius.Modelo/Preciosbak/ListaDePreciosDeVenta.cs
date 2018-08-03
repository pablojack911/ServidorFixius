using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Precios
{
    public class ListaDePreciosDeVenta:EntidadMaestro
    {
        public virtual ICollection<ItemListaDePrecioDeVenta> Items { get; set; }
    }
}
