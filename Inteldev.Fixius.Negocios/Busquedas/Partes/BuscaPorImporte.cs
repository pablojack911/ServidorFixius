using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
    public class BuscaPorImporte<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object busqueda)
        {
            this.Nombre = "Importe";
            decimal Busqueda;
            this.PuedeBuscar = (p => decimal.TryParse(p.ToString(), out Busqueda));
            this.SetearParteIzquierda("Importe");
            decimal.TryParse(busqueda.ToString(),out Busqueda);
            this.SetearParteDerecha(Busqueda,typeof(decimal));
            this.JuntaExpressionIgual();
        }
    }
}
