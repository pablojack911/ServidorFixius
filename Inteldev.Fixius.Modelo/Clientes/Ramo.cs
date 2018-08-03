using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class Ramo : EntidadMaestro
    {
        public Canal Canal { get; set; }
        [ForeignKey("Canal")]
        public int? CanalId { get; set; }
        public TarjetaClienteMayorista Tarjeta { get; set; }
        [ForeignKey("Tarjeta")]
        public int? TarjetaId { get; set; }
    }
}
