using Inteldev.Core;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Grabadores
{
    public class GrabadorTarjetaClienteMayorista : GrabadorGenerico<TarjetaClienteMayorista>
    {
        public GrabadorTarjetaClienteMayorista(string empresa, IValidador<TarjetaClienteMayorista> Validador)
            : base(empresa, "tarjetaclientemayorista", Validador)
        {

        }

        public override void Insertar(TarjetaClienteMayorista tarjetaClienteMayorista, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                tarjetaClienteMayorista.HeredaId = this.SetearFk(tarjetaClienteMayorista, "Hereda");

                if (tarjetaClienteMayorista.Ramos.Count > 0)
                {
                    foreach (var ramo in tarjetaClienteMayorista.Ramos)
                    {
                        ramo.CanalId = this.SetearFk(ramo, "Canal");
                        ramo.TarjetaId = this.SetearFk(ramo, "Tarjeta");
                        if (ramo.Id == 0)
                            cntxt.Entry<Ramo>(ramo).State = EntityState.Added;
                        else
                            cntxt.Set<Ramo>().Attach(ramo);
                    }
                }

                cntxt.Set<TarjetaClienteMayorista>().Add(tarjetaClienteMayorista);
                if (Usuario != null)
                    cntxt.insertaAuditoria<TarjetaClienteMayorista>(tarjetaClienteMayorista, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            });
        }

        public override void Actualizar(TarjetaClienteMayorista tarjetaClienteMayorista, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                //obtengo al cliente como esta guardado en la base de datos
                var actualizar = cntxt.BuscarPorId<TarjetaClienteMayorista>(tarjetaClienteMayorista.Id, CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    tarjetaClienteMayorista.HeredaId = this.SetearFk(tarjetaClienteMayorista, "Hereda");

                    Action<Ramo> seteaFkRamo = r =>
                    {
                        r.CanalId = this.SetearFk(r, "Canal");
                        r.TarjetaId = this.SetearFk(r, "Tarjeta");
                    };

                    //this.ActualizarColeccionUnoAMuchos<Ramo>(actualizar.Ramos, tarjetaClienteMayorista.Ramos, cntxt, seteaFkRamo);
                    this.ActualizarColeccionMuchosAMuchos<Ramo>(actualizar.Ramos, tarjetaClienteMayorista.Ramos, cntxt, seteaFkRamo);


                    this.SetearValores(tarjetaClienteMayorista, actualizar, cntxt);

                    if (Usuario != null)
                        cntxt.insertaAuditoria<TarjetaClienteMayorista>(actualizar, Accion.Modifica, Usuario);

                    cntxt.SaveChanges();
                }
            });
        }
    }
}
