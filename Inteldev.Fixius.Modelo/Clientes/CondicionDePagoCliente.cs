using Inteldev.Core.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inteldev.Fixius.Modelo.Clientes
{
    [Table("CondicionDePagoCliente")]
    public class CondicionDePagoCliente : EntidadMaestro
    {
        public int CantidadDeDias { get; set; }
        public ModoDePago ModoDePago { get; set; }
        public CondicionDePagoCliente()
            : base()
        {
        }
    }

    public enum ModoDePago : int
    {
        Contado = 0,
        CuentaCorriente = 1
    }
}
