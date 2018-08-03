using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Validadores
{
    public class ValidadorGenerico<TEntidad> : IValidador<TEntidad>
        where TEntidad : EntidadMaestro
    {

        public ValidadorGenerico()
        {

        }

        public bool ExisteError(TEntidad entidad, string empresa, out string mensajeError)
        {
            if (this.codigoIsNull(entidad))
            {
                mensajeError = "Codigo no puede estar vacío.";
                return true;
            }
            else
            {
                if (this.divisionIsNull(entidad))
                {
                    mensajeError = "Debe indicar una Division Comercial.";
                    return true;
                }
                else
                {
                    if (this.empresaIsNull(entidad))
                    {
                        mensajeError = "Debe indicar una Empresa.";
                        return true;
                    }
                    else
                    {
                        if (this.isRepetido(entidad, empresa))
                        {
                            mensajeError = "Codigo repetido.";
                            return true;
                        }
                        //else
                        //{
                        //    if (this.RamoNoCoincideConTarjetaHabilitada(entidad, empresa))
                        //    {
                        //        mensajeError = "El Ramo seleccionado no coincide \ncon la tarjeta que está habilitada actualmente.";
                        //        return true;
                        //    }
                        //}
                        //else
                        //{
                        //    if(this.NumeroDeDocumentoIsRepetido(entidad,empresa))
                        //    {
                        //        mensajeError = "Numero de Documento ya utilizado.";
                        //        return true;
                        //    }
                        //}
                    }
                }
            }
            mensajeError = "No hay error.";
            return false;
        }

        //public virtual bool RamoNoCoincideConTarjetaHabilitada(TEntidad entidad, string empresa)
        //{
        //    return false;
        //}

        //public virtual bool NumeroDeDocumentoIsRepetido(TEntidad entidad, string empresa)
        //{
        //    return false;
        //}

        public virtual bool isRepetido(TEntidad entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", typeof(TEntidad).Name);
            var buscador = (IBuscador<TEntidad>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<TEntidad>), parameter);
            buscador.CargarEntidadesRelacionadas = Core.CargarRelaciones.NoCargarNada;
            if (entidad.Codigo != null && entidad.Codigo != "")
            {
                if (buscador.ExisteCodigo<TEntidad>(entidad.Codigo))
                    //if (buscador.BuscarPorCodigo<TEntidad>(entidad.Codigo) != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public virtual bool codigoIsNull(TEntidad entidad)
        {
            return false;
        }

        public virtual bool divisionIsNull(TEntidad entidad)
        {
            return false;
        }

        public virtual bool empresaIsNull(TEntidad entidad)
        {
            return false;
        }
    }
}
