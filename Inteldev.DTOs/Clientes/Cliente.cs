using System;
using System.Collections.Generic;
using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Locacion;
using System.Runtime.Serialization;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using Inteldev.Core.DTO.Validaciones;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using Inteldev.Fixius.Servicios.DTO.Fiscal;
using Inteldev.Fixius.Servicios.DTO.Logistica;


namespace Inteldev.Fixius.Servicios.DTO.Clientes
{
    [ValidadorAtributo(typeof(ValidadorCliente))]
    public class Cliente : DTOMaestro
    {
        [DataMember]
        [IncluirEnBuscador]
        public String NombreFantasia { get; set; }
        [DataMember]
        [IncluirEnBuscador]
        public String Apellido { get; set; }
        [DataMember]
        [IncluirEnBuscador]
        public Domicilio Domicilio { get; set; }//ok
        [DataMember]
        public Provincia Provincia { get; set; }//ok
        [DataMember]
        public int? ProvinciaId { get; set; }
        [DataMember]
        public Localidad Localidad { get; set; }//ok
        [DataMember]
        public int? LocalidadId { get; set; }
        [DataMember]
        public Localidad LocalidadDeEntrega { get; set; }
        [DataMember]
        public int? LocalidadDeEntregaId { get; set; }
        [DataMember]
        public Domicilio LugarEntrega { get; set; }//ok
        [DataMember]
        public string HoraEntrega { get; set; }//ok
        [DataMember]
        public List<Telefono> Telefonos { get; set; }//ok        
        [DataMember]
        public string Email { get; set; }//ok
        [DataMember]
        public DateTime FechaAlta { get; set; }
        [DataMember]
        //public Ramo Ramo { get; set; }//ok
        private Ramo ramo;

        public Ramo Ramo
        {
            get { return ramo; }
            set
            {
                ramo = value;
                this.OnPropertyChanged("Ramo");
                this.OnPropertyChanged("TarjetasCliente");
            }
        }

        [DataMember]
        public int? RamoId { get; set; }
        [DataMember]
        public List<GrupoCliente> GrupoDinamico { get; set; }//ok
        [DataMember]
        public FormaDePago FormaDePago { get; set; }
        //[DataMember]
        //public CondicionDePagoCliente CondicionDePago { get; set; }
        //[DataMember]
        //public int? CondicionDePagoId { get; set; }
        [DataMember]
        public decimal LimiteDeCredito { get; set; }
        //fiscales
        [DataMember]
        private string razonSocial;
        [IncluirEnBuscador]
        public string RazonSocial
        {
            get { return razonSocial; }
            set
            {
                razonSocial = value;
                this.OnPropertyChanged("RazonSocial");
            }
        }

        [DataMember]
        //obligatorio
        //public Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIva CondicionAnteIva { get; set; }
        private CondicionAnteIva condicionAnteIva;

        public CondicionAnteIva CondicionAnteIva
        {
            get { return condicionAnteIva; }
            set
            {
                condicionAnteIva = value;
                this.OnPropertyChanged("CondicionAnteIva");
                this.OnPropertyChanged("Cuit");
                this.OnPropertyChanged("NumeroDocumentoCliente");
            }
        }

        [DataMember]
        private string cuit;
        [IncluirEnBuscador]
        public string Cuit
        {
            get { return cuit; }
            set
            {
                cuit = value;
                this.OnPropertyChanged("Cuit");
                this.OnPropertyChanged("CondicionAnteIva");
                this.OnPropertyChanged("PorcentajePercepcionManual");
            }
        }

        [DataMember]
        //public Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB CondicionAnteIibb { get; set; }//ok
        private Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB condicionAnteIibb;

        public Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB CondicionAnteIibb
        {
            get { return condicionAnteIibb; }
            set
            {
                condicionAnteIibb = value;
                this.OnPropertyChanged("CondicionAnteIibb");
                this.OnPropertyChanged("NumeroIibb");
            }
        }

        [DataMember]
        //public string NumeroIibb { get; set; }
        private string numeroIibb;

        public string NumeroIibb
        {
            get { return numeroIibb; }
            set
            {
                numeroIibb = value;
                this.OnPropertyChanged("NumeroIibb");
            }
        }

        [DataMember]
        //public string NumeroReba { get; set; }
        private string numeroReba;

        public string NumeroReba
        {
            get { return numeroReba; }
            set
            {
                numeroReba = value;
                this.OnPropertyChanged("NumeroReba");
                this.OnPropertyChanged("VencimientoReba");
            }
        }

        [DataMember]
        //public DateTime VencimientoReba { get; set; }
        private DateTime vencimientoReba;

        public DateTime VencimientoReba
        {
            get { return vencimientoReba; }
            set
            {
                vencimientoReba = value;
                this.OnPropertyChanged("VencimientoReba");
            }
        }

        [DataMember]
        public List<TarjetaMayoristaItem> TarjetasCliente { get; set; }
        [DataMember]
        private DatosOldCliente datosOld;

        public DatosOldCliente DatosOld
        {
            get { return datosOld; }
            set
            {
                datosOld = value;
                this.OnPropertyChanged("DatosOld");
            }
        }

        [DataMember]
        public string DomicilioDeEntrega { get; set; }
        [DataMember]
        public List<ConfiguraCredito> ConfiguraCreditos { get; set; }
        [DataMember]
        public bool NoControlaCredito { get; set; }
        [DataMember]
        public List<RutaDeVenta> RutasDeVenta { get; set; }
        [DataMember]
        public bool Inactivo { get; set; }
        [DataMember]
        public bool Suspendido { get; set; }
        [DataMember]
        public bool Legales { get; set; }
        [DataMember]
        public List<ObservacionCliente> ObservacionCliente { get; set; }
        [DataMember]
        public List<ObservacionCliente> ObservacionClienteLogistica { get; set; }
        [DataMember]
        //public decimal PorcentajePercepcionManual { get; set; }
        private decimal porcentajePercepcionManual;

        public decimal PorcentajePercepcionManual
        {
            get { return porcentajePercepcionManual; }
            set
            {
                porcentajePercepcionManual = value;
                this.OnPropertyChanged("PorcentajePercepcionManual");
            }
        }

        [DataMember]
        public TipoDocumentoCliente TipoDocumentoCliente { get; set; }
        [DataMember]
        private string numeroDocumentoCliente;
        [IncluirEnBuscador]
        public string NumeroDocumentoCliente
        {
            get { return numeroDocumentoCliente; }
            set
            {
                numeroDocumentoCliente = value;
                this.OnPropertyChanged("NumeroDocumentoCliente");
                this.OnPropertyChanged("CondicionAnteIva");
            }
        }
        [DataMember]
        private Cliente cuentaPadre;

        public Cliente CuentaPadre
        {
            get { return cuentaPadre; }
            set
            {
                cuentaPadre = value;
                this.OnPropertyChanged("CuentaPadre");
            }
        }

        [DataMember]
        public int? CuentaPadreId { get; set; }

        [DataMember]
        public int? ZonaLogisticaId { get; set; }
        [DataMember]
        public ZonaLogistica ZonaLogistica { get; set; }
        [DataMember]
        public int? ZonaGeograficaId { get; set; }
        [DataMember]
        private RutaDeVenta zonaGeografica;

        public RutaDeVenta ZonaGeografica
        {
            get { return zonaGeografica; }
            set
            {
                zonaGeografica = value;
                this.OnPropertyChanged("ZonaGeografica");
            }
        }

        public Cliente()
            : base()
        {
            VencimientoReba = DateTime.Today;
            FechaAlta = DateTime.Today;
        }

    }
}
