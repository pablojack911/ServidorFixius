using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Precios
{
    [Table("ListaDePreciosDeVenta")]
    public class ListaDePreciosDeVenta:EntidadMaestro
    {
        public ICollection<ItemListaDePrecioDeVenta> Items { get; set; }
    }
}
