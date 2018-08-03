using Inteldev.Core.DTO.Contabilidad;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Contabilidad
{
    public class BuscadorReferencia
    {
        private ConceptoDeMovimiento concepto;
        private Imputaciones imputacion;

        public BuscadorReferencia()
        {
            this.concepto = null;
        }

        public void BuscarReferencia(Empresa empresa, TipoDocumento tipoDocumento, TipoConcepto tipoConcepto)
        {
            if (tipoConcepto != TipoConcepto.Neto1 && tipoConcepto != TipoConcepto.Exento)
            {
                var buscadorReferencia = FabricaNegocios._Resolver<IBuscadorDTO<Inteldev.Fixius.Modelo.Contabilidad.ReferenciaContable, Inteldev.Fixius.Servicios.DTO.Contabilidad.ReferenciaContable>>();
                Fixius.Servicios.DTO.Contabilidad.ReferenciaContable referenciaContable = new Servicios.DTO.Contabilidad.ReferenciaContable();
                var referenciasContables = buscadorReferencia.BuscarLista(1, Core.CargarRelaciones.CargarTodo).Where(p => p.Empresa.Id == empresa.Id);
                switch (tipoConcepto)
                {
                    case TipoConcepto.IvaTasaGeneral:
                    case TipoConcepto.IvaTasaReducida:
                    case TipoConcepto.IvaTasaDiferencial:
                        if(tipoDocumento == TipoDocumento.Factura)
                            referenciaContable = referenciasContables.Where(p=> p.Imputacion == Core.DTO.Contabilidad.Imputaciones.IVACF).FirstOrDefault();
                        else
                            referenciaContable = referenciasContables.Where(p => p.Imputacion == Core.DTO.Contabilidad.Imputaciones.IVADF).FirstOrDefault();
                        break;
                    case TipoConcepto.ImpuestoInterno:
                        referenciaContable = referenciasContables.Where(p=>p.Imputacion == Imputaciones.ImpInternos).FirstOrDefault();
                        break;
                    case TipoConcepto.PercepcionIva:
                        referenciaContable = referenciasContables.Where(p=>p.Imputacion == Imputaciones.PercepcionIva).FirstOrDefault();
                        break;
                    case TipoConcepto.PercepcionIIBB:
                        referenciaContable = referenciasContables.Where(p=>p.Imputacion == Imputaciones.PercepcionIIBB).FirstOrDefault();
                        break;
                    case TipoConcepto.Final:
                        referenciaContable = referenciasContables.Where(p => p.Imputacion == Core.DTO.Contabilidad.Imputaciones.ProveedoresVarios).FirstOrDefault();
                        break;
                    default:
                        break;
                }
                if (referenciaContable != null)
                {
                    this.concepto = referenciaContable.Concepto;
                    this.imputacion = referenciaContable.Imputacion;
                }
            }
        }

        public Core.DTO.Contabilidad.Imputaciones ObtenerImputacion()
        {
            return this.imputacion;
        }

        public ConceptoDeMovimiento ObtenerConceptoMovimiento()
        {
            return this.concepto;
        }

    }
}
