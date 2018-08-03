using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.DTO.Fiscal;
using Inteldev.Core.DTO.Organizacion;
//using Inteldev.Core.Servicios.DTO.Auditoria;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using System.Collections.ObjectModel;
using Inteldev.Fixius.Servicios.DTO.Tesoreria;

namespace Inteldev.Fixius.Servicios.DTO.Proveedores
{
    [Inteldev.Core.DTO.Validaciones.ValidadorAtributo(typeof(Validadores.ValidadorProveedor))]
    public class Proveedor : DTOMaestro
    {
        [DataMember]
        [IncluirEnListado]
        [IncluirEnBuscador]
        public string RazonSocial { get; set; }
        [DataMember]
        private string codigoHistoricoPreventa;
        [IncluirEnBuscador]
        [IncluirEnListado]
        public string CodigoHistoricoPreventa
        {
            get { return codigoHistoricoPreventa; }
            set
            {
                codigoHistoricoPreventa = value;
                this.OnPropertyChanged("CodigoHistoricoPreventa");
            }
        }

        [DataMember]
        private string codigoHistoricoMayorista;
        [IncluirEnListado]
        [IncluirEnBuscador]
        public string CodigoHistoricoMayorista
        {
            get { return codigoHistoricoMayorista; }
            set
            {
                codigoHistoricoMayorista = value;
                this.OnPropertyChanged("CodigoHistoricoMayorista");
            }
        }

        [DataMember]
        public List<Telefono> Telefonos { get; set; }
        [DataMember]
        public string Domicilio { get; set; }
        [DataMember]
        public Localidad Localidad { get; set; }
        [DataMember]
        public int? LocalidadId { get; set; }
        [DataMember]
        public Provincia Provincia { get; set; }
        [DataMember]
        public int? ProvinciaId { get; set; }
        [DataMember]
        public List<Contacto> Contactos { get; set; }
        [DataMember]
        public EstadoProveedor EstadoProveedor { get; set; }
        [DataMember]
        public List<ObservacionProveedor> Observaciones { get; set; }
        //[DataMember]
        //public ObservableCollection<Empresa> Empresas { get; set; }
        [DataMember]
        public bool RequiereDatosDeAutorizacion { get; set; }
        [DataMember]
        public bool EsAgentePercepcionIIBB { get; set; }
        [DataMember]
        public bool EsAgentePercepcionIVA { get; set; }
        [DataMember]
        public List<CondicionDePagoProveedor> CondicionDePago { get; set; }
        [DataMember]
        public FormaDePago FormaDePago { get; set; }
        [DataMember]
        public Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIva CondicionAnteIva { get; set; }
        [DataMember]
        [IncluirEnListado]
        [IncluirEnBuscador]
        public string Cuit { get; set; }
        [DataMember]
        private Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB condicionAnteIIBB;

        public Inteldev.Fixius.Servicios.DTO.Fiscal.CondicionAnteIIBB CondicionAnteIIBB
        {
            get { return condicionAnteIIBB; }
            set
            {
                condicionAnteIIBB = value;
                this.OnPropertyChanged("CondicionAnteIIBB");
                this.OnPropertyChanged("Iibb");
            }
        }

        [DataMember]
        //public String Iibb { get; set; }
        private String iibb;

        public String Iibb
        {
            get { return iibb; }
            set
            {
                iibb = value;
                this.OnPropertyChanged("Iibb");
            }
        }

        [DataMember]
        public List<ConceptoDeMovimiento> ConceptoDeMovimiento { get; set; }
        [DataMember]
        public Entrega Entrega { get; set; }
        [DataMember]
        public DatosOldProveedor DatosOld { get; set; }
        [IgnoreDataMember]
        public PlantillaListaProveedor Plantilla { get; set; }
        [DataMember]
        //public TipoProveedor TipoProveedor { get; set; }
        private TipoProveedor tipoProveedor;

        public TipoProveedor TipoProveedor
        {
            get { return tipoProveedor; }
            set
            {
                tipoProveedor = value;
                this.OnPropertyChanged("TipoProveedor");
            }
        }

        [DataMember]
        public int? TipoProveedorId { get; set; }
        [DataMember]
        public int? PlantillaId { get; set; }
        [DataMember]
        public int VencimientoPagos { get; set; }
        [DataMember]
        public List<ProntoPago> ProntoPago { get; set; }
        [DataMember]
        public List<Banco> Bancos { get; set; }

        public Proveedor()
            : base()
        {
        }

    }
}
