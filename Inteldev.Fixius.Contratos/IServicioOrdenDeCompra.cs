using Inteldev.Core.Contratos;
using System;
using System.ServiceModel;
namespace Inteldev.Fixius.Contratos
{
	[ServiceContract]
	public interface IServicioOrdenDeCompra : IServicioABM<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra>
	{
		[OperationContract]
		System.Collections.Generic.List<Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra> ObtenerOrdenesDeCompra(Inteldev.Fixius.Servicios.DTO.Proveedores.EstadoOrdenDeCompra estado, int proveedorId);
	}
}
