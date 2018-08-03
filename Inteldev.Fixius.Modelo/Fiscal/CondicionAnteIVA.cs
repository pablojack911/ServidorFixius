﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Fiscal
{
	public enum CondicionAnteIVA : int
	{
        ResponsableInscripto = 0,
        Monotributo = 1,
        Exento = 2,
        ConsumidorFinal = 3
	}
}
