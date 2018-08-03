using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class BuscadorId
    {
        public int Buscar<TEntidad>(IDbContext contexto, string valor) where TEntidad:EntidadMaestro
        {
            var entidad = contexto.BuscarPorCodigo<TEntidad>(valor, Core.CargarRelaciones.NoCargarNada);

            if (entidad != null)
                return entidad.Id;
            else
               return 0;
        }
            
    }
}
