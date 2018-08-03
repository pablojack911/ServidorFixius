using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo
{
    public class Contexto : EntidadMaestro
    {
        public string Nombre { get; set; }
        public string StringConexion{ get; set; }
    }
}
