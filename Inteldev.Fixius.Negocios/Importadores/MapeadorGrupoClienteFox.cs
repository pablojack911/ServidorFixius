using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorGrupoClienteFox : MapeadorFox<GrupoCliente>
    {
        public MapeadorGrupoClienteFox(IDao con, string empresa, string entidad)
            : base("grupos", "codigo", con, empresa, entidad)
        {

        }

        protected override GrupoCliente Mapear(GrupoCliente entidad, System.Data.DataRow registro)
        {
            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Financieros = true;

            #region Clientes

            var drClientes = dao.EjecutarConsulta("select codigo from clientes where grupo='" + entidad.Codigo + "'");

            var listaClientes = new List<Cliente>();

            while (drClientes.Read())
            {
                var cli = this.BuscarEntidadPorCodigo<Cliente>(drClientes.GetString(0).Trim());
                if (cli != null)
                    listaClientes.Add(cli);
            }

            listaClientes.ForEach(c =>
            {
                if (!entidad.Clientes.Any(cli => cli.Codigo.Equals(c.Codigo))) //existe, por lo tanto no lo agrego.
                    entidad.Clientes.Add(c);//sino... adentro
            });

            List<Cliente> clientesBorrados = new List<Cliente>();
            entidad.Clientes.ToList().ForEach(cli =>
            {
                if (!listaClientes.Any(c => c.Codigo.Equals(cli.Codigo)))
                    clientesBorrados.Add(cli);
            });

            clientesBorrados.ForEach(cb => entidad.Clientes.Remove(cb));

            #endregion


            //entidad.Financieros = this.ObtenerBoolDeString(registro["credito"].ToString());

            drClientes.Close();
            drClientes.Dispose();
            //dao.Desconectar();

            return entidad;
        }
    }
}
