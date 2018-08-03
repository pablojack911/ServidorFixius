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
    public class GrabadorFoxCobrador : GrabadorFox<Cobrador>
    {
        public GrabadorFoxCobrador(IDao con)
            : base(con)
        {

        }
        public override void Configurar(Cobrador entidad)
        {
            this.Tabla = "operator";
            this.ClavePrimaria = "Codigo+trans(cargo)";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(2, '0'), "2");
        }

        public override void ConfigurarCamposValores(Cobrador entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            this.CamposValores.Add("cargo", 2);
            if (entidad.DatosOldPreventa != null)
            {
                this.CamposValores.Add("essupervisor", entidad.DatosOldPreventa.EsSupervisor);
                this.CamposValores.Add("inactivo", entidad.DatosOldPreventa.Inactivo);
            }
        }
    }
}
