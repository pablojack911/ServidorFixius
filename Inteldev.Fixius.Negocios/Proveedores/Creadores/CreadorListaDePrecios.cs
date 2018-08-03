using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Negocios.Proveedores.Mapeadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
    public class CreadorListaDePrecios : CreadorDTO<Modelo.Proveedores.ListaDePrecios,Servicios.DTO.Proveedores.ListaDePrecios>
    {
        public CreadorListaDePrecios(ICreador<Modelo.Proveedores.ListaDePrecios> creador,
                                    IMapeadorGenerico<Modelo.Proveedores.ListaDePrecios, 
                                                      Servicios.DTO.Proveedores.ListaDePrecios> mapeador, string empresa, string entidad)
            : base(creador, mapeador, empresa, entidad)
        {
            
        }

        public override CreadorCarrier<Servicios.DTO.Proveedores.ListaDePrecios> Crear(params int[] args)
        {
            var entidad= this.CreadorEntidad.Crear(args);
            ParameterOverride[] parameters = { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", "Proveedor") };
            var buscaprov = (IBuscador<Modelo.Proveedores.Proveedor>) FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Proveedores.Proveedor>), parameters);
            entidad.Proveedor = buscaprov.BuscarSimple(args[0]);
            var devuelve = this.Mapeador.EntidadToDto(entidad);
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Proveedores.ListaDePrecios>();
            creadorCarrier.SetEntidad(devuelve);
			return creadorCarrier;
        }    

        
    }
}
