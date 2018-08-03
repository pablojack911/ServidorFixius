using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Auditoria;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.DTO.Stock;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Stock
{
    public class ItemNoIngresado : DTOBase
    {
        public ItemNoIngresado()
        {
            this.Facturas = new List<DocumentoCompra>();
        }
        [DataMember]
        public Proveedor Proveedor { get; set; }
        [DataMember]
        public int? ProveedorId { get; set; }
        [DataMember]
        public EstadoIngresoDeMercaderia Estado { get; set; }
        [DataMember]
        public ICollection<DocumentoCompra> Facturas { get; set; }
        [DataMember]
        public ICollection<ItemNoIngresado> ItemsNoIngresados { get; set; }
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
        public Observacion Observacion { get; set; }
        [DataMember]
        public int ObservacionId { get; set; }
        [DataMember]
        public Motivo Motivo { get; set; }
        [DataMember]
        public int? MotivoId { get; set; }
    }
}
