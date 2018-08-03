using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Negocios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class EmpresaResolverDTOColleccion : ValueResolver<List<Core.Modelo.Organizacion.EmpresaCodigo>,List<Inteldev.Core.DTO.Organizacion.Empresa>>
    {
        protected override List<Inteldev.Core.DTO.Organizacion.Empresa> ResolveCore(List<Core.Modelo.Organizacion.EmpresaCodigo> source)
        {
            if (source != null)
            {
                var result = new List<Inteldev.Core.DTO.Organizacion.Empresa>();
                ParameterOverride[] para = { new ParameterOverride("empresa", ""), new ParameterOverride("entidad", "empresa") };
                var buscaEmpresa = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>), para);
                foreach (var item in source)
                {    
                    result.Add(buscaEmpresa.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Empresa>(item.Codigo, Core.CargarRelaciones.CargarTodo, null));
                }
                return result;
            }
            else
            {
                return new List<Inteldev.Core.DTO.Organizacion.Empresa>();
            }
        }
    }
}
