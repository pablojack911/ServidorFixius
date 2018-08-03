using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class CoordenadaCliente : EntidadMaestro
    {
        public string Observacion { get; set; }
        public string Icono { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Domicilio { get; set; }
        public int Orden { get; set; }
    }
}
