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
    public class GrabadorFoxSector : GrabadorFox<Sector>
    {
        public GrabadorFoxSector(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(Sector entidad)
        {
            this.Tabla = "sector";
            this.ClavePrimaria = "codigo+area";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(3, '0'), entidad.Area.Codigo.Trim().PadLeft(2, '0'));
        }

        public override void ConfigurarCamposValores(Sector entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("area", entidad.Area.Codigo);
        }
    }
}
