using Inteldev.Core.DTO;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Servicios.DTO.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Inteldev.Fixius.Servicios.DTO.Precios
{
    public class HabilitaLista:DTOMaestro
    {
        [DataMember]
        public ListaDePreciosDeVenta Lista { get; set; }
        [DataMember]
        public int? ListaDePreciosDeVentaId { get; set; }
        [DataMember]
        public Empresa Empresa { get; set; }
        [DataMember]
        public DivisionComercial DivisionComercial { get; set; }
        [DataMember]
        public int? DivisionComercialId { get; set; }
        [DataMember]
        public UnidadeDeNegocio UnidadDeNegocio { get; set; }
        [DataMember]
        public Sucursal Sucursal { get; set; }
        [DataMember]
        public int? SucursalId { get; set; }
        [DataMember]
        public GrupoCliente GrupoCliente { get; set; }
        [DataMember]
        public int? GrupoClienteId { get; set; }
    }
}
