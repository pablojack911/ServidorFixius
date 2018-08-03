using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Creadores
{
	public class CreadorDevolucionDeMercaderia : CreadorDTO<Modelo.Proveedores.DevolucionDeMercaderia,Servicios.DTO.Proveedores.DevolucionDeMercaderia>
	{
		public CreadorDevolucionDeMercaderia(ICreador<Modelo.Proveedores.DevolucionDeMercaderia> creadorEntidad,IMapeadorGenerico<Modelo.Proveedores.DevolucionDeMercaderia,Servicios.DTO.Proveedores.DevolucionDeMercaderia> mapeador,string empresa, string entidad) : base(creadorEntidad,mapeador,empresa, entidad) { }

		/// <summary>
		/// args[0] = proveedor
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public override CreadorCarrier<Servicios.DTO.Proveedores.DevolucionDeMercaderia> Crear(params int[] args)
		{
			var buscadorProveedor = FabricaNegocios._Resolver<IBuscadorDTO<Modelo.Proveedores.Proveedor,Servicios.DTO.Proveedores.Proveedor>>();
			var creadorDevolucion = FabricaNegocios._Resolver<ICreador<Modelo.Proveedores.DevolucionDeMercaderia>>();
			var devolucion = creadorDevolucion.Crear();
			var result = this.Mapeador.EntidadToDto(devolucion);
			result.Proveedor = buscadorProveedor.BuscarSimple(args[0],Core.CargarRelaciones.NoCargarNada);
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Proveedores.DevolucionDeMercaderia>();
            creadorCarrier.SetEntidad(result);
			return creadorCarrier;
		}
	}
}
