using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class StringEmpresaConverter : ITypeConverter<string, Empresa>
    {
        public Empresa Convert(ResolutionContext context)
        {
            try
            {
                var codigoEmpresa = context.SourceValue.ToString();
                ParameterOverride[] para = { new ParameterOverride("empresa", ""), new ParameterOverride("entidad", "empresa") };
                var buscaEmpresa = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>), para);
                return buscaEmpresa.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Empresa>(codigoEmpresa, Core.CargarRelaciones.CargarTodo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
