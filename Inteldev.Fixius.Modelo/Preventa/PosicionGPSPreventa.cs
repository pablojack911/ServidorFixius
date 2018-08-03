using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Preventa
{
    public class PosicionGPSPreventa:EntidadMaestro
    {
        public DateTime Fecha { get; set; }
        public Preventista Preventista { get; set; }
        [ForeignKey("Preventista")]
        public int? PreventistaId { get; set; }
        public Coordenada Coordenadas { get; set; }
    }
}
