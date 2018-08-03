using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Fiscal;
using Inteldev.Core.Modelo.Locacion;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Inteldev.Fixius.Modelo.Financiero;
using System.Xml.Serialization;
using Inteldev.Fixius.Modelo.Tesoreria;
using Inteldev.Fixius.Modelo.Fiscal;
//using Inteldev.Core.Modelo.Auditoria;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    [Table("Proveedores")]
    public class Proveedor : EntidadMaestro
    {

        #region Escalares

        public string CodigoHistoricoPreventa { get; set; }
        public string CodigoHistoricoMayorista { get; set; }
        public string RazonSocial { get; set; }//ok
        public string Cuit { get; set; }//ok
        public string Iibb { get; set; }//ok
        public string Domicilio { get; set; }//ok
        public int VencimientoPagos { get; set; }

        public bool RequiereDatosDeAutorizacion { get; set; }//ok

        public bool EsAgentePercepcionIIBB { get; set; }

        public bool EsAgentePercepcionIVA { get; set; }

        public FormaDePago FormaDePago { get; set; }//ok

        public CondicionAnteIVA CondicionAnteIva { get; set; }//ok

        public CondicionAnteIIBB CondicionAnteIIBB { get; set; }//ok

        public EstadoProveedor EstadoProveedor { get; set; }//ok

        #endregion

        #region FK's

        public Localidad Localidad { get; set; }
        [ForeignKey("Localidad")]
        public int? LocalidadId { get; set; }

        public Provincia Provincia { get; set; }//ok
        [ForeignKey("Provincia")]
        public int? ProvinciaId { get; set; }

        public PlantillaListaProveedor Plantilla { get; set; }
        [ForeignKey("Plantilla")]
        public int? PlantillaId { get; set; }

        public Entrega Entrega { get; set; }
        [ForeignKey("Entrega")]
        public int? EntregaId { get; set; }

        public TipoProveedor TipoProveedor { get; set; }
        [ForeignKey("TipoProveedor")]
        public int? TipoProveedorId { get; set; }

        #endregion

        #region Uno A Uno



        [UnoAUno]
        public DatosOldProveedor DatosOld { get; set; }

        #endregion

        #region Uno a Muchos

        [UnoAMuchos]
        public ICollection<Telefono> Telefonos { get; set; }//ok

        [UnoAMuchos]
        public ICollection<Contacto> Contactos { get; set; } //ok

        [UnoAMuchos]
        public ICollection<ObservacionProveedor> Observaciones { get; set; }

        [UnoAMuchos]
        public ICollection<ProntoPago> ProntoPago { get; set; }

        #endregion

        #region Muchos a Muchos

        [MuchosAMuchos]
        public ICollection<CondicionDePagoProveedor> CondicionDePago { get; set; }//ok

        [MuchosAMuchos]
        public ICollection<ConceptoDeMovimiento> ConceptoDeMovimiento { get; set; } //ok

        [MuchosAMuchos]
        public ICollection<Banco> Bancos { get; set; }

        #endregion

        //public ICollection<Empresa> Empresas { get; set; } ????

        #region Constructor

        public Proveedor()
            : base()
        {
            this.ConceptoDeMovimiento = new List<ConceptoDeMovimiento>();
            this.Telefonos = new List<Telefono>();
            this.Contactos = new List<Contacto>();
            this.Observaciones = new List<ObservacionProveedor>();
            this.CondicionDePago = new List<CondicionDePagoProveedor>();
            this.Bancos = new List<Banco>();
            this.ProntoPago = new List<ProntoPago>();
        }

        #endregion Constructor
    }
}
