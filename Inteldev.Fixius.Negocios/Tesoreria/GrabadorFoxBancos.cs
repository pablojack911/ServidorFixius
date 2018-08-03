using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Tesoreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Tesoreria
{

    public class GrabadorFoxBancos : GrabadorFox<Banco>
    {
        public GrabadorFoxBancos(IDao dao)
            : base(dao)
        { }

        public override void Configurar(Banco entidad)
        {
            this.Tabla = "Bancos";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(3, '0');


        }

        public override void ConfigurarCamposValores(Banco entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
        }
    }
}
