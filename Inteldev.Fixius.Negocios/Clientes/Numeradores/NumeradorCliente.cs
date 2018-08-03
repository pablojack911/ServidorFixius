using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Numeradores
{
    public class NumeradorCliente : Numerador<Cliente>
    {

        public NumeradorCliente(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }
        public override string UltimoCodigo()
        {
            var ultimoCodigo = "ERROR";
            var daoFox = FabricaNegocios.Instancia.Resolver(typeof(IDao)) as IDao;
            IDataReader dr = null;
            if (daoFox.Connection.ConnectionString.Contains("release"))
            {
                dr = daoFox.EjecutarConsulta(@"SELECT nextid FROM s:\appvfp\mayorista\mayorista_release\datos\ids");
            }
            else
            {
                dr = daoFox.EjecutarConsulta(@"SELECT nextid FROM s:\mayorista\datos\ids");
            }
            if (dr != null && dr.Read())
                ultimoCodigo = dr[0].ToString();
            
            dr.Close();
            dr.Dispose();
            //daoFox.Desconectar();
            return ultimoCodigo;
        }
    }
}
