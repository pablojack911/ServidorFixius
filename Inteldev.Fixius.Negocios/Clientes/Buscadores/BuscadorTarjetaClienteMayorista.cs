using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public class BuscadorTarjetaClienteMayorista : BuscadorGenerico<TarjetaClienteMayorista>
    {
        public BuscadorTarjetaClienteMayorista(string empresa, string entidad)
            : base(empresa, "TarjetaClienteMayorista")
        {

        }
        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {
            var listaFiltrada = new List<TarjetaClienteMayorista>();
            var listaCodigosLocal = this.Contexto.Consultar<TarjetaClienteMayorista>(CargarRelaciones.CargarEntidades).Where(x => x.Hereda == null).Select(p => new { p.Id, p.Codigo });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p => p[0] == item.Codigo)))
                    listaFiltrada.Add(this.Contexto.Consultar<TarjetaClienteMayorista>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
            }
            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }
    }
}
