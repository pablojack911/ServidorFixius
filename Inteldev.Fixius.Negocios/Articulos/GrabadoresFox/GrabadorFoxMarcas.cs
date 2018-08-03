using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.GrabadoresFox
{
    public class GrabadorFoxMarcas : GrabadorFox<Marca>
    {

        public GrabadorFoxMarcas(IDao dao)
            : base(dao)
        {
        }
        public override void Configurar(Marca entidad)
        {
            this.Tabla = "marcas";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
        }

        public override void ConfigurarCamposValores(Marca entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
        }
    }
}
