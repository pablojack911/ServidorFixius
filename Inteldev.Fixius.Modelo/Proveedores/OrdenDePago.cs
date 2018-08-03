using Inteldev.Core.Modelo.Tesoreria;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Proveedores
{
    public class OrdenDePago : DocumentoProveedor
    {
        public OrdenDePago()
        {
            this.Valores = new List<Valor>();
            this.Aplicaciones = new List<Aplicacion>();
        }
        public ICollection<Valor> Valores { get; set; }
        public ICollection<Aplicacion> Aplicaciones { get; set; }
        public decimal Importe { get; set; }
        public decimal Aplicado { get; set; }
    }
}
