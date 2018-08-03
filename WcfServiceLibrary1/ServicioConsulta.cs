using Inteldev.Core.Contratos;
using Inteldev.Core.DTO;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Negocios.Proveedores.Consultadores;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioConsulta<TEntidad> : IServicioConsulta<TEntidad>
        where TEntidad : DTOMaestro
    {

        public Respuesta<TEntidad> Consultar(Parametros<TEntidad> parametros)
        {
            var consultador = FabricaNegocios._Resolver<IConsultador<TEntidad>>();
            var respuesta = new Respuesta<TEntidad>();
            respuesta.Datos = consultador.Consulta(parametros);
            return respuesta;
        }
    }
}
