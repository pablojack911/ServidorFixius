using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
    public class BuscaCuitProveedor<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object Busqueda) 
        {
            this.Nombre = "CUIT Proveedor";
            this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()));
            this.SetearParteIzquierda("Proveedor","Cuit",typeof(string));
            this.SetearParteDerecha(Busqueda.ToString(),typeof(string));
            this.JuntaExpressionIgual();
        }
    }
}
