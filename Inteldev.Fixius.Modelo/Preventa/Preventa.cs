using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class Preventa : EntidadMaestro
    {
        [UnoAUno]
        public Inteldev.Fixius.Modelo.Preventa.DatosOldPreventa DatosOldPreventa { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Foto { get; set; }
        public string Domicilio { get; set; }
        //public Coordenada Coordenada { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
