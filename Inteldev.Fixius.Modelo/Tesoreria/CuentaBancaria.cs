using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Tesoreria
{
    public class CuentaBancaria : EntidadMaestro
    {
        public CuentaBancaria()
        {
            this.MovimientosBancarios = new List<MovimientoBancario>();
        }
        public Banco Banco { get; set; }
        [ForeignKey("Banco")]
        public int? BancoId { get; set; }
        public string Empresa { get; set; }
        public ICollection<MovimientoBancario> MovimientosBancarios { get; set; }
    }
}
