using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
	public enum FormaDePago : int
	{
		[EnumMember]
		Efectivo = 0,
		[EnumMember]
		Cheque = 1,
		[EnumMember]
		Deposito = 2
	}
}
