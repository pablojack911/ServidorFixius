using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Tesoreria
{
    [ValidadorAtributo(typeof(ValidadorBase<Banco>))]
    public class Banco : DTOMaestro
    {
        [IgnoreDataMember]
        public List<Proveedor> Proveedores { get; set; }
    }
}
