using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Contratos;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Servicios
{
    public class ServicioObtenerCodigoDisponible<TMaestro> : IServicioObtenerCodigoDisponible where TMaestro : EntidadMaestro
    {

        public string CodigoDisponible(string desde)
        {
            var paramers = new ParameterOverride[2];
            paramers[0] = new ParameterOverride("empresa", "01");
            paramers[1] = new ParameterOverride("entidad", "Articulo");

            var buscador = (BuscadorGenerico<TMaestro>)FabricaNegocios.Instancia.Resolver(typeof(BuscadorGenerico<TMaestro>), paramers);
            var numerador = (Numerador<TMaestro>)FabricaNegocios.Instancia.Resolver(typeof(INumerador<TMaestro>), paramers);

            long elElegido = 0;

            if (desde == null || desde == "" || desde == "0")
                desde = "1".PadLeft(numerador.TamañoMaximo, '0');

            var LongDesde = long.Parse(desde);

            if (buscador != null)
            {
                //desde debo incrementar cada 1000
                //while (String.Compare(codigoDisponible, "0".PadLeft(13, '0')) != 0)
                do
                {
                    var listaCodigos = buscador.ObtenerListaCodigos<TMaestro>(LongDesde);
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
            return elElegido.ToString().PadLeft(numerador.TamañoMaximo, '0');
        }
    }
}
