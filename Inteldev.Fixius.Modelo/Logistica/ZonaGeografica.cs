using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Logistica
{
    public class ZonaGeografica : EntidadMaestro
    {
        public ZonaGeografica()
        {
            this.Vertices = new List<Coordenada>();
        }
        public Provincia Provincia { get; set; }
        [ForeignKey("Provincia")]
        public int? ProvinciaId { get; set; }
        public Localidad Localidad { get; set; }
        [ForeignKey("Localidad")]
        public int? LocalidadId { get; set; }
        public ICollection<Coordenada> Vertices { get; set; }
    }
}
