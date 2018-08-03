using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Fiscal;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
	public class BuscadorLetra : Inteldev.Fixius.Negocios.Proveedores.Buscadores.IBuscadorLetra
	{
        public string ObtenerLetra(CondicionAnteIVA CondicionDeIvaEmpresa, CondicionAnteIVA CondicionDeIvaProveedor, TipoDocumento documento)
        {
            string result = "A";
            var poneLetra = FabricaNegocios._Resolver<IPoneLetra>();
            poneLetra.ItemLetra.documento = documento;
            poneLetra.ItemLetra.condicionAnteIVAEmpresa = CondicionDeIvaEmpresa;
            poneLetra.ItemLetra.condicionAnteIVAProveedor = CondicionDeIvaProveedor;
            result = poneLetra.ObtenerLetra(poneLetra.ItemLetra);
            return result;
        }
    }
}
