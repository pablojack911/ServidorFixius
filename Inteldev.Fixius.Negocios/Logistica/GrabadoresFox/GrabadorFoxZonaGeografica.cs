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
    public class GrabadorFoxZonaGeografica : GrabadorFox<ZonaGeografica>
    {
        public GrabadorFoxZonaGeografica(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(ZonaGeografica entidad)
        {
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(4, '0');
            this.Tabla = "zonas";
        }

        public override void ConfigurarCamposValores(ZonaGeografica entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
        }
    }
}
