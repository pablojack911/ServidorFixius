using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.GrabadoresFox
{
    public class GrabadorFoxTransportista : GrabadorFox<Transportista>
    {
        public GrabadorFoxTransportista(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(Transportista entidad)
        {
            this.Tabla = "Proveedo";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(5, '0');
        }

        public override void ConfigurarCamposValores(Transportista entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", (entidad.Nombre == null) ? string.Empty : entidad.Nombre);
        }
    }
}
