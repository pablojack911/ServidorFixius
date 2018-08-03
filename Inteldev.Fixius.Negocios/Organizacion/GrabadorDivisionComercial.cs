using Inteldev.Core;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Organizacion
{
    public class GrabadorDivisionComercial : GrabadorGenerico<DivisionComercial>
    {
        public GrabadorDivisionComercial(string empresa, string entidad, IValidador<DivisionComercial> validador)
            : base(empresa, entidad, validador)
        {

        }

        public override void Insertar(DivisionComercial division, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
                {
                    cntxt.Set<DivisionComercial>().Add(division);
                    if (Usuario != null)
                        cntxt.insertaAuditoria<DivisionComercial>(division, Accion.Agrega, Usuario);
                    cntxt.SaveChanges();
                });
        }

        public override void Actualizar(DivisionComercial division, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {

                //obtengo la division como esta guardada en la base de datos
                var actualizar = cntxt.BuscarPorId<DivisionComercial>(division.Id, CargarRelaciones.CargarTodo);

                this.ActualizarColeccionUnoAMuchos<EmpresaCodigo>(actualizar.Empresas, division.Empresas, cntxt);

                SetearValores(division, actualizar, cntxt);

                if (Usuario != null)
                    cntxt.insertaAuditoria<DivisionComercial>(actualizar, Accion.Modifica, Usuario);
                cntxt.SaveChanges();

            });
        }
    }
}
