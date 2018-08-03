using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Preventa
{
    /// <summary>
    /// DTO para Jefe
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorPreventa))]
    public class Jefe : Preventa
    {
        [DataMember]
        public List<Supervisor> Supervisores { get; set; }

    }
}
