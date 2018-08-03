using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Negocios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class EmpresaResolverDTO : ValueResolver<string, Empresa>
    {
        protected override Empresa ResolveCore(string source)
        {
            if (source != null)
            {
                try
                {
                    ParameterOverride[] para = { new ParameterOverride("empresa", ""), new ParameterOverride("entidad", "empresa") };
                    var buscaEmpresa = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>), para);
                    return buscaEmpresa.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Empresa>(source, Core.CargarRelaciones.CargarTodo, null);
                }
                catch (Exception ex)
                { }
                return null;
            }
            else
            {
                return null;
            }

        }
    }
}
