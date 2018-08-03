using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class EmpresaResolverEntidadColleccion : ValueResolver<List<Empresa>,List<EmpresaCodigo>>
    {
        protected override List<EmpresaCodigo> ResolveCore(List<Empresa> source)
        {
            if (source != null)
            {
                var result = new List<EmpresaCodigo>();
                foreach (var item in source)
                {
                    result.Add(new EmpresaCodigo() { Codigo = item.Codigo });   
                }
                return result;
            }
            else
                return new List<EmpresaCodigo>();
        }
    }
}
