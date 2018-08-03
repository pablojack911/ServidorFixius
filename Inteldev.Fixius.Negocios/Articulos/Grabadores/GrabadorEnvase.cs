using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Grabadores
{
    public class GrabadorEnvase : GrabadorGenerico<Envase>
    {
        public GrabadorEnvase(string empresa, string entidad, IValidador<Envase> validador)
            : base(empresa, entidad, validador)
        {

        }

        public override void Insertar(Envase envase, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                if (envase.Articulos.Count > 0)
                {
                    foreach (var art in envase.Articulos)
                    {
                        art.ArticuloId = this.SetearFk(art, "Articulo");
                        if (art.Id == 0)
                            cntxt.Entry<ArticuloEnvase>(art).State = EntityState.Added;
                        else
                            cntxt.Set<ArticuloEnvase>().Attach(art);
                    }
                }
                cntxt.Set<Envase>().Add(envase);
                if (Usuario != null)
                    cntxt.insertaAuditoria<Envase>(envase, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            }
            );
        }

        public override void Actualizar(Envase envase, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                var actualizar = cntxt.BuscarPorId<Envase>(envase.Id, Core.CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    Action<ArticuloEnvase> setFkArticuloEnvase = p => p.ArticuloId = this.SetearFk(p, "Articulo");
                    this.ActualizarColeccionUnoAMuchos<ArticuloEnvase>(actualizar.Articulos, envase.Articulos, cntxt, setFkArticuloEnvase);
                    this.SetearValores(envase, actualizar, cntxt);
                    if (Usuario != null)
                        cntxt.insertaAuditoria<Envase>(envase, Accion.Modifica, Usuario);
                    cntxt.SaveChanges();
                }
            });
        }
    }
}
