using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Usuarios
{
    public class GrabadorPerfilUsuario : GrabadorGenerico<PerfilUsuario>
    {
        public GrabadorPerfilUsuario(string empresa, string entidad, IValidador<PerfilUsuario> validador)
            : base(empresa, entidad, validador)
        {

        }

        public override void Insertar(PerfilUsuario perfil, Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                cntxt.Set<PerfilUsuario>().Add(perfil);
                //if (Usuario != null) //NO PUEDO GRABAR LA AUDITORIA POR PROBLEMAS DE REDUNDANCIA CICLICA DEADLOCK
                //    cntxt.insertaAuditoria<PerfilUsuario>(perfil, Core.Modelo.Auditoria.Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            });
        }

        public override void Actualizar(PerfilUsuario perfil, Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                var actualizar = cntxt.BuscarPorId<PerfilUsuario>(perfil.Id, Core.CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    var todosLosPermisosActualizados = new List<Permiso>();
                    todosLosPermisosActualizados = this.CrearListaDePermisos(perfil.Permiso, todosLosPermisosActualizados);
                    var todosLosPermisosDesactualizados = new List<Permiso>();
                    todosLosPermisosDesactualizados = this.CrearListaDePermisos(actualizar.Permiso, todosLosPermisosDesactualizados);

                    foreach (var permiso in todosLosPermisosDesactualizados)
                    {
                        this.SetearValores(todosLosPermisosActualizados.First(x => x.Id == permiso.Id), permiso, cntxt);
                    }
                    this.SetearValores(perfil, actualizar, cntxt);
                }
                //if (Usuario != null)//NO PUEDO GRABAR LA AUDITORIA POR PROBLEMAS DE REDUNDANCIA CICLICA DEADLOCK
                //    cntxt.insertaAuditoria<PerfilUsuario>(actualizar, Core.Modelo.Auditoria.Accion.Modifica, Usuario);
                cntxt.SaveChanges();
            });
        }

        private List<Permiso> CrearListaDePermisos(Permiso permiso, List<Permiso> permisos)
        {
            foreach (var per in permiso.SubModulos)
            {
                if (per.SubModulos.Count > 0)
                    this.CrearListaDePermisos(per, permisos);
                if (!permisos.Any(x => x.Id == per.Id))
                    permisos.Add(per);
            }
            return permisos;
        }

        //public void ActualizarSubModulo(Permiso origen, Permiso destino, IDbContext contexto) //posible opcion
        //{
        //    foreach (var perm in origen.SubModulos)
        //    {
        //        if (perm.SubModulos.Count > 0)
        //        {
        //            this.ActualizarSubModulo(perm, destino, contexto);
        //            this.SetearValores(origen, destino.SubModulos.Where(x => x.Id == origen.Id).First(), contexto);
        //        }
        //    }
        //}
    }
}
