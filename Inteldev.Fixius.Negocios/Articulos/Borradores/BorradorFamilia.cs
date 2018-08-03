using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Borradores
{
    public class BorradorFamilia : BorradorGenerico<Familia>
    {
        public BorradorFamilia(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<Core.Modelo.EntidadBase>();
        }
        public override void Eliminar(Familia entidad, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            var flia = cntxt.BuscarPorId<Familia>(entidad.Id, Core.CargarRelaciones.NoCargarNada);

            cntxt.Entry<Familia>(flia).State = System.Data.Entity.EntityState.Deleted;

            //cntxt.SaveChanges();
        }
    }
}
