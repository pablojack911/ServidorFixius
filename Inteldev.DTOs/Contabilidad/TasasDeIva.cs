using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Contabilidad
{
    [ValidadorAtributo(typeof(ValidadorBase<TasasDeIva>))]
    public class TasasDeIva : DTOMaestro
    {
        [DataMember]
        public decimal Valor { get; set; }
        [DataMember]
        public EnumTasas Enum { get; set; }
    }
}
