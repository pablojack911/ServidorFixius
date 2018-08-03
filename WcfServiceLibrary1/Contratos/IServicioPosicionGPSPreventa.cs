using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios.Contratos
{
    public interface IServicioPosicionGPSPreventa
    {
        ObservableCollection<IServicioPosicionGPSPreventa> ObtenerPosiciones();
        void ActualizarPosicionGPS(string CodigoPreventista, double latitud, double longitud, DateTime fecha);
    }
}
