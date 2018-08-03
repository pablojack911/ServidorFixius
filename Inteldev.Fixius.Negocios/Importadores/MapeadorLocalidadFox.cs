using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class MapeadorLocalidadFox : MapeadorFox<Localidad>
    {
        public MapeadorLocalidadFox(IDao con, string empresa, string entidad)
            : base("Localida", "copostal", con, empresa, entidad)
        {
        }

        protected override Localidad Mapear(Localidad entidad, System.Data.DataRow registro)
        {
            
            entidad.Codigo = registro["Copostal"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            var prov = this.BuscarEntidadPorCodigo<Provincia>("01");
            if (prov == null)
                prov = this.AgregarProvincia();

            entidad.Provincia = prov;

            return entidad;
        }

        private Provincia AgregarProvincia()
        {
            ParameterOverride[] parameters = new ParameterOverride[2];
            parameters[0] = new ParameterOverride("empresa", "01");
            parameters[1] = new ParameterOverride("entidad", "Provincia");


            var tipograbador = typeof(IGrabador<>);
            var tipoGrabadorGenerico = tipograbador.MakeGenericType(typeof(Provincia));

            LogManager.Instancia.AgregarMensaje(string.Format("Creado el Grabador de la entidad {0}", typeof(Provincia).ToString()));
            dynamic grabador = FabricaNegocios.Instancia.Resolver(tipoGrabadorGenerico, parameters);
            var grabadorCarrier = grabador.Grabar(new Provincia() { Nombre = "Buenos Aires", Codigo = "01" });//necesitamos ingresar una provincia BsAs para todas las localidades

            return this.BuscarEntidadPorCodigo<Provincia>("01");
        }
    }
}
