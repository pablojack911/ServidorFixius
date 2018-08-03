using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class ListaDePreciosColumna:EntidadBase
    {
        public Columna Columna { get; set; }
		[ForeignKey("Columna")]
		public int? ColumnaId { get; set; }
        
		public decimal Valor { get; set; }
    }
}
