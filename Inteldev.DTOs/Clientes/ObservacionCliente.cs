using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Usuarios;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    [ValidadorAtributo(typeof(ValidadorObservacion))]
    public class ObservacionCliente : DTOBase
    {
        [DataMember]
        public DateTime FechaHora { get; set; }
        [DataMember]
        public Usuario Usuario { get; set; }
        [DataMember]
        public int? UsuarioId { get; set; }

        public ObservacionCliente()
            : base()
        {
            this.FechaHora = DateTime.Now;
        }
    }
}
