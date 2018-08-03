using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class DatosOldCondicionDePagoCliente : DTOBase
    {
        [DataMember]
        public int ModoFac { get; set; }
        [DataMember]
        public int Dias { get; set; }
    }
}
