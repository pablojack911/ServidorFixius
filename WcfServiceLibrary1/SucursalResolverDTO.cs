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
    public class SucursalResolverDTO : ValueResolver<string, Sucursal>
    {
        protected override Sucursal ResolveCore(string source)
        {
            if (source != null)
            {
                try
                {
                    ParameterOverride[] para = { new ParameterOverride("empresa", "01"), new ParameterOverride("entidad", "sucursal") };
                    var buscaSucursal = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Inteldev.Core.DTO.Organizacion.Sucursal>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Inteldev.Core.DTO.Organizacion.Sucursal>), para);
                    return buscaSucursal.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Sucursal>(source, Core.CargarRelaciones.CargarTodo, null);
                }
                catch (Exception ex)
                {
                    Debug.Print("Error Resolver Sucursal to DTO: " + ex.Message);
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
