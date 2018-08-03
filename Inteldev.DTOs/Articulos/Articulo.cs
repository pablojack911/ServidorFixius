using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using System.Runtime.Serialization;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using System.Collections.ObjectModel;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [Inteldev.Core.DTO.Validaciones.ValidadorAtributo(typeof(Validadores.ValidadorArticulo))]
    public class Articulo : DTOMaestro
    {
        [DataMember]
        public string NombreBreve { get; set; }
        //[DataMember]
        //public UnidadeDeNegocio UnidadDeNegocio { get; set; }
        [DataMember]
        public string CodigoDelProveedor { get; set; }
        [DataMember]
        public Proveedor Proveedor { get; set; }
        [DataMember]
        public int? ProveedorId { get; set; }
        [DataMember]
        public Area Area { get; set; }
        [DataMember]
        public int? AreaId { get; set; }
        [DataMember]
        public Sector Sector { get; set; }
        [DataMember]
        public int? SectorId { get; set; }
        [DataMember]
        public Subsector Subsector { get; set; }
        [DataMember]
        public int? SubsectorId { get; set; }
        [DataMember]
        public Familia Familia { get; set; }
        [DataMember]
        public int? FamiliaId { get; set; }
        [DataMember]
        public Subfamilia Subfamilia { get; set; }
        [DataMember]
        public int? SubfamiliaId { get; set; }
        [DataMember]
        public List<GrupoArticulo> Grupo { get; set; }
        [DataMember]
        public Marca Marca { get; set; }
        [DataMember]
        public int? MarcaId { get; set; }
        [DataMember]
        public Empaque Empaque { get; set; }
        [DataMember]
        public int? EmpaqueId { get; set; }
        [DataMember]
        public Caracteristica Caracteristica { get; set; }
        [DataMember]
        public int? CaracteristicaId { get; set; }
        [DataMember]
        public List<CodigoEan> CodigoEAN { get; set; }
        [DataMember]
        public List<CodigoDun> CodigoDUN { get; set; }
        [DataMember]
        public Envase Envase { get; set; }
        [DataMember]
        public int? EnvaseId { get; set; }
        //[DataMember]
        //public Articulo ArticuloEnvase { get; set; }
        [DataMember]
        public List<ArticuloCompuesto> ArticulosCompuestos { get; set; }
        [DataMember]
        public EstadoArticulo Estado { get; set; }
        [DataMember]
        public UnidadDeMedida UnidadDeMedida { get; set; }
        [DataMember]
        public List<ObservacionArticulo> Observaciones { get; set; }
        //[DataMember]
        //public TasasDeIva TasasDeIva { get; set; }
        //[DataMember]
        //public int? TasasId { get; set; }
        [DataMember]
        private EnumTasas tasaDeIva;

        public EnumTasas TasaDeIva
        {
            get { return tasaDeIva; }
            set
            {
                tasaDeIva = value;
                this.OnPropertyChanged("TasaDeIva");
            }
        }

        [DataMember]
        public decimal MargenSugerido { get; set; }
        [DataMember]
        public DatosOldArticulo DatosOld { get; set; }
        [DataMember]
        public bool VentaPorPeso { get; set; }
        [DataMember]
        public bool EsEnvase { get; set; }
    }
}
