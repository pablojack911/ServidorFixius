using Inteldev.Fixius.Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioPosicionGPSPreventa : IServicioPosicionGPSPreventa
    {
        public System.Collections.ObjectModel.ObservableCollection<IServicioPosicionGPSPreventa> ObtenerPosiciones()
        {
            throw new NotImplementedException();
        }

        public void ActualizarPosicionGPS(string CodigoPreventista, double latitud, double longitud, DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
