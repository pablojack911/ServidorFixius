using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public class BuscadorPercepcionPorPadron : LogicaDeNegociosBase<PadronIIBB>, IBuscadorPercepcion
    {
        public BuscadorPercepcionPorPadron()
            : base()
        {

        }

        public BuscadorPercepcionPorPadron(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        public decimal ObtenerPorcentajeDePercepcion(string Cuit)
        {
            var padron = this.Contexto.Consultar<PadronIIBB>(Core.CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.CUIT == Cuit);
            if (padron != null)
                return padron.Percepcion;
            else
                return 8;
        }
    }
}
