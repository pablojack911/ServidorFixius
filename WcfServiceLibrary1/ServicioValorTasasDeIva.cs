using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioValorTasasDeIva : IServicioValorTasasDeIva
    {
        public decimal ObtenerValorDeTasaDeIVA(EnumTasas tasa)
        {
            Decimal valor = 0;
            if (tasa == EnumTasas.General)
                valor = 21;
            else
                if (tasa == EnumTasas.Reducida)
                    valor = 10.5m;
                else
                    valor = 27;
            return valor;
        }
    }
}
