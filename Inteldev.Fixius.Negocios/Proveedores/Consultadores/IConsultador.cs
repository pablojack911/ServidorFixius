using Inteldev.Core.DTO;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Consultadores
{
    public interface IConsultador<TEntidad> where TEntidad : DTOMaestro
    {
        Respuesta<TEntidad> Consulta(Parametros<TEntidad> param);
    }
}
