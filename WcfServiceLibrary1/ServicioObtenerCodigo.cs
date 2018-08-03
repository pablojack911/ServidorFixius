using Inteldev.Core.Negocios;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Proveedores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class ServicioObtenerCodigo : IServicioObtenerCodigo
    {
        public string CodigoDisponible(string desde)
        {
            //var codigoDisponible = "0".PadLeft(13, '0');
            long elElegido = 0;

            if (desde == null || desde == "" || desde == "0")
                desde = "1".PadLeft(13, '0');
            var LongDesde = long.Parse(desde);

            var paramers = new ParameterOverride[2];
            paramers[0] = new ParameterOverride("empresa", "01");
            paramers[1] = new ParameterOverride("entidad", "Articulo");
            var buscador = (BuscadorArticulo)FabricaNegocios.Instancia.Resolver(typeof(BuscadorArticulo), paramers);

            if (buscador != null)
            {
                //desde debo incrementar cada 1000
                //while (String.Compare(codigoDisponible, "0".PadLeft(13, '0')) != 0)
                do
                {
                    var listaCodigos = buscador.ObtenerListaCodigos<Articulo>(LongDesde);
                    long i = LongDesde;
                    foreach (var codigo in listaCodigos)
                    {
                        var codigoLong = long.Parse(codigo);
                        if (codigoLong > i)
                        {
                            elElegido = i;
                            break;
                        }
                        else
                            i++;
                    }
                    LongDesde = i;
                }
                while (elElegido == 0);
            }

            //return codigoDisponible;
            return elElegido.ToString().PadLeft(13, '0');
        }
    }
}
