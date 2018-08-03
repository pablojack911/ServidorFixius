using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class ListaDePrecios:EntidadMaestro
    {
        public Proveedor Proveedor { get; set; }
		[ForeignKey("Proveedor")]
		public int? ProveedorId { get; set; }

        public DateTime Vigencia { get; set; }
        public ICollection<ObservacionProveedor> Observaciones { get; set; }
        public ICollection<ListaDePreciosDetalle> Detalle { get; set; }

        public ListaDePrecios():base()
        {
            this.Vigencia = DateTime.Today;
        }

    }

}
