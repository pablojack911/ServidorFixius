using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Borradores
{
    public class BorradorRutaDeVenta : BorradorGenerico<RutaDeVenta>
    {
        public BorradorRutaDeVenta(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<Core.Modelo.EntidadBase>();
        }

        public override void Eliminar(RutaDeVenta entidad, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            using (var transaccion = cntxt.EmpezarTransaccion())
            {
                try
                {
                    this.AgregarAListaParaBorrar(entidad.DatosOld);

                    var ruta = cntxt.BuscarPorId<RutaDeVenta>(entidad.Id, Core.CargarRelaciones.NoCargarNada);

                    cntxt.Entry<RutaDeVenta>(ruta).State = System.Data.Entity.EntityState.Deleted;

                    cntxt.SaveChanges();

                    this.EliminarGrafo(cntxt);

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
