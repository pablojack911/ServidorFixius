using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Preventa.GrabadoresFox
{
    public class GrabadorFoxPreventista : GrabadorFox<Preventista>
    {
        public GrabadorFoxPreventista(IDao con)
            : base(con)
        {

        }
        public override void Configurar(Preventista entidad)
        {
            this.Tabla = "operator";
            this.ClavePrimaria = "Codigo+trans(cargo)";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(2, '0'), "1");
        }

        public override void ConfigurarCamposValores(Preventista entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            this.CamposValores.Add("cargo", 1);
            this.SetearValores("user", entidad.Usuario, string.Empty);
            this.SetearValores("pass", entidad.Password, string.Empty);
            this.SetearValores("foto", entidad.Foto, string.Empty);

            if (entidad.DatosOldPreventa != null)
            {
                this.CamposValores.Add("essupervisor", entidad.DatosOldPreventa.EsSupervisor ? 1 : 0);
                this.CamposValores.Add("inactivo", entidad.DatosOldPreventa.Inactivo ? 1 : 0);
            }
        }
    }
}
