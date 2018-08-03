using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Logistica
{
    [ValidadorAtributo(typeof(ValidadorZonaLogistica))]
    public class ZonaLogistica : DTOMaestro
    {
        [DataMember]
        public List<Cliente> Clientes { get; set; }

    }
}
