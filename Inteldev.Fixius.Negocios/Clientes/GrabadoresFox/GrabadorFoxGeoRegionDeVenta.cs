using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    /// <summary>
    /// Grabador Fox para GeoRegionDeVenta
    /// </summary>
    public class GrabadorFoxGeoRegionDeVenta : GrabadorFox<GeoRegionDeVenta>
    {
        public GrabadorFoxGeoRegionDeVenta(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(GeoRegionDeVenta entidad)
        {
            this.Tabla = "regiones";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo;
        }

        public override void ConfigurarCamposValores(GeoRegionDeVenta entidad)
        {
            this.SetearValores("codigo", entidad.Codigo, "");
            this.SetearValores("nombre", entidad.Nombre, "");
        }
    }
}
