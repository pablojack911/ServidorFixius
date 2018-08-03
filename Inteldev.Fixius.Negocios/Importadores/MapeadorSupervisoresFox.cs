using Inteldev.Core.Datos;
using Inteldev.Datos.Dao;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorSupervisoresFox : MapeadorFox<Supervisor>
    {
        public MapeadorSupervisoresFox(Inteldev.Core.Datos.IDao con, String empresa, string entidad)
            : base("operator", "select * from operator order by codigo GROUP BY codigo where cargo = 6", "codigo", con, empresa, entidad)
        {
        }

        protected override Supervisor Mapear(Supervisor entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();

            // Mobile
            entidad.Usuario = registro["user"].ToString().Trim();
            entidad.Password = registro["pass"].ToString().Trim();
            entidad.Foto = registro["Foto"].ToString().Trim();

            // Datos Anteriores
            if (entidad.DatosOldPreventa == null)
                entidad.DatosOldPreventa = new DatosOldPreventa();

            entidad.DatosOldPreventa.EsSupervisor = ObtenerBoolDeString(registro["essupervisor"].ToString());
            entidad.DatosOldPreventa.Inactivo = ObtenerBoolDeString(registro["inactivo"].ToString());


            var drPreventistasDelSupervisor = dao.EjecutarConsulta("select codigo from s://preventa//datos//operator where supervisor='" + entidad.Codigo + "' group by codigo");

            while (drPreventistasDelSupervisor.Read())
            {

                string codigoPreventista = drPreventistasDelSupervisor[0].ToString();
                Preventista prev = BuscarEntidadPorCodigo<Preventista>(codigoPreventista);
                if (prev != null)
                    entidad.Preventistas.Add(prev);
                else
                    Debug.Write("No existe el preventista " + codigoPreventista + " en la base de datos local. (POCHO)");
            }
            drPreventistasDelSupervisor.Close();
            drPreventistasDelSupervisor.Dispose();
            //dao.Desconectar();

            return entidad;
        }
    }
}
