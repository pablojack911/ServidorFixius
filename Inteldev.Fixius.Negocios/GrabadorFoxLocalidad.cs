using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;

namespace Inteldev.Fixius.Negocios
{
    public class GrabadorFoxLocalidad : GrabadorFox<Localidad>
    {
        public GrabadorFoxLocalidad(IDao dao)
            : base(dao)
        {
        }

        public override void Configurar(Localidad entidad)
        {
            this.Tabla = "localida";
            this.ClavePrimaria = "copostal";
            this.ValorClavePrimaria = entidad.Codigo.PadLeft(4, '0');
        }

        public override void ConfigurarCamposValores(Localidad entidad)
        {
            this.SetearValores("copostal", entidad.Codigo, "");
            this.SetearValores("nombre", entidad.Nombre, "");
            //this.SetearValores("local", 0, "");
            //this.SetearValores("imp_flet", Decimal.Zero, "");
            //this.SetearValores("modi", false, false);
        }
    }
}
