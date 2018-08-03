using Inteldev.Core;
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
    public class BorradorArticulo : BorradorGenerico<Articulo>
    {
        public BorradorArticulo(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<Core.Modelo.EntidadBase>();
        }

        public override void Eliminar(Articulo articulo, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            using (var transaccion = cntxt.EmpezarTransaccion())
            {
                try
                {
                    foreach (var obs in articulo.Observaciones)
                    {
                        cntxt.Entry<ObservacionArticulo>(obs).State = EntityState.Deleted;
                    }

                    foreach (var item in articulo.CodigoDUN)
                    {
                        cntxt.Entry<CodigoDun>(item).State = EntityState.Deleted;
                    }

                    foreach (var item in articulo.CodigoEAN)
                    {
                        cntxt.Entry<CodigoEan>(item).State = EntityState.Deleted;
                    }

                    foreach (var artCom in articulo.ArticulosCompuestos)
                    {
                        cntxt.Entry<ArticuloCompuesto>(artCom).State = EntityState.Deleted;
                    }

                    this.AgregarAListaParaBorrar(articulo.DatosOld);

                    cntxt.SaveChanges(); //para borrar las listaas.

                    var artABorrar = cntxt.BuscarPorId<Articulo>(articulo.Id, CargarRelaciones.NoCargarNada);

                    cntxt.Entry<Articulo>(artABorrar).State = EntityState.Deleted;

                    cntxt.SaveChanges(); //Borra el articulo

                    this.EliminarGrafo(cntxt);

                    if (usuario != null)
                        cntxt.insertaAuditoria<Articulo>(articulo, Accion.Elimina, usuario);

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
