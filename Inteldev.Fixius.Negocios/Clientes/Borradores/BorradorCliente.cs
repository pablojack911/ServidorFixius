using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Borradores
{
    public class BorradorCliente : BorradorGenerico<Cliente>
    {
        public BorradorCliente(string empresa, string entidad)
            : base(empresa, entidad)
        {
            this.listaEntidadesParaBorrar = new List<EntidadBase>();
        }
        public override void Eliminar(Cliente cliente, Usuario usuario, IDbContext cntxt)
        {
            using (var transaccion = cntxt.EmpezarTransaccion())
            {
                try
                {
                    foreach (var tel in cliente.Telefonos) //ModelBuilder no se encarga
                    {
                        cntxt.Entry<Telefono>(tel).State = System.Data.Entity.EntityState.Deleted;
                    }

                    foreach (var obs in cliente.ObservacionCliente)
                    {
                        cntxt.Entry<ObservacionCliente>(obs).State = EntityState.Deleted;
                    }

                    foreach (var obsLog in cliente.ObservacionClienteLogistica)
                    {
                        cntxt.Entry<ObservacionCliente>(obsLog).State = EntityState.Deleted;
                    }

                    cntxt.SaveChanges(); //para borrar las listas 1-*

                    this.AgregarAListaParaBorrar(cliente.DatosOld);
                    if (cliente.Domicilio != null)
                        if (cliente.Domicilio.Id > 0)
                            this.AgregarAListaParaBorrar(cliente.Domicilio);
                    if (cliente.LugarEntrega != null)
                        if (cliente.LugarEntrega.Id > 0)
                            this.AgregarAListaParaBorrar(cliente.LugarEntrega);

                    var cliABorrar = cntxt.BuscarPorId<Cliente>(cliente.Id, Core.CargarRelaciones.NoCargarNada);

                    cntxt.Entry<Cliente>(cliABorrar).State = EntityState.Deleted;

                    cntxt.SaveChanges(); //para borrar el cliente

                    this.EliminarGrafo(cntxt);

                    //foreach (var confCred in cliente.ConfiguraCreditos)
                    //{
                    //    //setearFK para cada fk
                    //    confCred.CobradorId = SetearFk(confCred, "Cobrador");
                    //    confCred.CondicionDePagoId = SetearFk(confCred, "CondicionDePago");
                    //    confCred.CondicionDePago2Id = SetearFk(confCred, "CondicionDePago2");
                    //    confCred.VendedorId = SetearFk(confCred, "Vendedor");
                    //    confCred.VendedorEspecialId = SetearFk(confCred, "VendedorEspecial");
                    //    cntxt.Entry<ConfiguraCredito>(confCred).State = EntityState.Deleted;
                    //}

                    //cliente.GrupoDinamico.Clear(); //no puedo eliminar los grupoDinamico por uno, sino los borraria para todos, no?

                    //cliente.ProvinciaId = SetearFk(cliente, "Provincia");

                    //cliente.RamoId = SetearFk(cliente, "Ramo");

                    //cliente.LocalidadId = SetearFk(cliente, "Localidad"); //FK

                    //cliente.LocalidadDeEntregaId = SetearFk(cliente, "LocalidadDeEntrega"); //FK

                    //cliente.RutasDeVenta.Clear();

                    //foreach (var tar in cliente.TarjetasCliente)
                    //{
                    //    tar.TipoTarjetaId = SetearFk(tar, "TipoTarjeta");
                    //    cntxt.Entry<TarjetaMayoristaItem>(tar).State = EntityState.Deleted;
                    //}


                    cntxt.insertaAuditoria<Cliente>(cliente, Accion.Elimina, usuario); //este metodo lo invoca el Borrar del DbContext en el GrabadorGenerico
                    //grabador generico se encarga de SaveChanges() - Metodo public ErrorCarrier Borrar(TEntidad entidad, Usuario Usuario)
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
