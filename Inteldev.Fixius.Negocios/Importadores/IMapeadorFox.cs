using Inteldev.Core.Modelo;
using Microsoft.Practices.Unity;
using System;
using System.Data;
namespace Inteldev.Fixius.Negocios.Importadores
{
    public interface IMapeadorFox<TEntidad>
     where TEntidad : Inteldev.Core.Modelo.EntidadMaestro, new()
    {
        ParameterOverride[] paramers { get; set; }
        object Procesar();        

        bool CompararParaBorrar(EntidadMaestro entidad);

        int ItemsPorLote { get; set; }


    }
}
