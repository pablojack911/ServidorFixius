using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.DTO.Contabilidad
{
	public enum EnumTasas : byte
	{
		[EnumMember]
		General = 0,
		[EnumMember]
		Reducida = 1,
		[EnumMember]
		Incrementada = 2
	}
}
