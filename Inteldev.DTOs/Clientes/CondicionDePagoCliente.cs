using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    /// <summary>
    /// DTO de CondicionDePagoCliente
    /// </summary>
    [ValidadorAtributo(typeof(ValidadorCondicionDePagoCliente))]
    public class CondicionDePagoCliente : DTOMaestro
    {
        [DataMember]
        public int CantidadDeDias { get; set; }
        [DataMember]
        public ModoDePago ModoDePago { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }
    }


    public enum ModoDePago : int
    {
        [EnumMember]
        Contado = 0,
        [Description("Cuenta Corriente")]
        [EnumMember]
        CuentaCorriente = 1
    }

}
