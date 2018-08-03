using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Fixius.Modelo.Contabilidad;
using Inteldev.Fixius.Modelo.Financiero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorReferenciaContableFox:MapeadorFox<ReferenciaContable>
    {
        public MapeadorReferenciaContableFox(IDao dao, string empresa, string entidad)
            : base("refiere","select * from refiere where empresa='01' and codigo>'   '" ,"codigo",dao,empresa,entidad)
        {
           
        }
        
        protected override ReferenciaContable Mapear(ReferenciaContable entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString();
            entidad.Empresa = "01";
            entidad.Imputacion = Core.Modelo.Contabilidad.Imputaciones.ProveedoresVarios;
            entidad.Concepto = BuscarEntidadPorCodigo<ConceptoDeMovimiento>(registro["cuenta"].ToString());

            return entidad;
        }
    }
}
