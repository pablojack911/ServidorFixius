using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Usuarios;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class ObservacionCliente : EntidadBase
    {
        public DateTime FechaHora { get; set; }

        public Usuario Usuario { get; set; }
        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }

        public ObservacionCliente()
        {
            this.FechaHora = DateTime.Now;
        }
    }
}
