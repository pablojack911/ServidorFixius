using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorEnvase))]
    public class Envase : DTOMaestro
    {
        [DataMember]
        public List<ArticuloEnvase> Articulos { get; set; }
        [DataMember]
        public bool EsCerveza { get; set; }
    }
}
