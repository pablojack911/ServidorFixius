using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo
{
    public class RelacionEmpresaEntidad : EntidadMaestro
    {
        public Empresa Empresa { get; set; }
        [ForeignKey("Empresa")]
        public int? EmpresaId { get; set; }
        public string Entidad { get; set; }
        public int Grupo { get; set; }
    }
}