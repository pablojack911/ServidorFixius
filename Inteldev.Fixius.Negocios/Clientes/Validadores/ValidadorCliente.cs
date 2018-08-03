using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Negocios.Validadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Validadores
{
    public class ValidadorCliente : ValidadorGenerico<Cliente>
    {
        //public override bool isRepetido(Cliente entidad, string empresa)
        //{
        //    ParameterOverride[] parameter = new ParameterOverride[2];
        //    parameter[0] = new ParameterOverride("empresa", empresa);
        //    parameter[1] = new ParameterOverride("entidad", "cliente");
        //    var buscador = (IBuscador<Cliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Cliente>), parameter);
        //    return buscador.ConsultaSimple(Core.CargarRelaciones.NoCargarNada).Any(c => c.NumeroDocumentoCliente == entidad.NumeroDocumentoCliente);
        //}


        //public override bool RamoNoCoincideConTarjetaHabilitada(Cliente entidad, string empresa)
        //{
        //    bool coincide = false;
        //    if (entidad.Ramo != null)
        //        if (entidad.TarjetasCliente.Count > 0)
        //        {
        //            var ramocodigo = entidad.Ramo.Codigo;

        //            var tarjetaHabilitada = entidad.TarjetasCliente.FirstOrDefault(t => t.Habilitada == true).TipoTarjeta;
        //            if (tarjetaHabilitada != null)
        //            {
        //                var paramers = new ParameterOverride[2];
        //                paramers[0] = new ParameterOverride("empresa", empresa);
        //                paramers[1] = new ParameterOverride("entidad", "Ramo");
        //                var buscadorRamos = (IBuscador<Fixius.Modelo.Clientes.Ramo>)FabricaNegocios.Instancia.Resolver(typeof(BuscadorGenerico<Fixius.Modelo.Clientes.Ramo>), paramers);
        //                if (buscadorRamos != null)
        //                {
        //                    var ramosDeTarjeta = buscadorRamos.ConsultaSimple(Core.CargarRelaciones.CargarTodo).Where(r => r.Tarjeta.Codigo == tarjetaHabilitada.Codigo).ToList();
        //                    coincide = ramosDeTarjeta.Any(p => p.Codigo == ramocodigo);
        //                }
        //            }
        //        }
        //        else
        //            coincide = true;
        //    return coincide;
        //}
    }
}
