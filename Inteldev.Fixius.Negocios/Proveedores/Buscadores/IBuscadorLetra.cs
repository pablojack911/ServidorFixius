using Inteldev.Core.Negocios;
using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public interface IBuscadorLetra
	{
		string ObtenerLetra(Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA CondicionDeIvaEmpresa, Inteldev.Fixius.Modelo.Fiscal.CondicionAnteIVA CondicionDeIvaEntidad, Inteldev.Fixius.Modelo.Proveedores.TipoDocumento documento);
	}
}
