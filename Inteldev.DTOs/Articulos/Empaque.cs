using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Validaciones;

namespace Inteldev.Fixius.Servicios.DTO.Articulos
{
    [ValidadorAtributo(typeof(ValidadorBase<Empaque>))]
    public class Empaque : DTOMaestro
    {
        public decimal Contenido { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; }
    }
}
