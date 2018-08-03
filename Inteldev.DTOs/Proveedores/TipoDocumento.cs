using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public enum TipoDocumento : int
    {
        [EnumMember]
        Factura = 0,
        [EnumMember]
        [Description("Nota de Credito")]
        NotaDeCredito = 1,
        [EnumMember]
        [Description("Nota de Debito")]
        NotaDeDebito = 2,
        [EnumMember]
        OrdenDePago = 3,
        [EnumMember]
        [Description("Liquidación Bancaria")]
        LiquidacionBancaria = 4,
        [DataMember]
        NotaDeCreditoInterno = 5,
        [DataMember]
        NotadeDébitoInterno = 6

    }
}
