using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Modelo.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Grabadores
{
	public class GrabadorDevolucionDeMercaderia : GrabadorGenerico<Inteldev.Fixius.Modelo.Proveedores.DevolucionDeMercaderia>
	{
		public GrabadorDevolucionDeMercaderia(string empresa, string entidad, Inteldev.Core.Negocios.Validadores.IValidador<Modelo.Proveedores.DevolucionDeMercaderia> validador) : base(empresa, entidad, validador)
		{

		}

		public void grabaDebitos(DevolucionDeMercaderia entidad, Usuario Usuario )
		{
			//var buscadorNumero = FabricaNegocios._Resolver<IBuscadorDTO<Inteldev.Core.Modelo.Numerador, Inteldev.Core.DTO.Numerador>>();
			//var numero = buscadorNumero.BuscarLista(entidad.SucursalId, Core.CargarRelaciones.NoCargarNada).Where(p => p.TipoDocumento == Core.DTO.Documentos.ReciboStock).FirstOrDefault();
			//var grabador = FabricaNegocios._Resolver<IGrabador<Inteldev.Fixius.Modelo.Clientes.NotaDeDebitoDeVenta>>();
			//var creadorDevolucionProveedor = FabricaNegocios._Resolver<ICreador<Modelo.Stock.ReciboStock>>();
			//var grabadorDevolucionProveedor = FabricaNegocios._Resolver<IGrabador<Modelo.Stock.ReciboStock>>();
			//foreach (var item in entidad.Detalle)
			//{
			//    var result = new NotaDeDebitoDeVenta();
			//    result.Articulo = item.Articulo;
			//    result.ArticuloId = item.ArticuloId;
			//    if (numero != null)
			//    {
			//        result.Numero = numero.Numero + 1;
			//    }
			//    else
			//        result.Numero = 0;
			//    //aca genero la devolucion de proveedor
			//    var devolucionProveedor = creadorDevolucionProveedor.Crear();
			//    devolucionProveedor.MovimientoStock = new Movimiento();
			//    var detalleMovimiento = new DetalleMovimiento();
			//    detalleMovimiento.Articulo = result.Articulo;
			//    detalleMovimiento.ArticuloId = result.ArticuloId;
			//    detalleMovimiento.Cantidad = result.Cantidad;
			//    //estos dos no se donde ponerlos
			//    //detalleMovimiento.Costo = result.Costo;
			//    //detalleMovimiento.Fecha = result.Fecha;

			//    devolucionProveedor.MovimientoStock.DetalleMovimiento.Add(detalleMovimiento);
			//    //devolucionProveedor.Sucursal = result.Sucursal;
			//    //devolucionProveedor.SucursalId = result.SucursalId;
			//    grabador.Grabar(result,Usuario);
			//    grabadorDevolucionProveedor.Grabar(devolucionProveedor,Usuario);
			//}
		}

		public override Core.DTO.Carriers.GrabadorCarrier GrabarNuevo(DevolucionDeMercaderia Entidad, Core.Modelo.Usuarios.Usuario Usuario)
		{
			this.grabaDebitos(Entidad,Usuario);
			return base.GrabarNuevo(Entidad, Usuario);
		}

		public override Core.DTO.Carriers.GrabadorCarrier GrabarExistente(DevolucionDeMercaderia Entidad, Usuario Usuario)
		{
			this.actualizarDebitos(Entidad, Usuario);
			return base.GrabarExistente(Entidad, Usuario);
		}

		private void actualizarDebitos(DevolucionDeMercaderia Entidad, Usuario Usuario )
		{
			//var buscador = FabricaNegocios._Resolver <Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorNotaDevolucion>();
			//var grabador = FabricaNegocios._Resolver<IGrabador<Inteldev.Fixius.Modelo.Clientes.NotaDeDebitoDeVenta>>();
			//var buscadorNumero = FabricaNegocios._Resolver<IBuscadorDTO<Inteldev.Core.Modelo.Numerador, Inteldev.Core.DTO.Numerador>>();
			//var numero = buscadorNumero.BuscarLista(Entidad.SucursalId, Core.CargarRelaciones.NoCargarNada).Where(p => p.TipoDocumento == Core.DTO.Documentos.ReciboStock).FirstOrDefault();
			//foreach (var item in Entidad.Detalle)
			//{
			//    var elem = buscador.buscaPorArticulo(item.Articulo.Id);
			//    if(elem != null)
			//    {
			//        elem.Articulo = item.Articulo;
			//        elem.Articulo = item.Articulo;
			//        elem.ArticuloId = item.ArticuloId;
			//        if (numero != null)
			//        {
			//            elem.Numero = numero.Numero + 1;
						
			//        }
			//        else
			//            elem.Numero = 0;
			//        grabador.Grabar(elem,Usuario);
			//    }
			//}
		}
	}
}
