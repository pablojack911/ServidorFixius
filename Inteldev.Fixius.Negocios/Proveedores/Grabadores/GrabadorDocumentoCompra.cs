using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Core.Patrones;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Grabadores
{
    public class GrabadorDocumentoCompra : GrabadorGenerico<DocumentoCompra>
    {
        public GrabadorDocumentoCompra(string empresa, string entidad, IValidador<DocumentoCompra> validador)
            : base(empresa, entidad, validador)
        {
        }

        //public override Core.DTO.Carriers.GrabadorCarrier GrabarNuevo(Modelo.Proveedores.DocumentoCompra Entidad, Core.Modelo.Usuarios.Usuario Usuario)
        //{
        //    var paramers = new ParameterOverride[2];
        //    paramers[0] = new ParameterOverride("empresa", Entidad.Empresa);
        //    paramers[1] = new ParameterOverride("entidad", "DocumentoCompra");
        //    var BuscadorComprobante = (IBuscadorComprobante)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorComprobante), paramers);
        //    var comprobante = BuscadorComprobante.BuscarRepetido(Entidad.Empresa, Entidad.Sucursal, Entidad.Proveedor.Id, (int)Entidad.TipoDocumento, Entidad.Prenumero, Entidad.Numero);
        //    if (comprobante != null)
        //    {
        //        var grabadorCarrier = new GrabadorCarrier();
        //        grabadorCarrier.setError(true);
        //        grabadorCarrier.setMensaje(string.Format("El comprobante ya esta cargado para el proveedor {0}", Entidad.Proveedor.Nombre));
        //        return grabadorCarrier;
        //    }
        //    else
        //    {
        //        var creadorMovimiento = FabricaNegocios._Resolver<ICreador<Inteldev.Fixius.Modelo.Tesoreria.MovimientoBancario>>();
        //        var grabadorCuentaBancaria = FabricaNegocios._Resolver<IGrabador<Modelo.Tesoreria.CuentaBancaria>>();
        //        //aca mandar la creacion de las correspondientes notas de credito o notas de debito internas
        //        var grabadorNotas = FabricaNegocios._Resolver<IGrabador<Modelo.Proveedores.DocumentoCompra>>();

        //        if (Entidad.TipoDocumento == Modelo.Proveedores.TipoDocumento.NotaDeCredito ||
        //            Entidad.TipoDocumento == Modelo.Proveedores.TipoDocumento.NotaDeDebito)
        //        {
        //            //var notasDeCreditoPendientes = Entidad.NotasPendientes;
        //            foreach (NotaPendiente notaPendiente in Entidad.NotasPendientes)
        //            {
        //                if (notaPendiente.Seleccionado)
        //                {
        //                    notaPendiente.Aplicado = notaPendiente.Importe;

        //                    var mementoNota = new Memento<NotaPendiente>(notaPendiente);

        //                    grabadorNotas.GrabarExistente(notaPendiente, Usuario);
        //                    mementoNota.RecuperarEstado();
        //                    var grabadorNotasFox = FabricaNegocios._Resolver<IGrabadorFox<Modelo.Proveedores.DocumentoCompra>>();
        //                    grabadorNotasFox.Grabar(notaPendiente);

        //                    //si es Credito Pendiente lo convierte en Debito Pendiente y viceversa
        //                    notaPendiente.TipoDocumento = notaPendiente.TipoDocumento == TipoDocumento.NotaDeCreditoInterno ? TipoDocumento.NotadeDébitoInterno : TipoDocumento.NotaDeCreditoInterno;
        //                    notaPendiente.Id = 0;
        //                    notaPendiente.Codigo = null;
        //                    mementoNota.CapturarEstado(notaPendiente);
        //                    notaPendiente.ItemsConceptos.Clear();
        //                    var carrier = grabadorNotas.Grabar(notaPendiente, Usuario);

        //                    mementoNota.RecuperarEstado();
        //                    grabadorNotasFox = FabricaNegocios._Resolver<IGrabadorFox<Modelo.Proveedores.DocumentoCompra>>();
        //                    grabadorNotasFox.Grabar(notaPendiente);
        //                }
        //            }
        //        }
        //        //else
        //        //{
        //        //    if (Entidad.TipoDocumento == Modelo.Proveedores.TipoDocumento.NotaDeDebito)
        //        //    {
        //        //        var notasDeDebitoPendientes = Entidad.NotasPendientes;
        //        //        foreach (NotaPendiente notaDebito in notasDeDebitoPendientes)
        //        //        {
        //        //            if (notaDebito.Seleccionado)
        //        //            {
        //        //                notaDebito.Aplicado = notaDebito.Importe;
        //        //                grabadorNotas.Grabar(notaDebito, Usuario);

        //        //                grabadorNotasFox.Grabar(notaDebito);
        //        //                var notaCredito = notaDebito;
        //        //                notaCredito.Proveedor = proveedor;
        //        //                notaCredito.TipoDocumento = Modelo.Proveedores.TipoDocumento.NotaDeCreditoInterno;
        //        //                notaCredito.Id = 0;
        //        //                notaDebito.Codigo = null;
        //        //                grabadorNotas.Grabar(notaCredito, Usuario);
        //        //                notaCredito.Proveedor = proveedor;
        //        //                grabadorNotasFox.Grabar(notaCredito);
        //        //            }
        //        //        }
        //        //    }
        //        //}


        //        var carrierNuevo = base.GrabarNuevo(Entidad, Usuario);
        //        if (carrierNuevo.getError() == false && Entidad.TipoDocumento == TipoDocumento.LiquidacionBancaria)
        //        {
        //            //aca mando el movimiento bancario
        //            decimal debe = 0;
        //            decimal haber = 0;
        //            foreach (var item in Entidad.ItemsConceptos)
        //            {
        //                debe += item.Debe;
        //                haber += item.Haber;
        //            }
        //            var movimiento = creadorMovimiento.Crear();
        //            movimiento.ConceptoMovimientoBancario = Entidad.ConceptoMovimientoBancario;
        //            movimiento.Fecha = Entidad.Fecha;
        //            movimiento.FechaEfectiva = Entidad.Fecha;
        //            movimiento.Debe = debe;
        //            movimiento.Haber = haber;
        //            var cuentaBancaria = Entidad.CuentaBancaria;
        //            if (cuentaBancaria != null && Entidad.TipoDocumento == TipoDocumento.LiquidacionBancaria)
        //            {
        //                cuentaBancaria.MovimientosBancarios.Add(movimiento);
        //                grabadorCuentaBancaria.Grabar(cuentaBancaria, Usuario);
        //            }
        //        }
        //        if (!carrierNuevo.getError())
        //            carrierNuevo.setMensaje(string.Format("Comprobante grabado correctamente. Numero: {0}-{1}", Entidad.Prenumero, Entidad.Numero));
        //        return carrierNuevo;
        //    }
        //}

        public override void Actualizar(DocumentoCompra doc, Core.Modelo.Usuarios.Usuario Usuario, List<IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
                {
                    var actualizar = cntxt.BuscarPorId<DocumentoCompra>(doc.Id, CargarRelaciones.CargarTodo);
                    if (actualizar != null)
                    {
                        if (doc.MovimientoBancario != null)
                        {
                            doc.MovimientoBancario.ConceptoMovimientoBancarioId = this.SetearFk(doc.MovimientoBancario, "ConceptoMovimientoBancario");
                        }

                        if (doc.CuentaBancaria != null)
                        {
                            doc.CuentaBancaria.BancoId = this.SetearFk(doc.CuentaBancaria, "Banco");
                        }

                        doc.AutorizaId = SetearFk(doc, "Autoriza");
                        doc.ProveedorId = SetearFk(doc, "Proveedor");

                        #region Listas

                        Action<DocumentoProveedor> setFkDocumentoProveedor = d =>
                            {
                                d.ProveedorId = this.SetearFk(d, "Proveedor");
                            };

                        ActualizarColeccionUnoAMuchos<DocumentoProveedor>(actualizar.DocumentosAsociados, doc.DocumentosAsociados, cntxt, setFkDocumentoProveedor);

                        Action<ItemsConceptos> setFkItemsConceptos = i =>
                            {
                                i.ConceptoId = this.SetearFk(i, "Concepto");
                            };

                        ActualizarColeccionUnoAMuchos<ItemsConceptos>(actualizar.ItemsConceptos, doc.ItemsConceptos, cntxt, setFkItemsConceptos);

                        ActualizarColeccionUnoAMuchos<NotaPendiente>(actualizar.NotasPendientes, doc.NotasPendientes, cntxt);

                        #endregion

                        SetearValores(doc, actualizar, cntxt);
                        SetearValores(doc.MovimientoBancario, actualizar.MovimientoBancario, cntxt);
                        SetearValores(doc.CuentaBancaria, actualizar.CuentaBancaria, cntxt);


                        if (Usuario != null)
                            cntxt.insertaAuditoria<DocumentoCompra>(actualizar, Accion.Modifica, Usuario);
                        cntxt.SaveChanges();


                    }
                });
        }

        public override void Insertar(DocumentoCompra doc, Core.Modelo.Usuarios.Usuario Usuario, List<IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
                {
                    //carga local de las propiedades FK para que no se dupliquen al momento de grabar.
                    if (doc.MovimientoBancario != null)
                    {
                        doc.MovimientoBancario.ConceptoMovimientoBancarioId = this.SetearFk(doc.MovimientoBancario, "ConceptoMovimientoBancario");
                    }

                    if (doc.CuentaBancaria != null)
                    {
                        doc.CuentaBancaria.BancoId = this.SetearFk(doc.CuentaBancaria, "Banco");
                    }

                    doc.AutorizaId = SetearFk(doc, "Autoriza");
                    doc.ProveedorId = SetearFk(doc, "Proveedor");

                    //carga las propiedades de listas
                    if (doc.DocumentosAsociados.Count > 0)
                        foreach (var docAsoc in doc.DocumentosAsociados)
                        {
                            docAsoc.ProveedorId = this.SetearFk(docAsoc, "Proveedor");
                            if (docAsoc.Id == 0)
                                cntxt.Entry<DocumentoProveedor>(docAsoc).State = EntityState.Added;
                            else
                                cntxt.Set<DocumentoProveedor>().Attach(docAsoc);
                        }

                    if (doc.ItemsConceptos.Count > 0)
                    {
                        foreach (var item in doc.ItemsConceptos)
                        {
                            item.ConceptoId = this.SetearFk(item, "Concepto");
                            if (item.Id == 0)
                                cntxt.Entry<ItemsConceptos>(item).State = EntityState.Added;
                            else
                                cntxt.Set<ItemsConceptos>().Attach(item);
                        }
                    }

                    if (doc.NotasPendientes.Count > 0)
                    {
                        foreach (var nota in doc.NotasPendientes)
                        {
                            nota.AutorizaId = this.SetearFk(nota, "Autoriza");
                            nota.ProveedorId = this.SetearFk(nota, "Proveedor");
                            if (nota.Id == 0)
                                cntxt.Entry<NotaPendiente>(nota).State = EntityState.Added;
                            else
                                cntxt.Set<NotaPendiente>().Attach(nota);
                        }
                    }

                    cntxt.Set<DocumentoCompra>().Add(doc);
                    if (Usuario != null)
                        cntxt.insertaAuditoria<DocumentoCompra>(doc, Accion.Agrega, Usuario);
                    cntxt.SaveChanges();
                }
            );
        }
    }
}
