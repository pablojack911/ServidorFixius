using AutoMapper;
using Inteldev.Core.DTO.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class EmpresaResolverEntidad : ValueResolver<Empresa, string>
    {
        protected override string ResolveCore(Empresa source)
        {
            if (source != null)
                return source.Codigo;
            else
                return "";
        }
    }
}
