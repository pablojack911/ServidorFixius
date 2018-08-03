using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public interface IBuscadorDTOProveedor
    {
        IList<Inteldev.Fixius.Servicios.DTO.Financiero.ConceptoDeMovimiento> ObtenerConceptosDeMovimiento(int idProv);
    }
}
