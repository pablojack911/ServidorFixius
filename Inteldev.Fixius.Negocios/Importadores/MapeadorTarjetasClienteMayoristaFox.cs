using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorTarjetasClienteMayoristaFox : MapeadorFox<TarjetaClienteMayorista>
    {
        public MapeadorTarjetasClienteMayoristaFox(IDao con, string empresa, string entidad)
            : base("tarjclie", "select * from s://mayorista//datos//tarjclie where empty(heredade)", "codigo", con, empresa, entidad)
        {
        }

        protected override TarjetaClienteMayorista Mapear(TarjetaClienteMayorista entidad, System.Data.DataRow registro)
        {
            if (registro["codigo"].ToString().Trim() == "00")
            {
                entidad.Codigo = "NA";
            }
            else
            {
                entidad.Codigo = registro["codigo"].ToString().Trim();
            }
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Desde = registro["desde"].ToString().Trim();
            entidad.Hasta = registro["hasta"].ToString().Trim();
            entidad.Ramos.Clear();
            this.ImportarRamos(entidad);


            return entidad;
        }

        void ImportarRamos(TarjetaClienteMayorista tarjeta)
        {
            var dr = this.dao.EjecutarConsulta(string.Format("select * from s://mayorista//datos//ramos_tarje where tipo_tarje='{0}'", tarjeta.Codigo));

            while (dr.Read())
            {
                var codigoRamo = dr.GetString(1).Trim();
                var ramo = this.BuscarEntidadPorCodigo<Ramo>(codigoRamo);
                if (ramo != null)
                    tarjeta.Ramos.Add(ramo);
            }

            dr.Close();
            dr.Dispose();
            //this.dao.Desconectar();
        }

        //void ImportarRamos(TarjetaClienteMayorista tarjeta)
        //{
        //    var dr = dao.EjecutarConsulta(string.Format("select * from s://mayorista//datos//ramos_tarje where tipo_tarje='{0}'", tarjeta.Codigo));

        //    var listaRamos = new List<Ramo>();

        //    while (dr.Read())
        //    {
        //        var ram =this.BuscarEntidadPorCodigo<Ramo>(dr.GetString(1));
        //        if(tarjeta.Ramos.Any
        //        listaRamos.Add(tar);
        //    }

        //    listaRamos.ForEach(t =>
        //    {
        //        if (entidad.TarjetasCliente.Any(tar => tar.Codigo == t.Codigo)) //existe y actualizo la prop Habilitada.
        //            entidad.TarjetasCliente.FirstOrDefault(tar => tar.Codigo == t.Codigo).Habilitada = t.Habilitada;
        //        else
        //            entidad.TarjetasCliente.Add(t);
        //    });
        //    List<TarjetaMayoristaItem> tarjetasBorradas = new List<TarjetaMayoristaItem>();
        //    entidad.TarjetasCliente.ToList().ForEach(tar =>
        //            {
        //                if (!listaRamos.Any(t => t.Codigo == tar.Codigo))
        //                    tarjetasBorradas.Add(tar);
        //            });

        //    tarjetasBorradas.ForEach(tb => entidad.TarjetasCliente.Remove(tb));
        //}

    }
}
