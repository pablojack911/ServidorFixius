using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class GrupoArticulo : EntidadMaestro
    {
        public GrupoArticulo()
        {
            this.Articulos = new List<Articulo>();
        }
        public ICollection<Articulo> Articulos { get; set; }
    }
}
