using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inteldev.Core.Datos;

namespace Inteldev.Fixius.Negocios.Usuarios
{
    public class CreadorUsuario:Inteldev.Core.Negocios.CreadorGenerico<Inteldev.Core.Modelo.Usuarios.Usuario>
    {
        public CreadorUsuario(string empresa, string entidad)
            : base(empresa,entidad)
        {
        }
        protected override void CargarDatos(Core.Modelo.Usuarios.Usuario Entidad)
        {
        }
    }
}
