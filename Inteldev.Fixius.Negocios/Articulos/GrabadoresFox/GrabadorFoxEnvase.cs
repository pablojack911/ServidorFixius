using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.GrabadoresFox
{
    public class GrabadorFoxEnvase : GrabadorFox<Envase>
    {
        public GrabadorFoxEnvase(IDao dao)
            : base(dao)
        {

        }
        public override void Configurar(Envase entidad)
        {
            this.Tabla = "vacios";
            this.ClavePrimaria = "codigo";
            this.ValorClavePrimaria = entidad.Codigo;
        }

        public override void ConfigurarCamposValores(Envase entidad)
        {
            this.CamposValores.Add("codigo", entidad.Codigo);
            this.CamposValores.Add("nombre", entidad.Nombre);
            this.CamposValores.Add("cerveza", entidad.EsCerveza ? 1 : 0);
            if (entidad.Articulos.Count > 0)
                this.GrabarArticulosEnvase(entidad.Codigo, entidad.Articulos);
        }

        private void GrabarArticulosEnvase(string codigoEnvase, ICollection<ArticuloEnvase> articulos)
        {
            foreach (var art in articulos)
            {
                var cmdUpdate = this.Dao.CrearDbCommand();
                cmdUpdate.CommandText = string.Format("select codigo from vacio_art where articulo='{0}' and codigo='{1}'", art.Articulo.Codigo, codigoEnvase);
                cmdUpdate.CommandType = System.Data.CommandType.Text;

                var rows = cmdUpdate.ExecuteNonQuery();
                if (rows == 0)
                {
                    this.Dao.EjecutarComando(string.Format("insert into vacio_art (codigo,articulo,unidades,valor,cargaporfrac) values ('{0}','{1}',{2},{3},{4})", codigoEnvase, art.Articulo.Codigo, art.Cantidad, art.PrecioUnitario.ToString().Replace(',', '.'), art.Fraccion ? ".T." : ".F."));
                }
                else
                {
                    this.Dao.EjecutarComando(string.Format("update vacio_art set unidades={0},valor={1},cargaporfrac={2} where codigo='{3}' and articulo = '{4}'", art.Cantidad, art.PrecioUnitario.ToString().Replace(',', '.'), art.Fraccion ? ".T." : ".F.", codigoEnvase, art.Articulo.Codigo));
                }
            }

            var dr = this.Dao.EjecutarConsulta(string.Format("select articulo from vacio_art where codigo='{0}'", codigoEnvase));

            while (dr.Read())
            {
                var codArt = dr.GetString(0).Trim();
                if (!articulos.Any(p => p.Articulo.Codigo == codArt))
                {
                    this.Dao.EjecutarComando(string.Format("delete from vacio_art WHERE articulo='{0}' AND codigo='{1}'", codArt, codigoEnvase));
                }
            }
            dr.Close();
            dr.Dispose();
            //this.Dao.Desconectar();
        }
    }
}
