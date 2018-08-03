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
    public class GrabadorFoxRutaDeVenta : GrabadorFox<RutaDeVenta>
    {
        public GrabadorFoxRutaDeVenta(IDao dao)
            : base(dao)
        {
        }

        public override void Configurar(RutaDeVenta entidad)
        {
            this.Tabla = "zonas";
            this.ClavePrimaria = "empresa_rel+empresa+codigo";
            this.ValorClavePrimaria = string.Concat(entidad.Empresa, entidad.Division, entidad.Codigo.Trim().PadLeft(4, '0'));
        }

        public override void ConfigurarCamposValores(RutaDeVenta entidad)
        {
            this.SetearValores("codigo", entidad.Codigo, "");
            this.SetearValores("nombre", entidad.Nombre, "");
            this.SetearValores("empresa_rel", entidad.Empresa, "");
            this.SetearValores("empresa", (entidad.Division) == null ? string.Empty : entidad.Division, "");
            this.SetearValores("operator", (entidad.Titular) == null ? string.Empty : entidad.Titular.Codigo, "");
            this.SetearValores("operator2", (entidad.Suplente) == null ? string.Empty : entidad.Suplente.Codigo, "");
            this.SetearValores("region", (entidad.RegionDeVenta) == null ? string.Empty : entidad.RegionDeVenta.Codigo, "");

            if (entidad.DatosOld != null)
            {
                this.SetearValores("nofacturar", entidad.DatosOld.NoFacturar == true ? 1 : 0, 0);
                this.SetearValores("recargo", entidad.DatosOld.RecargoPorLogistica == true ? 1 : 0, 0);

                var aceptaped = 0;
                switch (entidad.DatosOld.AceptaPedidos)
                {
                    case AceptaPedidos.DiferidosYUrgentes: aceptaped = 1;
                        break;
                    case AceptaPedidos.Diferidos: aceptaped = 2;
                        break;
                    case AceptaPedidos.DiferidosSegunCronograma: aceptaped = 3;
                        break;
                    default: aceptaped = 0;
                        break;
                }
                this.SetearValores("aceptaped", aceptaped, 0);
            }

            if (entidad.Clientes != null && entidad.Clientes.Count > 0)
            {
                this.GrabarClientes(entidad.Clientes, entidad.Codigo, entidad.Division, entidad.Empresa);
            }

            this.GrabarCronograma(entidad.Codigo, entidad.Empresa, entidad.Division, entidad.DiasDeEntrega, entidad.DiasDeVisita, entidad.Diferidos, entidad.NoValidarCronograma);

            this.SetearValores("activada", entidad.Activada == true ? 1 : 0, 0);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zona">RutaDeVenta</param>
        /// <param name="empresa">Empresa</param>
        /// <param name="division">Division - Nombre de campo en FOX: prov</param>
        /// <param name="DiasDeEntrega">DiasDeEntrega</param>
        /// <param name="DiasDeVisita">DiasDeVisita</param>
        /// <param name="Diferidos">Diferidos</param>
        private void GrabarCronograma(string zona, string empresa, string division, DiasDeSemana DiasDeEntrega, DiasDeSemana DiasDeVisita, DiasDeSemana Diferidos, bool NoValidarCronograma)
        {
            var entrega = string.Empty;
            var pedido = string.Empty;
            var diferido = string.Empty;

            if (DiasDeEntrega != null)
            {
                entrega = this.GenerarCadena(DiasDeEntrega);
            }

            if (DiasDeVisita != null)
            {
                pedido = this.GenerarCadena(DiasDeVisita);
            }

            if (Diferidos != null)
            {
                diferido = this.GenerarCadena(Diferidos);
            }
            //insertar
            var cmdUpdate = this.Dao.CrearDbCommand();
            cmdUpdate.CommandText = string.Format(@"select zona from cron_ped where zona='{0}' and empresa='{1}' and prov='{2}'", zona, empresa, division);
            cmdUpdate.CommandType = System.Data.CommandType.Text;

            var rows = cmdUpdate.ExecuteNonQuery();
            if (rows == 0)
            {
                //insertar
                this.Dao.EjecutarComando(string.Format(@"INSERT INTO cron_ped (zona,empresa,prov,pedido,entrega,diferido,novalida) values ('{0}','{1}','{2}','{3}','{4}','{5}',{6})", zona, empresa, division, pedido, entrega, diferido, NoValidarCronograma == true ? 1 : 0));
            }
            else
            {
                //actualizar
                this.Dao.EjecutarComando(string.Format("UPDATE cron_ped SET pedido='{3}', entrega='{4}', diferido='{5}', novalida={6} WHERE zona='{0}' AND empresa='{1}' AND prov='{2}'", zona, empresa, division, pedido, entrega, diferido, NoValidarCronograma == true ? 1 : 0));
            }
            //this.Dao.Desconectar();
        }

        private string GenerarCadena(DiasDeSemana diasDeSemana)
        {
            var dias = string.Empty;
            if (diasDeSemana.Lunes)
                dias += "LU";
            if (diasDeSemana.Martes)
                if (dias == string.Empty)
                    dias += "MA";
                else
                    dias += "-MA";
            if (diasDeSemana.Miercoles)
                if (dias == string.Empty)
                    dias += "MI";
                else
                    dias += "-MI";
            if (diasDeSemana.Jueves)
                if (dias == string.Empty)
                    dias += "JU";
                else
                    dias += "-JU";
            if (diasDeSemana.Viernes)
                if (dias == string.Empty)
                    dias += "VI";
                else
                    dias += "-VI";
            if (diasDeSemana.Sabado)
                if (dias == string.Empty)
                    dias += "SA";
                else
                    dias += "-SA";
            return dias;
        }

        private void GrabarClientes(ICollection<Cliente> Clientes, string codigoRuta, string division, string empresa)
        {
            foreach (var cliente in Clientes)
            {
                var cmdUpdate = this.Dao.CrearDbCommand();
                cmdUpdate.CommandText = string.Format(@"select cliente from config_zona where cliente='{0}' and zona='{1}' and empresa='{2}' and subempresa='{3}'", cliente.Codigo, codigoRuta, empresa, division);
                cmdUpdate.CommandType = System.Data.CommandType.Text;

                var rows = cmdUpdate.ExecuteNonQuery();
                if (rows == 0)
                {
                    this.Dao.EjecutarComando(string.Format(@"INSERT INTO config_zona (zona,empresa,subempresa,cliente,baja) values ('{0}','{1}','{2}','{3}',{4})", codigoRuta, empresa, division, cliente.Codigo, 0));
                }
            }

            var dr = this.Dao.EjecutarConsulta(string.Format(@"select cliente from config_zona where zona='{0}' and empresa='{1}' and subempresa='{2}'", codigoRuta, empresa, division));
            while (dr.Read())
            {
                var cli = dr.GetString(0);
                int baja = 1;
                if (Clientes.Any(p => p.Codigo == cli))
                {
                    baja = 0;
                }
                this.Dao.EjecutarComando(string.Format("UPDATE config_zona SET baja={4} WHERE zona='{0}' AND empresa='{1}' AND subempresa='{2}' and cliente='{3}'", codigoRuta, empresa, division, cli, baja));
            }
            dr.Close();
            dr.Dispose();
            //this.Dao.Desconectar();
        }
    }

}
