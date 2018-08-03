using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorRubro))]
    public class Rubro : DTOMaestro
    {
        [DataMember]
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [DataMember]
        public int? CondicionDePagoId { get; set; }
        [DataMember]
        public bool NoIncluirEnListaDePrecios { get; set; }
        [DataMember]
        public bool AdmiteConvenio { get; set; }
        [DataMember]
        public decimal Acuerdo1 { get; set; }
        [DataMember]
        public decimal Acuerdo2 { get; set; }
        [DataMember]
        public decimal Acuerdo3 { get; set; }
        [DataMember]
        public decimal Acuerdo4 { get; set; }
    }
}
