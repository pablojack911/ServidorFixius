using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{

    public class MapeadorHeredaTarjetasClienteMayoristaFox : MapeadorFox<TarjetaClienteMayorista>
    {
        public MapeadorHeredaTarjetasClienteMayoristaFox(IDao con, string empresa, string entidad)
            : base("tarjclie", "select * from s://mayorista//datos//tarjclie where !empty(heredade) and codigo<>'06'", "codigo", con, empresa, entidad)
        {
        }

        protected override TarjetaClienteMayorista Mapear(TarjetaClienteMayorista entidad, System.Data.DataRow registro)
        {

            if (registro["codigo"].ToString().Trim() == "00")
            {
                entidad.Codigo = "NA";
            }
            else
            {
                entidad.Codigo = registro["codigo"].ToString().Trim();
            }
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Desde = registro["desde"].ToString().Trim();
            entidad.Hasta = registro["hasta"].ToString().Trim();
            

            String heredade = registro["heredade"].ToString().Trim();

            if (heredade.Trim().Length > 0) 
            {
                TarjetaClienteMayorista tarjeta = this.BuscarEntidadPorCodigo<TarjetaClienteMayorista>(heredade);

                if (tarjeta != null)
                    entidad.Hereda = tarjeta;

            }
            
            entidad.Ramos.Clear();
            this.ImportarRamos(entidad);
            
            return entidad;
        }

        void ImportarRamos(TarjetaClienteMayorista tarjeta)
        {
            var dr = this.dao.EjecutarConsulta(string.Format("select * from s://mayorista//datos//ramos_tarje where tipo_tarje='{0}'", tarjeta.Codigo));

            while (dr.Read())
            {
                var codigoRamo = dr.GetString(1).Trim();
                var ramo = this.BuscarEntidadPorCodigo<Ramo>(codigoRamo);
                if (ramo != null)
                    tarjeta.Ramos.Add(ramo);
            }

            dr.Close();
            dr.Dispose();
            //this.dao.Desconectar();
        }

        public override bool CompararParaBorrar(EntidadMaestro entidad)
        {
            var enti = entidad as TarjetaClienteMayorista;
            return enti.HeredaId!=null && enti.HeredaId!=0;
        } 
    }


}
