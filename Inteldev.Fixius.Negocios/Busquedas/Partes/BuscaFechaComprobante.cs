using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
    public class BuscaFechaComprobante<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object Busqueda)
        {
            this.Nombre = "Fecha Comprobante";
            this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()));
            this.SetearParteIzquierda("FechaContable");
            //this.SetearParteDerecha(DateTime.Parse(Busqueda.ToString()),typeof(DateTime));
            this.SetearParteDerecha(Busqueda.ToString(),typeof(DateTime));
            this.JuntaExpressionContains();
        }
    }
}
