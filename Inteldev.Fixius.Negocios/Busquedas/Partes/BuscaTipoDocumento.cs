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
    public class BuscaTipoDocumento<TEntidad> : ParteBusqueda<TEntidad>
        where TEntidad : EntidadBase
    {
        public void Cargar(object Busqueda)
        {
            this.Nombre = "Tipo Documento";
            TipoDocumento documento;
            try
            {
                documento = (TipoDocumento) Enum.Parse(typeof(TipoDocumento), Busqueda.ToString());
                this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()));
                this.SetearParteIzquierda("TipoDocumento");
                this.SetearParteDerecha(documento, typeof(int));
                this.JuntaExpressionIgual();
            }
            catch(ArgumentException ex) {

            }
        }
    }
}
