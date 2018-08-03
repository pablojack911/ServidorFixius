using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Logistica;
using Inteldev.Fixius.Modelo.Precios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Grabadores
{
    public class GrabadorCliente : GrabadorGenerico<Cliente>
    {
        public GrabadorCliente(string empresa, IValidador<Cliente> validador)
            : base(empresa, "cliente", validador)
        {

        }

        /// <summary>
        /// 2015 - AÑADIDO - Metodo que agrega en los contextos un cliente. Sobreescrito de GrabadorGenerico, utilizado para reemplazar los metodos de insercion de DbContextBase
        /// </summary>
        /// <param name="cliente">Cliente a agregar.</param>
        /// <param name="Usuario">Usuario encargado de la acción.</param>
        /// <param name="listaContextos">Contextos en donde se encuentra el DbSet de Cliente</param>
        public override void Insertar(Cliente cliente, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                //carga local de las propiedades FK para que no se dupliquen al momento de grabar.
                #region Especial - Zona Logistica debe ser por defecto el primer elemento de la lista RutaDeVenta.
                if (cliente.ZonaLogistica == null)
                {
                    var primerRuta = cliente.RutasDeVenta.FirstOrDefault();
                    if (primerRuta != null)
                    {
                        var codigoZonaLogABuscar = primerRuta.Codigo;
                        var zonaLog = cntxt.Set<ZonaLogistica>().FirstOrDefault(p => p.Codigo.Equals(codigoZonaLogABuscar));
                        if (zonaLog != null)
                            cliente.ZonaLogisticaId = zonaLog.Id;
                    }
                }
                else
                    cliente.ZonaLogisticaId = SetearFk(cliente, "ZonaLogistica");
                #endregion

                cliente.ZonaGeograficaId = SetearFk(cliente, "ZonaGeografica");

                cliente.LocalidadId = SetearFk(cliente, "Localidad");

                cliente.LocalidadDeEntregaId = SetearFk(cliente, "LocalidadDeEntrega");

                cliente.ProvinciaId = SetearFk(cliente, "Provincia");

                cliente.RamoId = SetearFk(cliente, "Ramo");

                cliente.CuentaPadreId = SetearFk(cliente, "CuentaPadre");

                if (cliente.DatosOld != null)
                {
                    //cliente.DatosOld.ZonaLogisticaId = SetearFk(cliente.DatosOld, "ZonaLogistica");
                    //cliente.DatosOld.ZonaGeograficaId = SetearFk(cliente.DatosOld, "ZonaGeografica");
                    cliente.DatosOld.RutaDeVentaId = SetearFk(cliente.DatosOld, "RutaDeVenta");
                    cliente.DatosOld.ListaDePrecioId = SetearFk(cliente.DatosOld, "ListaDePreciosDeVenta");
                }

                if (cliente.Domicilio != null)
                    cliente.Domicilio.CalleId = SetearFk(cliente.Domicilio, "Calle");

                if (cliente.LugarEntrega != null)
                    cliente.LugarEntrega.CalleId = SetearFk(cliente.LugarEntrega, "Calle");

                //carga las propiedades de listas
                if (cliente.ConfiguraCreditos.Count > 0)
                    foreach (var confCred in cliente.ConfiguraCreditos)
                    {
                        confCred.CobradorId = SetearFk(confCred, "Cobrador");
                        confCred.CondicionDePagoId = SetearFk(confCred, "CondicionDePago");
                        confCred.CondicionDePago2Id = SetearFk(confCred, "CondicionDePago2");
                        confCred.VendedorId = SetearFk(confCred, "Vendedor");
                        confCred.VendedorEspecialId = SetearFk(confCred, "VendedorEspecial");
                        if (confCred.Id == 0)
                            cntxt.Entry<ConfiguraCredito>(confCred).State = EntityState.Added;
                        else
                            cntxt.Set<ConfiguraCredito>().Attach(confCred);
                    }

                if (cliente.TarjetasCliente.Count > 0)
                    foreach (var tar in cliente.TarjetasCliente)
                    {
                        tar.TipoTarjetaId = SetearFk(tar, "TipoTarjeta");
                        if (tar.Id == 0)
                            cntxt.Entry<TarjetaMayoristaItem>(tar).State = EntityState.Added;
                        else
                            cntxt.Set<TarjetaMayoristaItem>().Attach(tar);
                    }

                if (cliente.RutasDeVenta.Count > 0)
                    foreach (var ruta in cliente.RutasDeVenta)
                    {
                        //ruta.DivisionId = SetearFk(ruta, "Division");
                        ruta.RegionDeVentaId = SetearFk(ruta, "RegionDeVenta");
                        ruta.SuplenteId = SetearFk(ruta, "Suplente");
                        ruta.TitularId = SetearFk(ruta, "Titular");

                        if (ruta.Id == 0)
                            cntxt.Entry<RutaDeVenta>(ruta).State = EntityState.Added;
                        else
                            cntxt.Set<RutaDeVenta>().Attach(ruta);
                    }

                if (cliente.GrupoDinamico.Count > 0)
                    foreach (var gru in cliente.GrupoDinamico)
                    {
                        if (gru.Id == 0)
                            cntxt.Entry<GrupoCliente>(gru).State = EntityState.Added;
                        else
                            cntxt.Set<GrupoCliente>().Attach(gru);
                    }

                cntxt.Set<Cliente>().Add(cliente);
                if (Usuario != null)
                    cntxt.insertaAuditoria<Cliente>(cliente, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            }
            );
        }

        /// <summary>
        /// 2015 - Añadido - Metodo que actualiza en los contextos un cliente. Sobreescrito de GrabadorGenerico, utilizado para reemplazar el metodo Actualizar de DbContextBase
        /// </summary>
        /// <param name="cliente">Cliente a actualizar.</param>
        /// <param name="Usuario">Usuario encargado de la acción.</param>
        /// <param name="listaContextos">Contextos en donde se encuentra el DbSet de Cliente.</param>
        public override void Actualizar(Cliente cliente, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            foreach (var cntxt in listaContextos)
            {
                //obtengo al cliente como esta guardado en la base de datos
                var actualizar = cntxt.BuscarPorId<Cliente>(cliente.Id, CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    #region Especial - Zona Logistica debe ser por defecto el primer elemento de la lista RutaDeVenta.
                    if (cliente.ZonaLogistica == null)
                    {
                        var primerRuta = cliente.RutasDeVenta.FirstOrDefault();
                        if (primerRuta != null)
                        {
                            var codigoZonaLogABuscar = primerRuta.Codigo;
                            var zonaLog = cntxt.Set<ZonaLogistica>().FirstOrDefault(p => p.Codigo.Equals(codigoZonaLogABuscar));
                            if (zonaLog != null)
                                cliente.ZonaLogisticaId = zonaLog.Id;
                        }
                    }
                    else
                        cliente.ZonaLogisticaId = SetearFk(cliente, "ZonaLogistica");
                    #endregion

                    if (cliente.DatosOld != null)
                    {
                        //cliente.DatosOld.ZonaLogisticaId = SetearFk(cliente.DatosOld, "ZonaLogistica");
                        //cliente.DatosOld.ZonaGeograficaId = SetearFk(cliente.DatosOld, "ZonaGeografica");
                        cliente.DatosOld.RutaDeVentaId = SetearFk(cliente.DatosOld, "RutaDeVenta");
                        cliente.DatosOld.ListaDePrecioId = SetearFk(cliente.DatosOld, "ListaDePreciosDeVenta");
                    }

                    if (cliente.Domicilio != null)
                        cliente.Domicilio.CalleId = SetearFk(cliente.Domicilio, "Calle");


                    if (cliente.LugarEntrega != null)
                        cliente.LugarEntrega.CalleId = SetearFk(cliente.LugarEntrega, "Calle");

                    //actualizo fk
                    //cliente.ZonaLogisticaId = SetearFk(cliente, "ZonaLogistica");

                    cliente.ZonaGeograficaId = SetearFk(cliente, "ZonaGeografica");

                    cliente.LocalidadId = SetearFk(cliente, "Localidad");

                    cliente.LocalidadDeEntregaId = SetearFk(cliente, "LocalidadDeEntrega");

                    cliente.ProvinciaId = SetearFk(cliente, "Provincia");

                    cliente.RamoId = SetearFk(cliente, "Ramo");

                    cliente.CuentaPadreId = SetearFk(cliente, "CuentaPadre");

                    #region Listas



                    ActualizarColeccionMuchosAMuchos<GrupoCliente>(actualizar.GrupoDinamico, cliente.GrupoDinamico, cntxt); //funciona

                    Action<RutaDeVenta> setFkRutaDeVenta = r =>
                    {
                        //r.DivisionId = this.SetearFk(r, "Division");
                        r.RegionDeVentaId = this.SetearFk(r, "RegionDeVenta");
                        r.SuplenteId = this.SetearFk(r, "Suplente");
                        r.TitularId = this.SetearFk(r, "Titular");
                    };

                    ActualizarColeccionMuchosAMuchos<RutaDeVenta>(actualizar.RutasDeVenta, cliente.RutasDeVenta, cntxt, setFkRutaDeVenta); //funciona

                    ActualizarColeccionUnoAMuchos<Telefono>(actualizar.Telefonos, cliente.Telefonos, cntxt);

                    ActualizarColeccionUnoAMuchos<ObservacionCliente>(actualizar.ObservacionCliente, cliente.ObservacionCliente, cntxt);

                    ActualizarColeccionUnoAMuchos<ObservacionCliente>(actualizar.ObservacionClienteLogistica, cliente.ObservacionClienteLogistica, cntxt);

                    Action<TarjetaMayoristaItem> setFkTarjetasCliente = t =>
                        {
                            t.TipoTarjetaId = this.SetearFk(t, "TipoTarjeta");
                        };

                    ActualizarColeccionUnoAMuchos<TarjetaMayoristaItem>(actualizar.TarjetasCliente, cliente.TarjetasCliente, cntxt, setFkTarjetasCliente); //no funciona

                    #endregion

                    SetearValores(cliente, actualizar, cntxt);
                    SetearValores(cliente.Domicilio, actualizar.Domicilio, cntxt);
                    SetearValores(cliente.LugarEntrega, actualizar.LugarEntrega, cntxt);
                    SetearValores(cliente.DatosOld, actualizar.DatosOld, cntxt);

                    Action<ConfiguraCredito> setFkConfiguraCredito = cc =>
                        {
                            cc.CobradorId = SetearFk(cc, "Cobrador");
                            cc.CondicionDePagoId = SetearFk(cc, "CondicionDePago");
                            cc.CondicionDePago2Id = SetearFk(cc, "CondicionDePago2");
                            cc.VendedorId = SetearFk(cc, "Vendedor");
                            cc.VendedorEspecialId = SetearFk(cc, "VendedorEspecial");
                        };

                    ActualizarColeccionUnoAMuchos<ConfiguraCredito>(actualizar.ConfiguraCreditos, cliente.ConfiguraCreditos, cntxt, setFkConfiguraCredito);

                    if (Usuario != null)
                        cntxt.insertaAuditoria<Cliente>(actualizar, Accion.Modifica, Usuario);
                    cntxt.SaveChanges();

                }
            }
        }
    }
}
