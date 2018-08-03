using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Datos.Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    public class GrabadorFoxClienteDobleReal : IGrabadorFox<Cliente>
    {
        protected string usuario;
        public bool Borrar(Cliente entidad)
        {
            var grabadorPreventa = new GrabadorFoxCliente(new DaoFoxReal());
            grabadorPreventa.Usuario = usuario;

            var ok = grabadorPreventa.Borrar(entidad);

            var grabadorMayorista = new GrabadorFoxCliente(new DaoFoxRealMayorista());
            grabadorMayorista.Usuario = usuario;

            var ok2 = grabadorMayorista.Borrar(entidad);

            return ok && ok2;
        }

        public bool Grabar(Cliente entidad)
        {
            var grabadorPreventa = new GrabadorFoxCliente(new DaoFoxReal());
            grabadorPreventa.Usuario = usuario;

            var ok = grabadorPreventa.Grabar(entidad);

            var grabadorMayorista = new GrabadorFoxCliente(new DaoFoxRealMayorista());
            grabadorMayorista.Usuario = usuario;

            var ok2 = grabadorMayorista.Grabar(entidad);

            return ok && ok2;
        }


        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }
    }
}
