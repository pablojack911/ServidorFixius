using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Fiscal
{
    public class PadronIIBB : EntidadMaestro
    {
        public string FechaPublicacion { get; set; }
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        [Index(IsUnique = false)]
        [MaxLength(13)]
        public string CUIT { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string CambioAliCuota { get; set; }
        public Decimal Percepcion { get; set; }
        public Decimal Retencion { get; set; }
        public int GrupoPercepcion { get; set; }
        public int GrupoRetencion { get; set; }
    }
}
