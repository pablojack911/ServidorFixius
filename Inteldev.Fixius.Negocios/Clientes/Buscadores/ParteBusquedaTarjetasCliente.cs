using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public class ParteBusquedaTarjetasCliente : ParteBusqueda<Cliente>
    {
        public ParteBusquedaTarjetasCliente()
            : base()
        {

        }

        public void Cargar(object Busqueda, string name)
        {
            this.Nombre = name;
            this.PuedeBuscar = (p => !string.IsNullOrEmpty(p.ToString()) && p.ToString().Length > 3);
            //this.SetearParteIzquierda(name);
            //this.SetearParteDerecha(Busqueda.ToString(), typeof(string));
            //this.JuntaExpressionIgual();
            //var lalala = 
            //this.JuntaExpressionEspecial(lalala);
            


            //ParameterOverride[] parameter = new ParameterOverride[2];
            //parameter[0] = new ParameterOverride("empresa", "01");
            //parameter[1] = new ParameterOverride("entidad", "cliente");
            //var buscador = (IBuscador<Cliente>)FabricaNegocios.Instancia.Resolver(typeof(IBuscador<Cliente>), parameter);
            //var consulta = buscador.ConsultaSimple(Core.CargarRelaciones.CargarCollecciones).Select(c => c.TarjetasCliente.Where(t => t.Codigo == Busqueda));
        }

        
    }
}
