using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo
{
    public class ConfiguraEmpresa : EntidadMaestro
    {
        public Empresa Empresa { get; set; }
        [ForeignKey("Empresa")]
        public int? EmpresaId { get; set; }
        public Contexto Contexto { get; set; }
        [ForeignKey("Contexto")]
        public int? ContextoId { get; set; }
    }
}
