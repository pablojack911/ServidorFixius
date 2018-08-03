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
    public class GrabadorFoxRubro : GrabadorFox<Rubro>
    {

        public GrabadorFoxRubro(IDao dao)
            : base(dao)
        {
        }
        public override void Configurar(Rubro entidad)
        {
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
            this.Tabla = "rubros";
        }

        public override void ConfigurarCamposValores(Rubro entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("condicio", entidad.CondicionDePago == null ? "" : entidad.CondicionDePago.Codigo);
            this.CamposValores.Add("preventa", entidad.NoIncluirEnListaDePrecios ? 1 : 0);
            this.CamposValores.Add("permiteconv", entidad.AdmiteConvenio ? 1 : 0);
            this.CamposValores.Add("dscto1", entidad.Acuerdo1);
            this.CamposValores.Add("dscto2", entidad.Acuerdo2);
            this.CamposValores.Add("dscto3", entidad.Acuerdo3);
            this.CamposValores.Add("dscto4", entidad.Acuerdo4);
        }
    }
}
