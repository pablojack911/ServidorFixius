using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioProveedor : ServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor, Inteldev.Fixius.Modelo.Proveedores.Proveedor>, IServicioProveedor
    {
        public List<DTO.Financiero.ConceptoDeMovimiento> ObtenerConceptosDeMovimiento(int idProv)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "Proveedor");
            var buscadorDTOProveedor = (BuscadorDTOProveedor)FabricaNegocios.Instancia.Resolver(typeof(BuscadorDTOProveedor), para);
            return buscadorDTOProveedor.ObtenerConceptosDeMovimiento(idProv).ToList();
        }
    }
}
