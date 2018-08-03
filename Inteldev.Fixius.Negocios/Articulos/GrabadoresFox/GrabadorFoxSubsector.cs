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
    public class GrabadorFoxSubsector : GrabadorFox<Subsector>
    {
        public GrabadorFoxSubsector(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(Subsector entidad)
        {
            this.Tabla = "subsector";
            this.ClavePrimaria = "area+sector+codigo";
            this.ValorClavePrimaria = string.Concat(entidad.Sector.Area.Codigo.Trim().PadLeft(2, '0'),
                                                    entidad.Sector.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Codigo.Trim().PadLeft(3, '0'));
        }

        public override void ConfigurarCamposValores(Subsector entidad)
        {
            this.CamposValores.Add("area", entidad.Sector.Area.Codigo);
            this.CamposValores.Add("sector", entidad.Sector.Codigo);
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
        }
    }
}
