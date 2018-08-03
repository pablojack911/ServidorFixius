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
    public class GrabadorFoxSubfamilia : GrabadorFox<Subfamilia>
    {
        public GrabadorFoxSubfamilia(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(Subfamilia entidad)
        {
            this.Tabla = "subfamilia";
            this.ClavePrimaria = "sector+codigo+familia+subsector+area";
            this.ValorClavePrimaria = string.Concat(entidad.Familia.Subsector.Sector.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Familia.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Familia.Subsector.Codigo.Trim().PadLeft(3, '0'),
                                                    entidad.Familia.Subsector.Sector.Area.Codigo.Trim().PadLeft(2, '0'));
        }

        public override void ConfigurarCamposValores(Subfamilia entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("area", entidad.Familia.Subsector.Sector.Area.Codigo);
            this.CamposValores.Add("sector", entidad.Familia.Subsector.Sector.Codigo);
            this.CamposValores.Add("subsector", entidad.Familia.Subsector.Codigo);
            this.CamposValores.Add("familia", entidad.Familia.Codigo);
        }
    }
}
