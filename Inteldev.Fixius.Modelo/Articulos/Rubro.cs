using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Articulos
{
    [Table("Rubros")]
    public class Rubro : EntidadMaestro
    {
        public CondicionDePagoCliente CondicionDePago { get; set; }
        [ForeignKey("CondicionDePago")]
        public int? CondicionDePagoId { get; set; }
        public bool NoIncluirEnListaDePrecios { get; set; }
        public bool AdmiteConvenio { get; set; }
        public decimal Acuerdo1 { get; set; }
        public decimal Acuerdo2 { get; set; }
        public decimal Acuerdo3 { get; set; }
        public decimal Acuerdo4 { get; set; }
    }
}
