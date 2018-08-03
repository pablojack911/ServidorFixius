using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Modelo;

namespace Inteldev.Fixius.Modelo.Articulos
{
    public class CodigoEan : EntidadBase
    {
        public string CodigoDeBarra { get; set; }
        public int? UnidadesPorBulto { get; set; }
        public int? UnidadesPorPack { get; set; }

        //public int? UnidadesPorPallet { get; set; }
        //public int? UnidadesPorBase { get; set; }
        //public int? UnidadesPorAltura { get; set; }
        public bool Activo { get; set; }
    }
}
