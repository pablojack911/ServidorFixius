using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Fiscal
{
	
	public enum CondicionAnteIva : int
	{
		[EnumMember]
        [Description("Responsable Inscripto")]
		ResponsableInscripto = 0,
		[EnumMember]
		Monotributo = 1,
		[EnumMember]
		Exento = 2,
        [EnumMember]
        [Description("Consumidor Final")]
        ConsumidorFinal = 3
	}
}
