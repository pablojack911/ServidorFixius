using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Fiscal
{
    public enum CondicionAnteIIBB : int
    {
        [EnumMember]
        NoAsignado = 0,
        [EnumMember]
        [Description("No Corresponde/Exento")]
        NoCorrespondeExento = 1,
        [EnumMember]
        [Description("DM 1126/93 (Clientes Cap.Fed.")]
        DMOnceVeitiseis = 2,
        [EnumMember]
        [Description("DN B8, Contr. Local (Clts.Pcia.Bs.As)")]
        DNBOcho = 3,
        [EnumMember]
        [Description("DN B38, Conv. Mult. (Clts.Pcia.Bs.As)")]
        DNBTreintaYOcho = 4
    }
}
