using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BuscadorDTOProveedor : BuscadorDTO<Inteldev.Fixius.Modelo.Proveedores.Proveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor>, IBuscadorDTOProveedor
    {
        public BuscadorDTOProveedor(IBuscador<Inteldev.Fixius.Modelo.Proveedores.Proveedor> buscadorEntidad, IMapeadorGenerico<Inteldev.Fixius.Modelo.Proveedores.Proveedor, Inteldev.Fixius.Servicios.DTO.Proveedores.Proveedor> mapeador)
            : base(buscadorEntidad, mapeador)
        {

        }


        public IList<Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento> ObtenerConceptosDeMovimiento(int idProv)
        {
            var para = new ParameterOverride[2];
            para[0] = new ParameterOverride("empresa", "01");
            para[1] = new ParameterOverride("entidad", "ConceptoDeMovimiento");
            var mapeadorConcepto = (MapeadorGenerico<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento>)FabricaNegocios.Instancia.Resolver(typeof(MapeadorGenerico<Inteldev.Fixius.Modelo.Financiero.ConceptoDeMovimiento, Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento>), para);

            var query = this.BuscadorEntidad.ConsultaSimple(Core.CargarRelaciones.CargarTodo);
            var listaConceptos = (from prov in query
                                  where prov.Id == idProv
                                  select prov.ConceptoDeMovimiento).FirstOrDefault();
            return mapeadorConcepto.ToListDto(listaConceptos.ToList());
        }
    }
}
