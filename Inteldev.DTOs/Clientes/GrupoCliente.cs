using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    /// <summary>
    /// DTO para GrupoCliente
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorGrupoCliente))]
    public class GrupoCliente : DTOMaestro
    {
        [DataMember]
        public List<Cliente> Clientes { get; set; }

        [DataMember]
        public bool Estadisticos { get; set; }
        [DataMember]
        public bool Financieros { get; set; }
        [DataMember]
        public bool Precios { get; set; }
    }
}
