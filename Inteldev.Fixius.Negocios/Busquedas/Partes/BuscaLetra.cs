using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
    public class BuscaLetra<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object Busqueda)
        {
            this.Nombre = "Letra";
            this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()));
            this.SetearParteIzquierda("Letra");
            this.SetearParteDerecha(Busqueda.ToString(), typeof(string));
            this.JuntaExpressionContains();
            
        }
    }
}
