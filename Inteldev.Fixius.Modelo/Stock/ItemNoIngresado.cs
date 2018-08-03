using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Inteldev.Fixius.Modelo.Stock
{
    public class ItemNoIngresado : EntidadBase
    {
        public ItemNoIngresado()
        {
            this.Facturas = new List<DocumentoCompra>();
            this.Items = new List<ItemIngreso>();
        }
		public Proveedor Proveedor { get; set; }
		[ForeignKey("Proveedor")]
		public int? ProveedorId { get; set; }
		public EstadoIngresoDeMercaderia Estado  { get; set; }
		public ICollection<DocumentoCompra> Facturas { get; set; }
		public ICollection<ItemIngreso> Items { get; set; }
        public ICollection<ItemNoIngresado> ItemsNoIngresados { get; set; }
		public bool Confirmado { get; set; }
		public Deposito Deposito { get; set; }
		[ForeignKey("Deposito")]
		public int? DepositoId { get; set; }
		public Sucursal Sucursal { get; set; }
		[ForeignKey("Sucursal")]
		public int? SucursalId { get; set; }
		public decimal Neto { get; set; }
        public Observacion Observacion { get; set; }
        [ForeignKey("Observacion")]
        public int ObservacionId { get; set; }
        public Motivo Motivo { get; set; }
        [ForeignKey("Motivo")]
        public int? MotivoId { get; set; }
    }
}
