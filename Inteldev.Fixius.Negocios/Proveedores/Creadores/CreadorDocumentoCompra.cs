using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Extenciones;
using Microsoft.Practices.Unity;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
    public class CreadorDocumentoCompra : CreadorDTO<Modelo.Proveedores.DocumentoCompra, Servicios.DTO.Proveedores.DocumentoCompra>
    {
        public CreadorDocumentoCompra(ICreador<Modelo.Proveedores.DocumentoCompra> creadorEntidad, IMapeadorGenerico<Modelo.Proveedores.DocumentoCompra, Servicios.DTO.Proveedores.DocumentoCompra> mapeador, string empresa, string entidad)
            : base(creadorEntidad, mapeador, empresa, entidad)
        {
        }

        ///// <summary>
        ///// args[0] = condicionAnteIVA empresa
        ///// args[1] = proveedor
        ///// args[2] = Tipo de Documento
        ///// args[3] = numero
        ///// args[4] = prenumero
        ///// args[5] = empresa
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //public override CreadorCarrier<Servicios.DTO.Proveedores.DocumentoCompra> Crear(params int[] args)
        //{

        //    ////aca tengo que obtener la letra del proveedor
        //    //ParameterOverride[] parameters = new ParameterOverride[2];
        //    //parameters[0] = new ParameterOverride("empresa", this.empresa);
        //    //parameters[1] = new ParameterOverride("entidad", "Letra");
        //    //var buscadorLetra = (IBuscadorLetra)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorLetra), parameters);
        //    //parameters[1] = new ParameterOverride("entidad", "Proveedor");
        //    //var buscadorProveedor = (IBuscadorDTO<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>), parameters);
        //    //parameters[0] = new ParameterOverride("empresa", "");
        //    //parameters[1] = new ParameterOverride("entidad", "Empresa");
        //    //var buscadorEmpresa = (IBuscadorDTO<Core.Modelo.Organizacion.Empresa, Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Core.Modelo.Organizacion.Empresa, Core.DTO.Organizacion.Empresa>), parameters);
        //    //parameters[0] = new ParameterOverride("empresa", this.empresa);
        //    //parameters[1] = new ParameterOverride("entidad", "DocumentoProveedor");
        //    //var buscadorComprobante = (IBuscadorComprobante)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorComprobante), parameters);
        //    //parameters[1] = new ParameterOverride("entidad", "DocumentoCompra");

        //    //var buscadorDocumento = (IBuscadorDocumentoDeCompra)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDocumentoDeCompra), parameters);
        //    ////var proveedor = buscadorProveedor.BuscarPorCodigo<ComprobanteDeCompra>(args[1],Core.CargarRelaciones.NoCargarNada);
        //    //var proveedor = buscadorProveedor.BuscarSimple(args[1], Core.CargarRelaciones.CargarTodo);
        //    ////var empresa = buscadorEmpresa.BuscarSimple(args[5],Core.CargarRelaciones.NoCargarNada);
        //    //var condicion = (Modelo.Fiscal.CondicionAnteIVA)proveedor.CondicionAnteIva;
        //    //string letra = buscadorLetra.ObtenerLetra((Modelo.Fiscal.CondicionAnteIVA)args[0], condicion, (Modelo.Proveedores.TipoDocumento)args[2]);
        //    //var result = base.Crear().GetEntidad();
        //    //result.Prenumero = args[4].ToString();
        //    //result.TipoDocumento = (Servicios.DTO.Proveedores.TipoDocumento)args[2];
        //    //result.Numero = args[3].ToString();
        //    //result.Proveedor = proveedor;
        //    //result.FormaDePago = proveedor.FormaDePago;
        //    //result.ProveedorId = proveedor.Id;
        //    //result.Letra = letra;
        //    //result.Empresa = buscadorEmpresa.BuscarSimple(args[5], Core.CargarRelaciones.NoCargarNada);
        //    ////result.EmpresaId = result.Empresa.Id;
        //    //parameters[1] = new ParameterOverride("entidad", "ReferenciaContable");
        //    //var buscadorImputacion = (IBuscadorDTO<Inteldev.Fixius.Modelo.Contabilidad.ReferenciaContable, Inteldev.Fixius.Servicios.DTO.Contabilidad.ReferenciaContable>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Fixius.Modelo.Contabilidad.ReferenciaContable, Inteldev.Fixius.Servicios.DTO.Contabilidad.ReferenciaContable>), parameters);
        //    //ReferenciaContable imputacion = new ReferenciaContable();
        //    //try
        //    //{
        //    //    imputacion = buscadorImputacion.BuscarLista(1, Core.CargarRelaciones.CargarTodo).Where(p => p.Empresa == result.Empresa && p.Imputacion == Core.DTO.Contabilidad.Imputaciones.ProveedoresVarios).FirstOrDefault();
        //    //}
        //    //catch (NullReferenceException e)
        //    //{
        //    //    imputacion = null;
        //    //}

        //    //if (imputacion != null)
        //    //{
        //    //    result.ItemsConceptos.Add(new Servicios.DTO.Proveedores.ItemsConceptos() { Concepto = imputacion.Concepto, Tipo = Servicios.DTO.Proveedores.TipoConcepto.Final });
        //    //}

        //    var creadorCarrier = new CreadorCarrier<Servicios.DTO.Proveedores.DocumentoCompra>();
        //    ////aca tengo que fijarme que no este repetido el numero, proveedor
        //    //if (buscadorComprobante.BuscarRepetido(result.Proveedor.Id, result.Numero, result.Prenumero, result.Letra, (Modelo.Proveedores.TipoDocumento)result.TipoDocumento) != null)
        //    //{
        //    //    creadorCarrier.SetError(true);
        //    //    creadorCarrier.SetMensaje(string.Format("Comprobante repetido para proveedor {0}", proveedor.Nombre));
        //    //}
        //    //else
        //    //    creadorCarrier.SetEntidad(result);
        //    ////buscar todos los notas de credito internas pendientes
        //    //List<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra> notas = new List<Servicios.DTO.Proveedores.DocumentoCompra>();
        //    //if (result.TipoDocumento == Servicios.DTO.Proveedores.TipoDocumento.NotaDeCredito)
        //    //{
        //    //    notas = this.Mapeador.ToListDto(buscadorDocumento.BuscaNCInternasPendiente(proveedor.Id));
        //    //}
        //    //else
        //    //{
        //    //    if (result.TipoDocumento == Servicios.DTO.Proveedores.TipoDocumento.NotaDeDebito)
        //    //        notas = this.Mapeador.ToListDto(buscadorDocumento.BuscaNDInternasPendiente(proveedor.Id));
        //    //}
        //    //if (notas != null)
        //    //{
        //    //    foreach (var item in notas)
        //    //    {
        //    //        var nota = item.Clonar<Inteldev.Fixius.Servicios.DTO.Proveedores.NotaPendiente>();
        //    //        result.NotasPendientes.Add(nota);
        //    //    }
        //    //}
        //    return creadorCarrier;
        //}

        public override CreadorCarrier<Servicios.DTO.Proveedores.DocumentoCompra> Crear(params string[] args)
        {
            var nuevoDoc = new Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra();

            var creadorCarrier = new CreadorCarrier<Inteldev.Fixius.Servicios.DTO.Proveedores.DocumentoCompra>();

            #region interpretacion de parametros

            var empresa = args[0];
            var sucursal = args[1];
            var provId = Convert.ToInt32(args[2]);
            var tipoDoc = Convert.ToInt32(args[3]);
            var preNro = args[4];
            var nro = args[5];

            #endregion

            #region resolución de buscadores

            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", this.empresa);

            parameters[1] = new ParameterOverride("entidad", "Empresa");
            var buscadorEmpresa = (IBuscadorDTO<Core.Modelo.Organizacion.Empresa, Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Core.Modelo.Organizacion.Empresa, Core.DTO.Organizacion.Empresa>), parameters);

            parameters[1] = new ParameterOverride("entidad", "Sucursal");
            var buscadorSucursal = (IBuscadorDTO<Core.Modelo.Organizacion.Sucursal, Core.DTO.Organizacion.Sucursal>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Core.Modelo.Organizacion.Sucursal, Core.DTO.Organizacion.Sucursal>), parameters);

            parameters[1] = new ParameterOverride("entidad", "Proveedor");
            var buscadorProveedor = (IBuscadorDTO<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Modelo.Proveedores.Proveedor, Servicios.DTO.Proveedores.Proveedor>), parameters);

            #endregion

            #region busquedas

            var emp = buscadorEmpresa.BuscarSimple(empresa, Core.CargarRelaciones.NoCargarNada);
            var suc = buscadorSucursal.BuscarSimple(sucursal, Core.CargarRelaciones.NoCargarNada);
            var tipoDocumento = (Inteldev.Fixius.Servicios.DTO.Proveedores.TipoDocumento)tipoDoc;
            var prov = buscadorProveedor.BuscarSimple(provId, Core.CargarRelaciones.NoCargarNada);

            #endregion

            nuevoDoc.Empresa = emp;
            nuevoDoc.Sucursal = suc;
            nuevoDoc.TipoDocumento = tipoDocumento;
            nuevoDoc.Proveedor = prov;
            nuevoDoc.Prenumero = preNro;
            nuevoDoc.Numero = nro;
            nuevoDoc.Fecha = DateTime.Now;
            nuevoDoc.FechaContable = DateTime.Now;
            nuevoDoc.FechaIngreso = DateTime.Now;
            nuevoDoc.FechaVencimiento = DateTime.Now;

            creadorCarrier.SetEntidad(nuevoDoc);

            return creadorCarrier;
        }
    }
}
