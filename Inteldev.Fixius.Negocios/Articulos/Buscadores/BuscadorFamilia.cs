using Inteldev.Core;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Inteldev.Fixius.Negocios.Articulos.Buscadores
{
    public class BuscadorFamilia : BuscadorGenerico<Familia>
    {
        public BuscadorFamilia(string empresa)
            : base(empresa, "Familia")
        {

        }

        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {
            var listaFiltrada = new List<Familia>();
            var listaCodigosLocal = this.Contexto.Consultar<Familia>(CargarRelaciones.CargarEntidades).Select(p => new
            {
                p.Id,
                p.Codigo,
                Subsector = p.Subsector.Codigo,
                Sector = p.Subsector.Sector.Codigo,
                Area = p.Subsector.Sector.Area.Codigo
            });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p =>
                    p[0] == item.Codigo &&
                    p[1] == item.Subsector &&
                    p[2] == item.Sector &&
                    p[3] == item.Area)))
                {
                    listaFiltrada.Add(this.Contexto.Consultar<Familia>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
                }
            }

            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }

        public Familia ObtenerFamilia(string codigoFlia, string codigoSubsector, string codigoSector, string codigoArea)
        {
            var flia = this.Contexto.ObtenerContextos<Familia>().FirstOrDefault().Set<Familia>()
                 .Include("Subsector")
                 .Include("Subsector.Sector")
                 .Include("Subsector.Sector.Area")
                 .FirstOrDefault(p =>
                     p.Codigo == codigoFlia &&
                     p.Subsector.Codigo == codigoSubsector &&
                     p.Subsector.Sector.Codigo == codigoSector &&
                     p.Subsector.Sector.Area.Codigo == codigoArea);
            return flia;
        }

        public Familia ObtenerFamilia(string codigoFlia, int idSubsector)
        {
            var flia = this.Contexto.ObtenerContextos<Familia>().FirstOrDefault().Set<Familia>()
                .Include("Subsector")
                .FirstOrDefault(p =>
                    p.Codigo == codigoFlia &&
                    p.Subsector.Id == idSubsector);
            return flia;
        }

        public override Familia BuscarSimple(object busqueda)
        {
            var flia = this.Contexto.ObtenerContextos<Familia>().FirstOrDefault().Set<Familia>()
                 .Include("Subsector")
                 .Include("Subsector.Sector")
                 .Include("Subsector.Sector.Area")
                 .FirstOrDefault(p => p.Id == (int)busqueda);
            return flia;
        }
    }
}
