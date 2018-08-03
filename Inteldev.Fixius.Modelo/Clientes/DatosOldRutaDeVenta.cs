using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class DatosOldRutaDeVenta : EntidadBase
    {
        public AceptaPedidos AceptaPedidos { get; set; }
        public bool RecargoPorLogistica { get; set; }
        public bool NoFacturar { get; set; }
    }

    public enum AceptaPedidos : int
    {
        DiferidosYUrgentes,
        Diferidos,
        DiferidosSegunCronograma
    }
}
