using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Datos.Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.GrabadoresFox
{
    public class GrabadorFoxProveedoresDobleReal : IGrabadorFox<Proveedor>
    {
        protected string usuario;
        public bool Borrar(Proveedor entidad)
        {
            var grabadorPreventa = new GrabadorFoxProveedor(new DaoFoxReal());
            grabadorPreventa.Usuario = usuario;

            var ok = grabadorPreventa.Borrar(entidad);

            var grabadorMayorista = new GrabadorFoxProveedor(new DaoFoxRealMayorista());
            grabadorMayorista.Usuario = usuario;

            var ok2 = grabadorMayorista.Borrar(entidad);

            return ok && ok2;
        }

        public bool Grabar(Proveedor entidad)
        {
            var grabadorPreventa = new GrabadorFoxProveedor(new DaoFoxReal());
            grabadorPreventa.Usuario = usuario;

            var ok = grabadorPreventa.Grabar(entidad);

            var grabadorMayorista = new GrabadorFoxProveedor(new DaoFoxRealMayorista());
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
