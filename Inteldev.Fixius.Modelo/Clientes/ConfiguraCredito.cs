using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class ConfiguraCredito : EntidadBase
    {
        public decimal Limite { get; set; }
        public Vendedor Vendedor { get; set; }
        [ForeignKey("Vendedor")]
        public int? VendedorId { get; set; }
        public Cobrador Cobrador { get; set; }
        [ForeignKey("Cobrador")]
        public int? CobradorId { get; set; }
        public Vendedor VendedorEspecial { get; set; }
        [ForeignKey("VendedorEspecial")]
        public int? VendedorEspecialId { get; set; }
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [ForeignKey("CondicionDePago")]
        public int? CondicionDePagoId { get; set; }
        public CondicionDePagoCliente CondicionDePago2 { get; set; }
        [ForeignKey("CondicionDePago2")]
        public int? CondicionDePago2Id { get; set; }
        public bool RespetarCondicionDePago2 { get; set; }

        public UnidadeDeNegocio UnidadDeNegocio { get; set; }
        
        
    }


    
}
