using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;

namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
	public interface IBuscadorDTOOrdenDeCompra : IBuscadorDTO<Inteldev.Fixius.Modelo.Proveedores.OrdenDeCompra,Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra>
	{
		//Inteldev.Fixius.Servicios.DTO.Proveedores.OrdenDeCompra BuscarSimple(object busqueda, CargarRelaciones cargarEntidades);
		List<OrdenDeCompra> BuscarOrdenes(EstadoOrdenDeCompra estado, int ProveedorId);
	}
}
