using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Borradores
{
    public class BorradorEnvase : BorradorGenerico<Envase>
    {
        public BorradorEnvase(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<Core.Modelo.EntidadBase>();
        }

        public override void Eliminar(Envase entidad, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            using (var transaccion = cntxt.EmpezarTransaccion())
            {
                try
                {
                    foreach (var art in entidad.Articulos)
                    {
                        cntxt.Entry<ArticuloEnvase>(art).State = EntityState.Deleted;
                    }

                    cntxt.SaveChanges(); //para borrar las listas

                    var envaseParaBorrar = cntxt.BuscarPorId<Envase>(entidad.Id, Core.CargarRelaciones.NoCargarNada);
                    cntxt.Entry<Envase>(envaseParaBorrar).State = EntityState.Deleted;

                    cntxt.SaveChanges();

                    if (usuario != null)
                        cntxt.insertaAuditoria<Envase>(entidad, Accion.Elimina, usuario);

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                }
            }

        }
    }
}
