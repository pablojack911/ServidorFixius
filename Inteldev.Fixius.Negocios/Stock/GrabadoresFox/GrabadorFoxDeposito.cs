
using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Stock;
using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Stock.GrabadoresFox
{
    public class GrabadorFoxDeposito : GrabadorFox<Deposito>
    {
        public GrabadorFoxDeposito(IDao dao)
            : base(dao)
        {
        }
        public override void Configurar(Deposito entidad)
        {
            this.Tabla = "deposito";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(3, '0');


        }

        public override void ConfigurarCamposValores(Deposito entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
        }
    }
}
