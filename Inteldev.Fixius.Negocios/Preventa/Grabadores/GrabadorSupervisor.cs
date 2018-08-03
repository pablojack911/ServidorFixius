using Inteldev.Core;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.Grabadores
{
    public class GrabadorSupervisor : GrabadorGenerico<Supervisor>
    {
        public GrabadorSupervisor(string empresa, string entidad, IValidador<Supervisor> validador)
            : base(empresa, entidad, validador)
        {

        }

        public override void Actualizar(Supervisor supervisor, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
                {
                    //obtengo al cliente como esta guardado en la base de datos
                    var actualizar = cntxt.BuscarPorId<Supervisor>(supervisor.Id, CargarRelaciones.CargarTodo);
                    if (actualizar != null)
                    {
                        supervisor.JefeId = SetearFk(supervisor, "Jefe");

                        Action<Preventista> setFkPreventistas = p =>
                            {
                                p.SupervisorId = SetearFk(p, "Supervisor");
                            };

                        ActualizarColeccionMuchosAMuchos<Preventista>(actualizar.Preventistas, supervisor.Preventistas, cntxt, setFkPreventistas);

                        SetearValores(supervisor, actualizar, cntxt);
                        SetearValores(supervisor.DatosOldPreventa, actualizar.DatosOldPreventa, cntxt);

                        if (Usuario != null)
                            cntxt.insertaAuditoria<Supervisor>(actualizar, Accion.Modifica, Usuario);
                        cntxt.SaveChanges();
                    }
                });
        }

        public override void Insertar(Supervisor supervisor, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                //carga local de las propiedades FK para que no se dupliquen al momento de grabar.
                supervisor.JefeId = SetearFk(supervisor, "Jefe");

                if (supervisor.Preventistas.Count > 0)
                {
                    foreach (var prev in supervisor.Preventistas)
                    {
                        prev.SupervisorId = SetearFk(prev, "Supervisor");
                        if (prev.Id == 0)
                            cntxt.Entry<Preventista>(prev).State = EntityState.Added;
                        else
                            cntxt.Set<Preventista>().Attach(prev);
                    }
                }

                cntxt.Set<Supervisor>().Add(supervisor);
                if (Usuario != null)
                    cntxt.insertaAuditoria<Supervisor>(supervisor, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            });
        }
    }
}
