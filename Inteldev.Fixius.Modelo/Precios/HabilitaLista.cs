using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Precios
{
    public class HabilitaLista : EntidadMaestro
    {
        public ListaDePreciosDeVenta Lista { get; set; }
        [ForeignKey("Lista")]
        public int? ListaDePreciosDeVentaId { get; set; }

        public string Empresa { get; set; }

        public DivisionComercial DivisionComercial { get; set; }
        [ForeignKey("DivisionComercial")]
        public int? DivisionComercialId { get; set; }    
        
        public UnidadeDeNegocio UnidadDeNegocio { get; set; }

        public Sucursal Sucursal { get; set; }
        [ForeignKey("Sucursal")]
        public int? SucursalId { get; set; }

        public GrupoCliente GrupoCliente { get; set; }
        [ForeignKey("GrupoCliente")]
        public int? GrupoClienteId { get; set; }
                        
    }
}
