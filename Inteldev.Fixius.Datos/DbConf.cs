using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Datos
{
    public class DbConf : DbConfiguration
    {
        public DbConf()
        {
            //var sqlcf = new System.Data.Entity.Infrastructure.SqlConnectionFactory(@"Data Source=GABRIEL-PC\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico;User ID=damian;Password=123456");
            //var sqlcf = new System.Data.Entity.Infrastructure.SqlConnectionFactory(@"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico; Integrated Security=SSPI");
            //this.SetDefaultConnectionFactory(sqlcf);
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);           

        }
    }
}
