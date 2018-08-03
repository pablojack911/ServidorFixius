using Inteldev.Core.DTO.Carriers;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Servicios.DTO.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock
{
	public class CreadorMovimiento : CreadorDTO<Modelo.Stock.Movimiento, Servicios.DTO.Stock.Movimiento>
	{
		public CreadorMovimiento(ICreador<Modelo.Stock.Movimiento> creadorEntidad, IMapeadorGenerico<Modelo.Stock.Movimiento,Servicios.DTO.Stock.Movimiento> mapeador, string empresa, string entidad) : base(creadorEntidad,mapeador,empresa,entidad)
		{

		}
		/// <summary>
		/// Fijarse aca porque no se porque pasa el articulo y la cantidad
		/// args[0] = deposito
		/// args[1] = articulo
		/// args[2] = cantidad
		/// args[3] = tipoMovimiento
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public override CreadorCarrier<Servicios.DTO.Stock.Movimiento> Crear(params int[] args)
		{
			var result = new Servicios.DTO.Stock.Movimiento();
			var buscadorDeposito = FabricaNegocios._Resolver<IBuscadorDTO<Core.Modelo.Stock.Deposito, Inteldev.Core.DTO.Stock.Deposito>>();
			result.DepositoId = args[0];
			result.TipoMovimiento = (TipoMovimiento)args[3];
			result.Fecha = DateTime.Now;
            var creadorCarrier = new CreadorCarrier<Servicios.DTO.Stock.Movimiento>();
            creadorCarrier.SetEntidad(result);
			return creadorCarrier;
		}
	}
}
