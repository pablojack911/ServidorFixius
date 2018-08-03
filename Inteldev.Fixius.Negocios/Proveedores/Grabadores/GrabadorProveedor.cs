using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Financiero;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Grabadores
{
    public class GrabadorProveedor : GrabadorGenerico<Modelo.Proveedores.Proveedor>
    {
        public GrabadorProveedor(string empresa, string entidad, IValidador<Proveedor> validador)
            : base(empresa, entidad, validador)
        { }

        /*
        /// <summary>
        /// Este override valida que el CUIT no este repetido. Despues hay que hacer validaciones mas ordenadas.
        /// </summary>
        /// <param name="Entidad"></param>
        /// <param name="Usuario"></param>
        /// <returns>fucking carrier con error</returns>
        public override Core.DTO.Carriers.GrabadorCarrier GrabarNuevo(Modelo.Proveedores.Proveedor Entidad, Core.Modelo.Usuarios.Usuario Usuario)
        {

            //var proveedor = this.Contexto.Consultar<Modelo.Proveedores.Proveedor>(CargarRelaciones.NoCargarNada).Where(p=>p.Cuit == Entidad.Cuit).FirstOrDefault();

            //if (proveedor == null)

            return base.GrabarNuevo(Entidad, Usuario);
            //else
            //{
            //    var grabadorCarrier = new GrabadorCarrier();
            //    grabadorCarrier.setError(true);
            //    grabadorCarrier.setMensaje("CUIT Repetido. Ingrese otro.");
            //    return grabadorCarrier;
            //}
        }*/

        public override void Insertar(Proveedor proveedor, Usuario Usuario, List<IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {

                //FKs
                proveedor.EntregaId = this.SetearFk(proveedor, "Entrega");

                proveedor.LocalidadId = this.SetearFk(proveedor, "Localidad");

                proveedor.PlantillaId = this.SetearFk(proveedor, "Plantilla");

                proveedor.ProvinciaId = this.SetearFk(proveedor, "Provincia");

                proveedor.TipoProveedorId = this.SetearFk(proveedor, "TipoProveedor");

                //Uno A Uno

                if (proveedor.DatosOld != null)
                {
                    proveedor.DatosOld.DepositoId = this.SetearFk(proveedor.DatosOld, "Deposito");
                    proveedor.DatosOld.FleteroId = this.SetearFk(proveedor.DatosOld, "Fletero");
                }

                //if (proveedor.Domicilio != null)
                //{
                //    proveedor.Domicilio.CalleId = this.SetearFk(proveedor.Domicilio, "Calle");
                //}

                //listas

                foreach (var cont in proveedor.Contactos)
                {
                    if (cont.Domicilio != null)
                        cont.Domicilio.CalleId = this.SetearFk(cont.Domicilio, "Calle");
                    //y los telefonos de los contactos? como los trabajamos?¿
                    if (cont.Id == 0)
                        cntxt.Entry<Contacto>(cont).State = EntityState.Added;
                    else
                        cntxt.Set<Contacto>().Attach(cont);
                }

                //listas muchos a muchos


                foreach (var banco in proveedor.Bancos)
                {
                    if (banco.Id == 0)
                        cntxt.Entry<Banco>(banco).State = EntityState.Added;
                    else
                        cntxt.Set<Banco>().Attach(banco);
                }

                foreach (var concepto in proveedor.ConceptoDeMovimiento)
                {
                    if (concepto.Id == 0)
                        cntxt.Entry<ConceptoDeMovimiento>(concepto).State = EntityState.Added;
                    else
                        cntxt.Set<ConceptoDeMovimiento>().Attach(concepto);
                }

                foreach (var condicion in proveedor.CondicionDePago)
                {
                    if (condicion.Id == 0)
                        cntxt.Entry<CondicionDePagoProveedor>(condicion).State = EntityState.Added;
                    else
                        cntxt.Set<CondicionDePagoProveedor>().Attach(condicion);
                }

                cntxt.Set<Proveedor>().Add(proveedor);
                if (Usuario != null)
                    cntxt.insertaAuditoria<Proveedor>(proveedor, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            }
            );
        }

        public override void Actualizar(Proveedor proveedor, Usuario Usuario, List<IDbContext> listaContextos)
        {
            //base.Actualizar(proveedor, Usuario, listaContextos);

            listaContextos.ForEach(cntxt =>
            {
                //obtengo al proveedor como esta guardado en la base de datos
                var actualizar = cntxt.BuscarPorId<Proveedor>(proveedor.Id, CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    //FKs
                    proveedor.EntregaId = this.SetearFk(proveedor, "Entrega");

                    proveedor.LocalidadId = this.SetearFk(proveedor, "Localidad");

                    proveedor.PlantillaId = this.SetearFk(proveedor, "Plantilla");

                    proveedor.ProvinciaId = this.SetearFk(proveedor, "Provincia");

                    proveedor.TipoProveedorId = this.SetearFk(proveedor, "TipoProveedor");

                    //Uno A Uno

                    if (proveedor.DatosOld != null)
                    {
                        proveedor.DatosOld.DepositoId = this.SetearFk(proveedor.DatosOld, "Deposito");
                        proveedor.DatosOld.FleteroId = this.SetearFk(proveedor.DatosOld, "Fletero");
                    }

                    //if (proveedor.Domicilio != null)
                    //{
                    //    proveedor.Domicilio.CalleId = this.SetearFk(proveedor.Domicilio, "Calle");
                    //}

                    #region Listas

                    //uno a muchos 

                    Action<Contacto> setFkContactos = c =>
                    {
                        if (c.Domicilio != null)
                            c.Domicilio.CalleId = this.SetearFk(c.Domicilio, "Calle");
                    };

                    ActualizarColeccionUnoAMuchos<Contacto>(actualizar.Contactos, proveedor.Contactos, cntxt, setFkContactos);

                    foreach (var contacto in actualizar.Contactos)
                    {
                        var contactoProv = proveedor.Contactos.FirstOrDefault(c => c.Id == contacto.Id);
                        if (contactoProv != null)
                            ActualizarColeccionUnoAMuchos<Telefono>(contacto.Telefonos, contactoProv.Telefonos, cntxt);
                    }

                    ActualizarColeccionUnoAMuchos<Telefono>(actualizar.Telefonos, proveedor.Telefonos, cntxt);

                    ActualizarColeccionUnoAMuchos<ProntoPago>(actualizar.ProntoPago, proveedor.ProntoPago, cntxt);

                    ActualizarColeccionUnoAMuchos<ObservacionProveedor>(actualizar.Observaciones, proveedor.Observaciones, cntxt);

                    //muchos a muchos
                    ActualizarColeccionMuchosAMuchos<CondicionDePagoProveedor>(actualizar.CondicionDePago, proveedor.CondicionDePago, cntxt);

                    ActualizarColeccionMuchosAMuchos<ConceptoDeMovimiento>(actualizar.ConceptoDeMovimiento, proveedor.ConceptoDeMovimiento, cntxt);

                    ActualizarColeccionMuchosAMuchos<Banco>(actualizar.Bancos, proveedor.Bancos, cntxt);

                    #endregion

                    SetearValores(proveedor, actualizar, cntxt);
                    //SetearValores(proveedor.Domicilio, actualizar.Domicilio, cntxt);
                    SetearValores(proveedor.DatosOld, actualizar.DatosOld, cntxt);


                }
                if (Usuario != null)
                    cntxt.insertaAuditoria<Proveedor>(actualizar, Accion.Modifica, Usuario);
                cntxt.SaveChanges();
            }
            );
        }
    }
}
