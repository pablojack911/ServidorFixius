using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Clientes
{
    public class RutaDeVenta : EntidadMaestro
    {
        public RutaDeVenta()
        {
            //this.Clientes = new List<Cliente>();
            this.DiasDeVisita = new DiasDeSemana();
            this.DiasDeEntrega = new DiasDeSemana();
            this.Diferidos = new DiasDeSemana();
            //this.Division = new DivisionComercial();
            //this.DatosOld = new DatosOldRutaDeVenta();
        }
        public string Division { get; set; }

        //public DivisionComercial DivisionComercial { get; set; }
        //[ForeignKey("DivisionComercial")]
        //public int? DivisionId { get; set; }

        public Preventista Titular { get; set; }
        [ForeignKey("Titular")]
        public int? TitularId { get; set; }

        public Preventista Suplente { get; set; }
        [ForeignKey("Suplente")]
        public int? SuplenteId { get; set; }

        public virtual RegionDeVenta RegionDeVenta { get; set; }
        [ForeignKey("RegionDeVenta")]
        public int? RegionDeVentaId { get; set; }

        public string Empresa { get; set; }

        public DiasDeSemana DiasDeEntrega { get; set; }

        public DiasDeSemana DiasDeVisita { get; set; }

        public DiasDeSemana Diferidos { get; set; }

        public bool Activada { get; set; }

        public bool NoValidarCronograma { get; set; }

        [UnoAUno]
        public DatosOldRutaDeVenta DatosOld { get; set; }

        [MuchosAMuchos]
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Coordenada> Vertices { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return this.Codigo;
        }
    }
}
