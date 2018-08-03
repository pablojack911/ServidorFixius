using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public enum TipoCambioDePreciosDeVenta:int
    {
        [EnumMember]
        Simulacion = 0,
        [EnumMember]
        [Description("Cambio Programado")]
        CambioProgramado = 1,
        [EnumMember]
        Folder = 2
    }
}
