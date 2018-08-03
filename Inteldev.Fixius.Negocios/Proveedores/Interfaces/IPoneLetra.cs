using System;
namespace Inteldev.Fixius.Negocios.Proveedores.Interfaces
{
    public interface IPoneLetra
    {
        ItemLetra ItemLetra { get; set; }
        string ObtenerLetra(ItemLetra condicion);
    }
}
