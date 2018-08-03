using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa
{
    public class GrabadorPosicionGpsPreventa : GrabadorDTO<Modelo.Preventa.PosicionGPSPreventa, PosicionGPSPreventa>
    {
        public GrabadorPosicionGpsPreventa(IGrabador<Modelo.Preventa.PosicionGPSPreventa> grabador,IMapeadorGenerico<Modelo.Preventa.PosicionGPSPreventa, PosicionGPSPreventa> mapeador)
            : base(grabador,mapeador)
        {
        }

        public void ActualizarPosicionGPS(string CodigoPreventista, double latitud, double longitud, DateTime fecha)
        {
           
        }
    }
}
