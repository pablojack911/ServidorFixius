using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    [ValidadorAtributo(typeof(ValidadorRutaDeVenta))]
    public class RutaDeVenta : DTOMaestro
    {
        public RutaDeVenta()
        {
            this.DiasDeVisita = new DiasDeSemana();
            this.Diferidos = new DiasDeSemana();
            this.DiasDeEntrega = new DiasDeSemana();
        }

        [DataMember]
        public List<Cliente> Clientes { get; set; }
        //public Empresa Empresa { get; set; }
        [DataMember]
        private Empresa empresa;

        public Empresa Empresa
        {
            get { return empresa; }
            set
            {
                empresa = value;
                this.OnPropertyChanged("Empresa");
            }
        }

        [DataMember]
        private string division;

        public string Division
        {
            get { return division; }
            set
            {
                division = value;
                this.OnPropertyChanged("Division");
            }
        }


        //[DataMember]
        //private DivisionComercial divisionComercial;

        //public DivisionComercial DivisionComercial
        //{
        //    get { return divisionComercial; }
        //    set
        //    {
        //        divisionComercial = value;
        //        this.OnPropertyChanged("DivisionComercial");
        //    }
        //}

        //[DataMember]
        //public int? DivisionId { get; set; }
        [DataMember]
        public DiasDeSemana DiasDeEntrega { get; set; }
        [DataMember]
        public DiasDeSemana DiasDeVisita { get; set; }
        [DataMember]
        public DiasDeSemana Diferidos { get; set; }
        [DataMember]
        public Preventista Titular { get; set; }
        [DataMember]
        public int? TitularId { get; set; }
        [DataMember]
        public Preventista Suplente { get; set; }
        [DataMember]
        public int? SuplenteId { get; set; }
        [DataMember]
        public bool Activada { get; set; }
        [DataMember]
        public bool NoValidarCronograma { get; set; }
        [DataMember]
        public DatosOldRutaDeVenta DatosOld { get; set; }
        //public RegionDeVenta RegionDeVenta { get; set; } //agregado por Pocho
        [DataMember]
        private RegionDeVenta regionDeVenta;

        public RegionDeVenta RegionDeVenta
        {
            get { return regionDeVenta; }
            set
            {
                regionDeVenta = value;
                this.OnPropertyChanged("RegionDeVenta");
            }
        }

        [DataMember]
        public int? RegionDeVentaId { get; set; }
        [DataMember]
        public List<Coordenada> Vertices { get; set; }
        [DataMember]
        public string Color { get; set; }

        public override string ToString()
        {
            return this.Codigo + " - " + this.Nombre;
        }

    }
}