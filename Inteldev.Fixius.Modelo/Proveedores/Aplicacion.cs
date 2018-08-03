using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class Aplicacion : EntidadMaestro
    {
        public DocumentoCompra DocumentoCompra { get; set; }
        public OrdenDePago OrdenDePago { get; set; }
    }
}
