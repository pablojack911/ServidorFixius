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
    public class GrabadorFoxCanal : GrabadorFox<Canal>
    {
        public GrabadorFoxCanal(IDao dao)
            : base(dao)
        { }

        public override void Configurar(Canal entidad)
        {
            this.Tabla = "Ramos";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
        }

        public override void ConfigurarCamposValores(Canal entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            this.CamposValores.Add("principal", 1);
        }
    }
}
