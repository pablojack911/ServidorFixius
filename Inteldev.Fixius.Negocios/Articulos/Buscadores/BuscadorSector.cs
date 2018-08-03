using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inteldev.Core;
namespace Inteldev.Fixius.Negocios.Articulos.Buscadores
{
    public class BuscadorSector : BuscadorGenerico<Sector>
    {
        public BuscadorSector(string empresa)
            : base(empresa, "Sector")
        {

        }

        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {
            var listaFiltrada = new List<Sector>();
            var listaCodigosLocal = this.Contexto.Consultar<Sector>(CargarRelaciones.CargarEntidades).Select(p => new
            {
                p.Id,
                p.Codigo,
                Area = p.Area.Codigo
            });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p =>
                    p[0] == item.Codigo &&
                    p[1] == item.Area)))
                {
                    listaFiltrada.Add(this.Contexto.Consultar<Sector>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
                }
            }

            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }

        public Sector ObtenerSector(string codigo, string codigoArea)
        {
            var sector = this.Contexto.ObtenerContextos<Sector>().FirstOrDefault().Set<Sector>()
                .Include("Area")
                .FirstOrDefault(p => p.Codigo == codigo && p.Area.Codigo == codigoArea);
            return sector;
        }

        public override Sector BuscarSimple(object busqueda)
        {
            var sector = this.Contexto.ObtenerContextos<Sector>().FirstOrDefault().Set<Sector>()
                .Include("Area")
                .FirstOrDefault(p => p.Id == (int)busqueda);
            return sector;
        }
    }
}
