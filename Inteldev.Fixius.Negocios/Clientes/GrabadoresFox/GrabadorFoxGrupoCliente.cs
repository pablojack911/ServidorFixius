using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.GrabadoresFox
{
    public class GrabadorFoxGrupoCliente : GrabadorFox<GrupoCliente>
    {
        public GrabadorFoxGrupoCliente(IDao dao)
            : base(dao)
        {

        }

        public override void Configurar(GrupoCliente entidad)
        {
            this.Tabla = "grupos";
            this.ClavePrimaria = "Codigo";
            this.ValorClavePrimaria = entidad.Codigo.Trim().PadLeft(3, '0');
        }

        public override void ConfigurarCamposValores(GrupoCliente entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("Nombre", entidad.Nombre);
            //this.CamposValores.Add("credito", entidad.Financieros);
        }
    }
}
