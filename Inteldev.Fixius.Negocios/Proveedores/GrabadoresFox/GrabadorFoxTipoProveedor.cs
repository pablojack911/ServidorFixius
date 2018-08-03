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
    public class GrabadorFoxTipoProveedor : GrabadorFox<TipoProveedor>
    {
        public GrabadorFoxTipoProveedor(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(TipoProveedor entidad)
        {
            this.Tabla = "tipoprov";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(3, '0');


        }

        public override void ConfigurarCamposValores(TipoProveedor entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
        }
    }
}
