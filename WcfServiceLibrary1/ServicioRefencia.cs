using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Contabilidad;
using Inteldev.Fixius.Negocios.Fiscales;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;
using Inteldev.Fixius.Servicios.DTO.Financiero;
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
    public class ServicioRefencia : IServicioReferencia
    {

        public decimal ObtenerTasa(DTO.Proveedores.TipoConcepto tipoConcepto)
        {
            var buscadorTasa = FabricaNegocios._Resolver<IBuscadorTasa>();
            return buscadorTasa.ObtenerTasa(tipoConcepto);
        }

        public ConceptoDeMovimiento ObtenerConcepto(Empresa empresa, TipoDocumento tipoDocumento, TipoConcepto tipoConcepto)
        {
            var buscadorRefencia = FabricaNegocios._Resolver<BuscadorReferencia>();
            buscadorRefencia.BuscarReferencia(empresa,tipoDocumento,tipoConcepto);
            return buscadorRefencia.ObtenerConceptoMovimiento();
        }
    }
}
