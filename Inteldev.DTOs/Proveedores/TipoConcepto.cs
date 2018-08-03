using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public enum TipoConcepto : int
    {
        [EnumMember]
        Neto1,
        [EnumMember]
        Neto2,
        [EnumMember]
        Neto3,
        [EnumMember]
        Exento,
        [EnumMember]
        IvaTasaGeneral,
        [EnumMember]
        IvaTasaReducida,
        [EnumMember]
        IvaTasaDiferencial,
        [EnumMember]
        PercepcionIva,
        [EnumMember]
        [Description("Percepcion IIBB")]
        PercepcionIIBB,
        [EnumMember]
        ImpuestoInterno,
        [EnumMember]
        Final
    }
}
