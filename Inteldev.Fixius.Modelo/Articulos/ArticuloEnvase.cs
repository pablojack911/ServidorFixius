using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class ArticuloEnvase : EntidadMaestro
    {
        public Articulo Articulo { get; set; }
        public int? ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Fraccion { get; set; }
        public string CodigoEnvase { get; set; }
    }
}
