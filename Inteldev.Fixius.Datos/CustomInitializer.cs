


//using Inteldev.Fixius.Datos.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Datos
{
    public class CustomInitializer : IDatabaseInitializer<ContextoGenerico>
    {

        void IDatabaseInitializer<ContextoGenerico>.InitializeDatabase(ContextoGenerico context)
        {
            //Configuration cfg = new Configuration(); // migration configuration class
            //cfg.TargetDatabase =

            //   new DbConnectionInfo(

            //      context.Database.Connection.ConnectionString,

            //      "System.Data.SqlClient");



            //DbMigrator dbMigrator = new DbMigrator(cfg);

            //// this will call the parameterless constructor of the datacontext

            //// but the connection string from above will be then set on in

            //dbMigrator.Update();
        }
    }
}
