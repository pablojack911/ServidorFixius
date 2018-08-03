using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Fixius.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios
{
    public class ValidadorBaseDatos
    {
        private ContextoGenerico contextoGenerico;
        private ContextoGenerico contextoExtra;

        public ValidadorBaseDatos(ContextoGenerico contextoExtra)
        {
            this.contextoExtra = contextoExtra;
            this.contextoGenerico = new ContextoGenerico(@"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico; Integrated Security=SSPI");
        }

        public bool validar<TEntidad>()
            where TEntidad : EntidadBase
        {
            int max1 = -1;
            int max2 = -1;
            try
            {
                max1 = this.contextoGenerico.Consultar<TEntidad>(Core.CargarRelaciones.NoCargarNada).Max(p => p.Id);
                max2 = this.contextoExtra.Consultar<TEntidad>(Core.CargarRelaciones.NoCargarNada).Max(p => p.Id);
                if (max1 == max2)
                    return true;
                else
                    return false;
            }
            catch (InvalidOperationException e)
            {
                if (max1 == -1 && max2 == -1)
                    return true;
                else
                    return false;
            }
        }

    }
}
