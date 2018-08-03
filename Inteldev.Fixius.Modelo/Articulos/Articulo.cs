using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
//using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Core.Modelo.Fiscal;
using System.ComponentModel.DataAnnotations.Schema;
using Inteldev.Fixius.Modelo.Contabilidad;


namespace Inteldev.Fixius.Modelo.Articulos
{
    [Table("Articulos")]
    public class Articulo : EntidadMaestro
    {
        public Articulo()
            : base()
        {
            this.Grupo = new List<GrupoArticulo>();
            this.CodigoEAN = new List<CodigoEan>();
            this.CodigoDUN = new List<CodigoDun>();
            this.ArticulosCompuestos = new List<ArticuloCompuesto>();
            this.Observaciones = new List<ObservacionArticulo>();
            //this.DatosOld = new DatosOld(); //delegado al creadorArticulo
        }

        public string NombreBreve { get; set; }
        //public UnidadeDeNegocio UnidadDeNegocio { get; set; }
        public string CodigoDelProveedor { get; set; }

        public Proveedor Proveedor { get; set; }
        [ForeignKey("Proveedor")]
        public int? ProveedorId { get; set; }

        public Area Area { get; set; }
        [ForeignKey("Area")]
        public int? AreaId { get; set; }

        public Sector Sector { get; set; }
        [ForeignKey("Sector")]
        public int? SectorId { get; set; }

        public Subsector Subsector { get; set; }
        [ForeignKey("Subsector")]
        public int? SubsectorId { get; set; }

        public Familia Familia { get; set; }
        [ForeignKey("Familia")]
        public int? FamiliaId { get; set; }

        public Subfamilia Subfamilia { get; set; }
        [ForeignKey("Subfamilia")]
        public int? SubFamiliaId { get; set; }

        [MuchosAMuchos]
        public ICollection<GrupoArticulo> Grupo { get; set; }

        public Marca Marca { get; set; }
        [ForeignKey("Marca")]
        public int? MarcaId { get; set; }

        public Empaque Empaque { get; set; }
        [ForeignKey("Empaque")]
        public int? EmpaqueId { get; set; }

        public Caracteristica Caracteristica { get; set; }
        [ForeignKey("Caracteristica")]
        public int? CaracteristicaId { get; set; }

        public ICollection<CodigoEan> CodigoEAN { get; set; }
        public ICollection<CodigoDun> CodigoDUN { get; set; }

        public Envase Envase { get; set; }
        [ForeignKey("Envase")]
        public int? EnvaseId { get; set; }

        //public Articulo ArticuloEnvase { get; set; }
        public ICollection<ArticuloCompuesto> ArticulosCompuestos { get; set; }

        public EstadoArticulo Estado { get; set; }

        public UnidadDeMedida UnidadDeMedida { get; set; }

        public ICollection<ObservacionArticulo> Observaciones { get; set; }

        //public TasasDeIva TasasDeIva { get; set; }
        //[ForeignKey("TasasDeIva")]
        //public int? TasasId { get; set; }

        public EnumTasas TasaDeIVA { get; set; }

        public decimal MargenSugerido { get; set; }
        [UnoAUno]
        public DatosOldArticulo DatosOld { get; set; }

        public bool VentaPorPeso { get; set; }
        public bool EsEnvase { get; set; }


    }
}
