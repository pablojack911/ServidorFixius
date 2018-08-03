using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorSectoresFox : MapeadorFox<Sector>
    {
        public MapeadorSectoresFox(IDao con, string empresa, string entidad)
            : base("sector", @"select * from s:\appvfp\hergo_release\datos\sector where !empty(area)", "codigo", con, empresa, entidad)
        {

        }
        protected override Sector Mapear(Sector entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Area = this.BuscarEntidadPorCodigo<Area>(registro["area"].ToString());

            return entidad;
        }

        public override string[] ObtenerFiltroBorrador(Core.Modelo.EntidadMaestro entidad)
        {
            var ent = (Sector)entidad;
            var devuelve = new string[]{
                ent.Codigo,
                ent.Area.Codigo};
            return devuelve;
        }

        protected override Sector ObtenerEntidad(System.Data.DataRow item)
        {
            string codigo = item["codigo"].ToString();
            string codigoArea = item["area"].ToString();

            var entidad = this.ObtenerEntidad(sector =>
            {
                if (sector.Area != null)
                    if (sector.Codigo == codigo &&
                        sector.Area != null && sector.Area.Codigo == codigoArea)
                        return true;
                return false;
            });

            return entidad;
        }
        //private Area AgregarArea()
        //{
        //    ParameterOverride[] parameters = new ParameterOverride[2];
        //    parameters[0] = new ParameterOverride("empresa", "01");
        //    parameters[1] = new ParameterOverride("entidad", "Area");


        //    var tipograbador = typeof(IGrabador<>);
        //    var tipoGrabadorGenerico = tipograbador.MakeGenericType(typeof(Area));

        //    LogManager.Instancia.AgregarMensaje(string.Format("Creado el Grabador de la entidad {0}", typeof(Area).ToString()));
        //    dynamic grabador = FabricaNegocios.Instancia.Resolver(tipoGrabadorGenerico, parameters);
        //    var grabadorCarrier = grabador.Grabar(new Area() { Nombre = "Area 1", Codigo = "001" });//necesitamos ingresar una provincia BsAs para todas las localidades

        //    return this.BuscarEntidadPorCodigo<Area>("001");
        //}
    }
}
