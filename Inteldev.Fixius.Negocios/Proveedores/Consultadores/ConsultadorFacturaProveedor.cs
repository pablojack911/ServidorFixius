using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Consultadores
{
    public class ConsultadorFacturaProveedor : IConsultador<Servicios.DTO.Proveedores.Proveedor>
    {
        private IDbContext contexto;

        public ConsultadorFacturaProveedor(IDbContext contexto)
        {
            this.contexto = contexto;
        }

        public Respuesta<Servicios.DTO.Proveedores.Proveedor> Consulta(Core.DTO.Parametros<Servicios.DTO.Proveedores.Proveedor> param)
        {
            var result = this.contexto.Consultar<DocumentoCompra>(CargarRelaciones.NoCargarNada)
               .Where(p => p.ProveedorId == param.Entidad.Id).ToList();
            var mapeador = FabricaNegocios._Resolver<IMapeadorGenerico<Modelo.Proveedores.DocumentoCompra, Servicios.DTO.Proveedores.DocumentoCompra>>();
            var respuesta = new Respuesta<Servicios.DTO.Proveedores.Proveedor>();
            respuesta.Datos = mapeador.ToListDto(result);
            respuesta.Estado = EstadoRespuesta.OK;
            return respuesta;
        }
    }
}
