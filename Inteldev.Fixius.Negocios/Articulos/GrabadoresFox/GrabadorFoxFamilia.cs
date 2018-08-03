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
    public class GrabadorFoxFamilia : GrabadorFox<Familia>
    {
        public GrabadorFoxFamilia(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(Familia entidad)
        {
            this.Tabla = "familia";
            this.ClavePrimaria = "codigo+sector+subsector+area";
            this.ValorClavePrimaria = string.Concat(entidad.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Subsector.Sector.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Subsector.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Subsector.Sector.Area.Codigo.Trim().PadLeft(2, '0'));
        }

        public override void ConfigurarCamposValores(Familia entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("area", entidad.Subsector.Sector.Area.Codigo);
            this.CamposValores.Add("sector", entidad.Subsector.Sector.Codigo);
            this.CamposValores.Add("subsector", entidad.Subsector.Codigo);
        }
    }
}
