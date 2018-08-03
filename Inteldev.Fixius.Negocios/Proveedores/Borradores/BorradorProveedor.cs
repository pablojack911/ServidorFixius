using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Borradores
{
    public class BorradorProveedor : BorradorGenerico<Proveedor>
    {
        public BorradorProveedor(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<EntidadBase>();
        }

        public override void Eliminar(Proveedor proveedor, Core.Modelo.Usuarios.Usuario usuario, Core.Datos.IDbContext cntxt)
        {
            using (var transaccion = cntxt.EmpezarTransaccion())
            {
                try
                {
                    foreach (var tel in proveedor.Telefonos) //ModelBuilder no se encarga
                    {
                        cntxt.Entry<Telefono>(tel).State = EntityState.Deleted;
                    }

                    foreach (var obs in proveedor.Observaciones)
                    {
                        cntxt.Entry<ObservacionProveedor>(obs).State = EntityState.Deleted;
                    }

                    foreach (var contacto in proveedor.Contactos)
                    {
                        foreach (var tel in contacto.Telefonos)
                        {
                            cntxt.Entry<Telefono>(tel).State = EntityState.Deleted;
                        }
                        if (contacto.Domicilio != null)
                            if (contacto.Domicilio.Id > 0)
                                this.AgregarAListaParaBorrar(contacto.Domicilio);
                    }

                    foreach (var prontoPago in proveedor.ProntoPago)
                    {
                        //if (prontoPago.Id > 0)
                        //    this.AgregarAListaParaBorrar(prontoPago);
                        cntxt.Entry<ProntoPago>(prontoPago).State = EntityState.Deleted;
                    }

                    cntxt.SaveChanges(); //para borrar las listas 1-*

                    this.AgregarAListaParaBorrar(proveedor.DatosOld);

                    //if (proveedor.Domicilio != null)
                    //    if (proveedor.Domicilio.Id > 0)
                    //        this.AgregarAListaParaBorrar(proveedor.Domicilio);

                    var provParaBorrar = cntxt.BuscarPorId<Proveedor>(proveedor.Id, Core.CargarRelaciones.NoCargarNada);

                    cntxt.Entry<Proveedor>(provParaBorrar).State = EntityState.Deleted;

                    cntxt.SaveChanges();

                    this.EliminarGrafo(cntxt);

                    cntxt.insertaAuditoria<Proveedor>(proveedor, Accion.Elimina, usuario); //este metodo lo invoca el Borrar del DbContext en el GrabadorGenerico
                    
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
