using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BuscadorOrdenDePago : BuscadorGenerico<Modelo.Proveedores.OrdenDePago>, Inteldev.Fixius.Negocios.Proveedores.Buscadores.IBuscadorOrdenDePago
    {
        public BuscadorOrdenDePago(string empresa, string entidad) : base(empresa,entidad) { }
        /// <summary>
        /// Busca entre los documentos de compra aquellos cuyo importe sea distinto al aplicado
        /// </summary>
        /// <returns>lista de documentos de compra</returns>
        public List<OrdenDePago> BuscaNoAplicados(int ProveedorId)
        {
            return this.Contexto.Consultar<OrdenDePago>(CargarRelaciones.NoCargarNada)
                .Where(p=>p.Aplicado != p.Importe && p.ProveedorId == ProveedorId).ToList();
        }
    }
}
