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
    public class MapeadorFamiliasFox : MapeadorFox<Familia>
    {
        private BuscadorFamilia buscador;
        private BuscadorSubsector buscadorSubsector;
        public MapeadorFamiliasFox(IDao con, string empresa, string entidad)
            : base("familia", @"select * from s:\appvfp\hergo_release\datos\familia where !empty(area) and !empty(sector) and !empty(subsector)", "codigo", con, empresa, entidad)
        {
            //Buscador para Familia para el ObtenerEntidad
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", "01");
            parameter[1] = new ParameterOverride("entidad", "familia");
            this.buscador = (BuscadorFamilia)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Familia>), parameter);

            //Buscador para Subsector
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", "01");
            parameters[1] = new ParameterOverride("entidad", "Subsector");
            this.buscadorSubsector = (BuscadorSubsector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Articulos.Subsector>), parameters);
        }
        protected override Familia Mapear(Familia entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            var codigoArea = registro["area"].ToString();
            var codigoSector = registro["sector"].ToString();
            var codigoSubsector = registro["subsector"].ToString();

            entidad.Subsector = this.buscadorSubsector.ObtenerSubsector(codigoSubsector, codigoSector, codigoArea);

            return entidad;
        }

        protected override Familia ObtenerEntidad(System.Data.DataRow item)
        {
            var codigo = item["codigo"].ToString();
            var codigoArea = item["area"].ToString();
            var codigoSector = item["sector"].ToString();
            var codigoSubsector = item["subsector"].ToString();

            var entidad = buscador.ObtenerFamilia(codigo, codigoSubsector, codigoSector, codigoArea);
            if (entidad == null)
                entidad = this.CrearNueva();
            return entidad;
        }

        public override string[] ObtenerFiltroBorrador(Core.Modelo.EntidadMaestro entidad)
        {
            var ent = (Familia)entidad;

            return new string[] 
            { 
                ent.Codigo, 
                ent.Subsector == null ? "" : ent.Subsector.Codigo, 
                ent.Subsector.Sector == null ? "" : ent.Subsector.Sector.Codigo, 
                ent.Subsector.Sector.Area == null ? "" : ent.Subsector.Sector.Area.Codigo 
            };
        }
    }
}
