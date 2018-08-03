using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
	public enum TipoDocumento : int
	{
        Factura = 0,
        NotaDeCredito = 1,
        NotaDeDebito = 2,
        OrdenDePago = 3,
        LiquidacionBancaria = 4,
        NotaDeCreditoInterno = 5,
        NotadeDébitoInterno = 6
	}
}
