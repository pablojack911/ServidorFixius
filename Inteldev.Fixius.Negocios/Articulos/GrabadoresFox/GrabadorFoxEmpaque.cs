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
    public class GrabadorFoxEmpaque : GrabadorFox<Empaque>
    {
        public GrabadorFoxEmpaque(IDao dao)
            : base(dao)
        {
        }

        public override void Configurar(Empaque entidad)
        {
            this.Tabla = "Empaque";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
        }

        public override void ConfigurarCamposValores(Empaque entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("litros", entidad.Contenido);
        }
    }
}
