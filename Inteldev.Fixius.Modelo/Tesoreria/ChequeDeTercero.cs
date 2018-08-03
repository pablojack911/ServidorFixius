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
    public class ChequeDeTercero : EntidadMaestro
    {
        public ChequeDeTercero()
        {
            this.Fecha = DateTime.Now;
            this.FechaEfectivizacion = DateTime.Now;
            this.MovimientoChequeTercero = new List<MovimientoChequeTercero>();
        }
        public DateTime Fecha { get; set; }
        public DateTime FechaEfectivizacion { get; set; }
        public decimal Importe { get; set; }
        public Banco Banco { get; set; }
        [ForeignKey("Banco")]
        public int? BancoId { get; set; }
        public int Numero { get; set; }
        public string Titular { get; set; }
        public string Empresa { get; set; }
        public Sucursal Sucursal { get; set; }
        public int? SucursalId { get; set; }
        public ICollection<MovimientoChequeTercero> MovimientoChequeTercero { get; set; }
    }
}
