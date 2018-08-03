using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    /// <summary>
    /// Grabador Fox para RegionDeVenta
    /// </summary>
    public class GrabadorFoxRegionDeVenta : GrabadorFox<RegionDeVenta>
    {
        public GrabadorFoxRegionDeVenta(IDao Dao)
            : base(Dao)
        {

        }
        public override void Configurar(RegionDeVenta entidad)
        {
            this.Tabla = "regiones";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo;
        }

        public override void ConfigurarCamposValores(RegionDeVenta entidad)
        {
            this.SetearValores("codigo", entidad.Codigo, "");
            this.SetearValores("nombre", entidad.Nombre, "");
            this.SetearValores("georegion", entidad.GeoRegionDeVenta != null ? entidad.GeoRegionDeVenta.Codigo : string.Empty, "");
        }
    }
}
