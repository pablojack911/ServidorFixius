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
    /// <summary>
    /// Mapeador ficticio. No existe la tabla subsector en fox. Lo que hace es importar, de momento, lo mismo que en sector en subsector
    /// Bue.. ahora si existe...
    /// </summary>
    public class MapeadorSubSectoresFox : MapeadorFox<Subsector>
    {
        private BuscadorSubsector buscador;
        private BuscadorSector buscadorSector;
        public MapeadorSubSectoresFox(IDao con, string empresa, string entidad)
            : base("sector", @"select * from s:\appvfp\hergo_release\datos\subsector where !empty(area) and !empty(sector)", "codigo", con, empresa, entidad)
        {
            //Instanciacion del buscador para el mapeador
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "subsector");
            this.buscador = (BuscadorSubsector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Subsector>), parameter);

            //Instanciacion del buscador para Sector
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", empresa);
            parameters[1] = new ParameterOverride("entidad", "Sector");
            this.buscadorSector = (BuscadorSector)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Modelo.Articulos.Sector>), parameters);
        }
        protected override Subsector Mapear(Subsector entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            var codigoSector = registro["sector"].ToString();
            var codigoArea = registro["area"].ToString();

            entidad.Sector = this.buscadorSector.ObtenerSector(codigoSector, codigoArea);

            return entidad;
        }

        protected override Subsector ObtenerEntidad(System.Data.DataRow item)
        {
            string codigo = item["codigo"].ToString();
            string codigoArea = item["area"].ToString();
            string codigoSector = item["sector"].ToString();

            var entidad = this.buscador.ObtenerSubsector(codigo, codigoSector, codigoArea);
            if (entidad == null)
                entidad = this.CrearNueva();
            return entidad;
        }

        public override string[] ObtenerFiltroBorrador(Core.Modelo.EntidadMaestro entidad)
        {
            var ent = (Subsector)entidad;
            return new string[] 
            { 
                ent.Codigo, 
                ent.Sector.Codigo, 
                ent.Sector.Area.Codigo 
            };
        }
    }
}
