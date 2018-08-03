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
    public class GrabadorFoxVendedor : GrabadorFox<Vendedor>
    {
        public GrabadorFoxVendedor(IDao con)
            : base(con)
        {

        }
        public override void Configurar(Vendedor entidad)
        {
            this.Tabla = "operator";
            this.ClavePrimaria = "Codigo+trans(cargo)";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(2, '0'), "5");
        }

        public override void ConfigurarCamposValores(Vendedor entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            this.CamposValores.Add("cargo", 5);
            //this.CamposValores.Add("user", entidad.Usuario);
            //this.CamposValores.Add("pass", entidad.Password);
            //this.CamposValores.Add("foto", entidad.Foto);
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
