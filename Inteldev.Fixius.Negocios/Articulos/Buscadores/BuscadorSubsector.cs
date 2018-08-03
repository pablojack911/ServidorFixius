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
    public class BuscadorSubsector : BuscadorGenerico<Subsector>
    {
        public BuscadorSubsector(string empresa)
            : base(empresa, "subsector")
        {

        }
        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {
            var listaFiltrada = new List<Subsector>();
            var listaCodigosLocal = this.Contexto.Consultar<Subsector>(CargarRelaciones.CargarEntidades).Select(p => new
            {
                p.Id,
                p.Codigo,
                Sector = p.Sector.Codigo,
                Area = p.Sector.Area.Codigo
            });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p =>
                    p[0] == item.Codigo &&
                    p[1] == item.Sector &&
                    p[2] == item.Area)))
                {
                    listaFiltrada.Add(this.Contexto.Consultar<Subsector>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
                }
            }

            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }

        public Subsector ObtenerSubsector(string codigoSubsector, string codigoSector, string codigoArea)
        {
            var subsector = this.Contexto.ObtenerContextos<Subsector>().FirstOrDefault().Set<Subsector>()
                .Include("Sector")
                .Include("Sector.Area")
                .FirstOrDefault(p =>
                    p.Codigo == codigoSubsector &&
                    p.Sector.Codigo == codigoSector &&
                    p.Sector.Area.Codigo == codigoArea);
            return subsector;
        }

        public Subsector ObtenerSubsector(string codigoSubsector, int idSector)
        {
            var subsector = this.Contexto.ObtenerContextos<Subsector>().FirstOrDefault().Set<Subsector>()
                .Include("Sector")
                    .FirstOrDefault(p =>
                        p.Codigo == codigoSubsector &&
                        p.Sector.Id == idSector);
            return subsector;
        }

        public override Subsector BuscarSimple(object busqueda)
        {
            var subsector = this.Contexto.ObtenerContextos<Subsector>().FirstOrDefault().Set<Subsector>()
               .Include("Sector")
               .Include("Sector.Area")
               .FirstOrDefault(p => p.Id == (int)busqueda);
            return subsector;
        }
    }
}
