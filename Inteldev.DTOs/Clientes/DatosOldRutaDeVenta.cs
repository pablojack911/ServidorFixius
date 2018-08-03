using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    public class DatosOldRutaDeVenta : DTOBase
    {
        [DataMember]
        public AceptaPedidos AceptaPedidos { get; set; }
        [DataMember]
        public bool RecargoPorLogistica { get; set; }
        [DataMember]
        public bool NoFacturar { get; set; }
    }

    public enum AceptaPedidos : int
    {
        [EnumMember]
        [Description("Diferidos Y Urgentes")]
        DifereidosYUrgentes,
        [EnumMember]
        Diferidos,
        [EnumMember]
        [Description("Diferidos Segun Cronograma")]
        DiferidosSegunCronograma
    }
}
