using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Datos;
using System.Data;
using Inteldev.Datos.Dao;
using System.Data.OleDb;

namespace Inteldev.Fixius.Datos
{
    public class DaoFox : Dao, Core.Datos.IDao
    {

        //base("Provider=VFPOLEDB.1 ;Data Source=////192.168.1.100//work//AppVfp//INTELDEV//Hergo_release//datos//truesoft.dbc")
        public DaoFox(string stringconnection)
            : base(new OleDbConnection(stringconnection))
        //: base("Provider=VFPOLEDB.1 ;Data Source=////server//work//preventa//datos//truesoft.dbc")
        //: base("Provider=VFPOLEDB.1 ;Data Source=////server//work1//AppVfp//INTELDEV//appvfp//Hergo_release//datos//truesoft.dbc")        
        {
            EjecutarComando("set null off");
            EjecutarComando("SET DELETED ON");
        }
        public IDbConnection Connection
        {
            get
            {
                return this.DbConnection;
            }
            set
            {
                Connection = value;
            }
        }

        public override void Conectar()
        {

            if (base.DbConnection.State != ConnectionState.Open)
            {
                this.Connection.Open();
                EjecutarComando("SET NULL OFF");
                EjecutarComando("SET DELETED ON");
                EjecutarComando("SET ENGINEBEHAVIOR 70");
            }
        }

    }
}
