using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Logistica.GrabadoresFox
{
    public class GrabadorFoxZonaLogistica : GrabadorFox<ZonaLogistica>
    {
        public GrabadorFoxZonaLogistica(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(ZonaLogistica entidad)
        {
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(4, '0');
            this.Tabla = "zonas_logis";
        }

        public override void ConfigurarCamposValores(ZonaLogistica entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
        }
    }
}
