using Inteldev.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    public class Columna:DTOBase
    {
        [DataMember]
        public int Orden { get; set; }
        
        [DataMember]
        public string Color { get; set; }
                
        [DataMember]
        public TipoColumna TipoColumna { get; set; }

    }      

    [DataContract]
    public enum TipoColumna
    {
        [EnumMember]
        Neto,
        [EnumMember]
        [Description("Descuento Lineal")]
        DescuentoLineal,
		[EnumMember]
        [Description("Descuento Cascada")]
		DescuentoCascada,
        [EnumMember]
        Recargo,
        [EnumMember]
        Iva,
        [EnumMember]
        [Description("Impuesto Interno")]
        ImpInterno,
        [EnumMember]
        SubTotal,
        [EnumMember]
        Costo,
        [EnumMember]
        Final,
		[EnumMember]
		Cantidad
    }

    [DataContract]
    public enum TipoDescuento
    {
        [EnumMember]
        [Description("En Factura")]
        EnFactura,
        [EnumMember]
        [Description("En Nota de Credito")]
        EnNotaDeCredito
    }
}
