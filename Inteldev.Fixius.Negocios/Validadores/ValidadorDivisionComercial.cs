using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Validadores
{
    public class ValidadorDivisionComercial : ValidadorGenerico<DivisionComercial>
    {

        public override bool isRepetido(DivisionComercial entidad, string empresa)
        {
            //if (entidad.Codigo == "")
            //{
            //    return false;
            //} //lo agregue 12.03.15 (funciona?) POCHO
            ParameterOverride[] parameter = new ParameterOverride[2];
            parameter[0] = new ParameterOverride("empresa", empresa);
            parameter[1] = new ParameterOverride("entidad", "divisioncomercial");
            var buscador = (IBuscador<DivisionComercial>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<DivisionComercial>), parameter);
            var divisiones = buscador.ConsultaSimple(Core.CargarRelaciones.CargarTodo).Where(p => p.Codigo == entidad.Codigo).ToList();
            if (divisiones == null || divisiones.Count() == 0)
            {
                return false;
            }
            else
            {
                foreach (var emp in entidad.Empresas)
                {
                    foreach (var div in divisiones)
                    {
                        var division = div.Empresas.FirstOrDefault(p => p.Codigo == emp.Codigo);
                        if (division != null)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
