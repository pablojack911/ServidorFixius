using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    public class CuentaBancaria : DTOMaestro
    {
        [DataMember]
        public Banco Banco { get; set; }
        [DataMember]
        public int? BancoId { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public List<MovimientoBancario> MovimientosBancarios { get; set; }
    }
}
