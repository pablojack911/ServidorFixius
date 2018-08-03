using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class NotaPendiente : DocumentoCompra
    {
        public bool Seleccionado { get; set; }
    }
}
