using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Numeradores
{
    public class NumeradorRutaDeVenta : LogicaDeNegociosBase<RutaDeVenta>, INumerador<RutaDeVenta>
    {
        public NumeradorRutaDeVenta(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        public string ProximoCodigo(RutaDeVenta entidad = null)
        {
            throw new NotImplementedException();
        }

        public int TamañoMaximo { get; set; }

        public string UltimoCodigo()
        {
            throw new NotImplementedException();
        }

        public string IncrementaLetra(string codigoLetra)
        {
            throw new NotImplementedException();
        }


        public string ProximoCodigoDisponibleConPrefijo(string prefijo, string resto, int tamañomax)
        {
            throw new NotImplementedException();
        }

        public string ProximoCodigoDisponibleSoloNumero(long LongDesde, int tamañoMaximo)
        {
            throw new NotImplementedException();
        }
    }
}
