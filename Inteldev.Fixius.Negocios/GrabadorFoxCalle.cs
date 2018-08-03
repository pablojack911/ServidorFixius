using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class GrabadorFoxCalle : GrabadorFox<Calle>
    {
        public GrabadorFoxCalle(IDao dao)
            : base(dao) { }

        public override void Configurar(Calle entidad)
        {
            this.Tabla = "streets";
            this.ClavePrimaria = "street";
            this.ValorClavePrimaria = entidad.Nombre;

        }

        public override void ConfigurarCamposValores(Calle entidad)
        {
            CamposValores.Add("street", entidad.Nombre);
        }
    }
}
