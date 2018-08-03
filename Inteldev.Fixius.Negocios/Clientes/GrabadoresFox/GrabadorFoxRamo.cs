using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    public class GrabadorFoxRamo : GrabadorFox<Ramo>
    {
        public GrabadorFoxRamo(IDao dao)
            : base(dao)
        { }

        public override void Configurar(Ramo entidad)
        {
            this.Tabla = "Ramos";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
        }

        public override void ConfigurarCamposValores(Ramo entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            if (entidad.Canal != null)
            {
                this.CamposValores.Add("comercio", entidad.Canal.Codigo);
            }
            else
            {
                this.CamposValores.Add("comercio", "");
            }
        }
    }
}
