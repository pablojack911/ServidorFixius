using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Auditoria;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.DTO.Stock;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using Inteldev.Fixius.Servicios.DTO.Validadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
    [Validator(typeof(ValidadorIngreso))]
	public class Ingreso : DTOMaestro
	{
		public Ingreso()
		{
			this.Facturas = new List<DocumentoCompra>();
            this.OrdenesDeCompra = new List<OrdenDeCompra>();
            
		}
		[DataMember]
		public Proveedor Proveedor { get; set; }
		[DataMember]
		public int? ProveedorId { get; set; }
		[DataMember]
		public List<DocumentoCompra> Facturas { get; set; }
		[DataMember]
		public DataTable Items { get; set; }
		[DataMember]
		public List<OrdenDeCompra> OrdenesDeCompra { get; set; }
		[DataMember]
		public bool Confirmado { get; set; }
		[DataMember]
		public Deposito Deposito { get; set; }
		[DataMember]
		public int? DepositoId { get; set; }
		[DataMember]
		public Sucursal Sucursal { get; set; }
		[DataMember]
		public int? SucursalId { get; set; }
		[DataMember]
		public decimal Neto { get; set; }
		[DataMember]
		public EstadoIngresoDeMercaderia Estado { get; set; }
        [DataMember]
        public List<ItemNoIngresado> ItemsNoIngresados { get; set; }
        [DataMember]
        public Observacion Observacion { get; set; }
        [DataMember]
        public int ObservacionId { get; set; }
	}
}
