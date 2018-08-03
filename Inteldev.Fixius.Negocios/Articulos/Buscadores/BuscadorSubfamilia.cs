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
    public class BuscadorSubfamilia : BuscadorGenerico<Subfamilia>
    {
        public BuscadorSubfamilia(string empresa)
            : base(empresa, "Subfamilia")
        {

        }

        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {
            var listaFiltrada = new List<Subfamilia>();
            var listaCodigosLocal = this.Contexto.Consultar<Subfamilia>(CargarRelaciones.CargarEntidades).Select(p => new
            {
                p.Id,
                p.Codigo,
                Familia = p.Familia.Codigo,
                Subsector = p.Familia.Subsector.Codigo,
                Sector = p.Familia.Subsector.Sector.Codigo,
                Area = p.Familia.Subsector.Sector.Area.Codigo
            });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p =>
                    p[0] == item.Codigo &&
                    p[1] == item.Familia &&
                    p[2] == item.Subsector &&
                    p[3] == item.Sector &&
                    p[4] == item.Area)))
                {
                    listaFiltrada.Add(this.Contexto.Consultar<Subfamilia>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
                }
            }

            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }

        public Subfamilia ObtenerSubfamilia(string codigoSubflia, string codigoFlia, string codigoSubsector, string codigoSector, string codigoArea)
        {
            var subflia = this.Contexto.ObtenerContextos<Subfamilia>().FirstOrDefault().Set<Subfamilia>()
                .Include("Familia")
                .Include("Familia.Subsector")
                .Include("Familia.Subsector.Sector")
                .Include("Familia.Subsector.Sector.Area")
                .FirstOrDefault(p =>
                    p.Codigo == codigoSubflia &&
                    p.Familia.Codigo == codigoFlia &&
                    p.Familia.Subsector.Codigo == codigoSubsector &&
                    p.Familia.Subsector.Sector.Codigo == codigoSector &&
                    p.Familia.Subsector.Sector.Area.Codigo == codigoArea);
            return subflia;
        }

        public Subfamilia ObtenerSubfamilia(string codigoSubflia, int idFamilia)
        {
            var subflia = this.Contexto.ObtenerContextos<Subfamilia>().FirstOrDefault().Set<Subfamilia>()
                .Include("Familia")
                    .FirstOrDefault(p =>
                        p.Codigo == codigoSubflia &&
                        p.Familia.Id == idFamilia);
            return subflia;
        }

        public override Subfamilia BuscarSimple(object busqueda)
        {
            var subflia = this.Contexto.ObtenerContextos<Subfamilia>().FirstOrDefault().Set<Subfamilia>()
                .Include("Familia")
                .Include("Familia.Subsector")
                .Include("Familia.Subsector.Sector")
                .Include("Familia.Subsector.Sector.Area")
                .FirstOrDefault(p => p.Id == (int)busqueda);
            return subflia;
        }

        //public override IQueryable<Subfamilia> ConsultaSimple(CargarRelaciones cargarEntidades)
        //{
        //    return this.Contexto.ObtenerContextos<Subfamilia>().FirstOrDefault().Set<Subfamilia>()
        //        .Include("Familia")
        //        .Include("Familia.Subsector")
        //        .Include("Familia.Subsector.Sector")
        //        .Include("Familia.Subsector.Sector.Area");
        //}
    }
}
