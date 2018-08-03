using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Busquedas.Partes
{
    public class BuscaCodigoProveedor<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object Busqueda)
        {
            this.Nombre = "Proveedor";
            this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()));
            this.SetearParteIzquierda("Proveedor","Codigo",typeof(Proveedor));
            this.SetearParteDerecha(Busqueda.ToString(), typeof(string));
            this.JuntaExpressionContains();
        }
    }
}
