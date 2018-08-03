using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Borradores
{
    public class BorradorSubfamilia : BorradorGenerico<Subfamilia>
    {
        public BorradorSubfamilia(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<Core.Modelo.EntidadBase>();
        }

        public override void Eliminar(Subfamilia entidad, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            var subflia = cntxt.BuscarPorId<Subfamilia>(entidad.Id, Core.CargarRelaciones.NoCargarNada);

            cntxt.Entry<Subfamilia>(subflia).State = System.Data.Entity.EntityState.Deleted;


        }
    }
}
