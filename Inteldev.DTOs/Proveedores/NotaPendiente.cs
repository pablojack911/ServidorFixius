using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class NotaPendiente : DocumentoCompra
    {
        public bool Seleccionado { get; set; }
    }
}
