using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Clientes;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Validadores
{
    public class ValidadorRutaDeVenta : ValidadorGenerico<Modelo.Clientes.RutaDeVenta>
    {

        public override bool isRepetido(Modelo.Clientes.RutaDeVenta entidad, string empresa)
        {
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "rutadeventa");
            var buscador = (IBuscador<RutaDeVenta>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<RutaDeVenta>), parameter);
            var rutasDeVenta = buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo).Where(p => p.Codigo == entidad.Codigo).ToList();

            if (rutasDeVenta != null || rutasDeVenta.Count != 0)
            {
                //tengo que comprobar en empresa, division comercial, codigo
                if (rutasDeVenta.Any(p => p.Empresa == entidad.Empresa && p.Division == entidad.Division))
                    //(rutasDeVetenta.FirstOrDefault(p => p.Empresa == entidad.Empresa) != null) && 
                    //(rutasDeVetenta.FirstOrDefault(p => p.Division.Id == entidad.Division.Id) != null)
                    //)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public override bool codigoIsNull(RutaDeVenta entidad)
        {
            if (entidad.Codigo == null || entidad.Codigo == string.Empty)
                return true;
            return false;
        }

        public override bool divisionIsNull(RutaDeVenta entidad)
        {
            if (entidad.Division == null)
                return true;
            return false;
        }

        public override bool empresaIsNull(RutaDeVenta entidad)
        {
            if (entidad.Empresa == null || entidad.Empresa == string.Empty)
                return true;
            return false;
        }
    }
}

