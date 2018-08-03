using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Fiscal;
using System.ComponentModel.DataAnnotations.Schema;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Precios;
using Inteldev.Fixius.Modelo.Logistica;

namespace Inteldev.Fixius.Modelo.Clientes
{
    [Table("Clientes")]
    public class Cliente : EntidadMaestro
    {

        #region Foreign Key

        [ForeignKey("ZonaGeografica")]
        public int? ZonaGeograficaId { get; set; }
        public RutaDeVenta ZonaGeografica { get; set; }

        public Provincia Provincia { get; set; }
        [ForeignKey("Provincia")]
        public int? ProvinciaId { get; set; }

        public Localidad Localidad { get; set; }
        [ForeignKey("Localidad")]
        public int? LocalidadId { get; set; }

        public Localidad LocalidadDeEntrega { get; set; }
        [ForeignKey("LocalidadDeEntrega")]
        public int? LocalidadDeEntregaId { get; set; }

        public Ramo Ramo { get; set; }
        [ForeignKey("Ramo")]
        public int? RamoId { get; set; }

        public Cliente CuentaPadre { get; set; }
        [ForeignKey("CuentaPadre")]
        public int? CuentaPadreId { get; set; }

        //public CondicionDePagoCliente CondicionDePago { get; set; }
        //[ForeignKey("CondicionDePago")]
        //public int? CondicionDePagoId { get; set; }

        [ForeignKey("ZonaLogistica")]
        public int? ZonaLogisticaId { get; set; }
        public ZonaLogistica ZonaLogistica { get; set; }

        #endregion Foreign Key

        #region Uno A Uno

        [UnoAUno]
        public DatosOldCliente DatosOld { get; set; }

        [UnoAUno]
        public Domicilio Domicilio { get; set; }

        [UnoAUno]
        public Domicilio LugarEntrega { get; set; }


        #endregion Uno A Uno

        #region Uno A Muchos

        [UnoAMuchos]
        public ICollection<ConfiguraCredito> ConfiguraCreditos { get; set; }

        [UnoAMuchos]
        public ICollection<ObservacionCliente> ObservacionCliente { get; set; }

        [UnoAMuchos]
        public ICollection<ObservacionCliente> ObservacionClienteLogistica { get; set; }

        [UnoAMuchos]
        public ICollection<TarjetaMayoristaItem> TarjetasCliente { get; set; }

        [UnoAMuchos]
        public ICollection<Telefono> Telefonos { get; set; }

        #endregion Uno A Muchos

        #region Muchos A Muchos

        [MuchosAMuchos]
        public ICollection<GrupoCliente> GrupoDinamico { get; set; }

        //[MuchosAMuchos]
        //[NoIncluirColecciones]
        public ICollection<RutaDeVenta> RutasDeVenta { get; set; }

        #endregion Muchos A Muchos

        #region Escalares

        public string HoraEntrega { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public FormaDePago FormaDePago { get; set; }
        public decimal LimiteDeCredito { get; set; }
        public string RazonSocial { get; set; }
        public Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA CondicionAnteIva { get; set; }
        public string Cuit { get; set; }
        public Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIIBB CondicionAnteIibb { get; set; }
        public string NumeroIibb { get; set; }
        public string NumeroReba { get; set; }
        public DateTime VencimientoReba { get; set; }
        public string DomicilioDeEntrega { get; set; }
        public bool NoControlaCredito { get; set; }
        #region EstadoCliente
        public bool Inactivo { get; set; }
        public bool Suspendido { get; set; }
        public bool Legales { get; set; }
        #endregion
        public decimal PorcentajePercepcionManual { get; set; }
        public TipoDocumentoCliente TipoDocumentoCliente { get; set; }
        public String NumeroDocumentoCliente { get; set; }
        public String NombreFantasia { get; set; }
        public String Apellido { get; set; }

        #endregion Escalares

        public Cliente()
            : base()
        {
            VencimientoReba = DateTime.Today;
            FechaAlta = DateTime.Today;
            this.GrupoDinamico = new List<GrupoCliente>();
            this.RutasDeVenta = new List<RutaDeVenta>();
            this.Telefonos = new List<Telefono>();
            this.TarjetasCliente = new List<TarjetaMayoristaItem>();
            //this.DatosOld = new DatosOldCliente();
            this.ConfiguraCreditos = new List<ConfiguraCredito>();
            this.ObservacionCliente = new List<ObservacionCliente>();
            this.ObservacionClienteLogistica = new List<ObservacionCliente>();
        }

        public override string ToString()
        {
            return string.Format("Id: {0}", this.Id);

        }
    }
}
