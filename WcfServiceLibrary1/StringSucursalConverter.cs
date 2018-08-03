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
    public class StringSucursalConverter : ITypeConverter<string, Sucursal>
    {
        public Sucursal Convert(ResolutionContext context)
        {
            try
            {
                var codigoSucursal = context.SourceValue.ToString();
                ParameterOverride[] para = { new ParameterOverride("empresa", ""), new ParameterOverride("entidad", "sucursal") };
                var buscaSucursal = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Inteldev.Core.DTO.Organizacion.Sucursal>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Sucursal, Inteldev.Core.DTO.Organizacion.Sucursal>), para);
                return buscaSucursal.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Sucursal>(codigoSucursal, Core.CargarRelaciones.CargarTodo, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
