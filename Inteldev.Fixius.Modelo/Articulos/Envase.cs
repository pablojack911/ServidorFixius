using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class Envase : EntidadMaestro
    {
        public ICollection<ArticuloEnvase> Articulos { get; set; }
        public bool EsCerveza { get; set; }

        public Envase()
        {
            this.Articulos = new List<ArticuloEnvase>();
        }

    }
}
