using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Negocios.Articulos.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorSubfamiliasFox : MapeadorFox<Subfamilia>
    {
        private BuscadorSubfamilia buscador;
        private BuscadorFamilia buscadorFamilia;
        public MapeadorSubfamiliasFox(IDao con, string empresa, string entidad)
            : base("subfamilia", @"select * from s:\appvfp\hergo_release\datos\subfamilia where !empty(area) and !empty(sector) and !empty(subsector) and !empty(familia)", "codigo", con, empresa, entidad)
        {
            //Buscador de Subfamilia para el ObtenerEntidad
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subfamilia");
            this.buscador = (BuscadorSubfamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subfamilia>), parameter);

            //Buscador para Familia
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", empresa);
            parameters[1] = new ParameterOverride("entidad", "Familia");
            this.buscadorFamilia = (BuscadorFamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Articulos.Familia>), parameters);
        }

        protected override Subfamilia Mapear(Subfamilia entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            var codigoFamilia = registro["familia"].ToString();
            var codigoSubsector = registro["subsector"].ToString();
            var codigoSector = registro["sector"].ToString();
            var codigoArea = registro["area"].ToString();

            entidad.Familia = this.buscadorFamilia.ObtenerFamilia(codigoFamilia, codigoSubsector, codigoSector, codigoArea);

            return entidad;
        }

        protected override Subfamilia ObtenerEntidad(System.Data.DataRow item)
        {
            string codigo = item["codigo"].ToString(); //codigo de subflia
            string codigoArea = item["area"].ToString();
            string codigoSector = item["sector"].ToString();
            string codigoSubsector = item["subsector"].ToString();
            string codigoFamilia = item["familia"].ToString();

            var entidad = this.buscador.ObtenerSubfamilia(codigo, codigoFamilia, codigoSubsector, codigoSector, codigoArea);
            if (entidad == null)
                entidad = this.CrearNueva();
            return entidad;
        }

        public override string[] ObtenerFiltroBorrador(Core.Modelo.EntidadMaestro entidad)
        {
            var ent = (Subfamilia)entidad;
            var devuelve = new string[]{
                ent.Codigo,
                ent.Familia.Codigo,
                ent.Familia.Subsector.Codigo,
                ent.Familia.Subsector.Sector.Codigo,
                ent.Familia.Subsector.Sector.Area.Codigo};
            return devuelve;
        }
    }
}
