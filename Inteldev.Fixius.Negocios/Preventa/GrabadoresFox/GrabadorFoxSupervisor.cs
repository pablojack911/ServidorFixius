using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.GrabadoresFox
{
    public class GrabadorFoxSupervisor : GrabadorFox<Supervisor>
    {
        public GrabadorFoxSupervisor(IDao con)
            : base(con)
        {

        }
        public override void Configurar(Supervisor entidad)
        {
            this.Tabla = "operator";
            this.ClavePrimaria = "Codigo+trans(cargo)";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(2, '0'), "6");
        }

        public override void ConfigurarCamposValores(Supervisor entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            this.CamposValores.Add("cargo", 6);
            this.GrabarPreventistas(entidad.Codigo, entidad.Preventistas);
        }

        private void GrabarPreventistas(string codigoSupervisor, ICollection<Preventista> preventistas)
        {
            var dr = this.Dao.EjecutarConsulta(@"select codigo from s://preventa//datos//operator where supervisor='" + codigoSupervisor + "' group by codigo");
            while (dr.Read())
            {
                foreach (var prev in preventistas)
                {
                    var cod = dr.GetString(0).Trim(); //preventista
                    if (!preventistas.Any(p => p.Codigo.Equals(cod))) //el codigo de la consulta anterior no está en la lista de preventistas actualmente supervisadas por este supervisor
                    {
                        this.Dao.EjecutarComando(string.Format(@"update operator set supervisor = ' ' where codigo='{0}'", cod)); // le quito el supervisor a los que ya no son supervisados por este supervisor
                    }
                }
            }

            foreach (var prev in preventistas)
            {
                this.Dao.EjecutarComando(string.Format(@"update operator set supervisor = '{0}' where codigo='{1}'", codigoSupervisor, prev.Codigo));
            }
            dr.Close();
            dr.Dispose();
        }


    }
}
