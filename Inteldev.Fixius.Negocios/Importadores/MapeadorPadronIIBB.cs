using Inteldev.Core.Datos;
using Inteldev.Fixius.Modelo.Fiscal;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorPadronIIBB : IMapeadorFox<PadronIIBB>
    {
        public MapeadorPadronIIBB(IDao con, String empresa, string entidad)
        {
            this.dao = con;
            this.TablaDestino = "PadronIIBBs";
            this.paramers = new ParameterOverride[] { new ParameterOverride("empresa", empresa), new ParameterOverride("entidad", entidad) };
            mapeos = new List<string[]>();
            this.AddMapeo("fecha_pub", "FechaPublicacion");
            this.AddMapeo("fecha_desde", "FechaDesde");
            this.AddMapeo("fecha_hasta", "FechaHasta");
            this.AddMapeo("cuit", "CUIT");
            this.AddMapeo("tipo", "Tipo");
            this.AddMapeo("estado", "Estado");
            this.AddMapeo("cambio_alicuota", "CambioAliCuota");
            this.AddMapeo("percepcion", "Percepcion");
            this.AddMapeo("retencion", "Retencion");
            this.AddMapeo("grupo_percepcion", "GrupoPercepcion");
            this.AddMapeo("grupo_retencion", "GrupoRetencion");
        }
        IDao dao;

        public Microsoft.Practices.Unity.ParameterOverride[] paramers { get; set; }

        public object Procesar()
        {
            var Reader = this.dao.EjecutarConsulta("select * from s://preventa//datos//padron order by cuit where !empty(cuit)");
            //this.dao.Desconectar();
            return Reader;
        }

        public bool CompararParaBorrar(Core.Modelo.EntidadMaestro entidad)
        {
            throw new NotImplementedException();
        }
        List<string[]> mapeos;

        public string TablaDestino;
        public dynamic mapeo()
        {

            return mapeos;
        }

        void AddMapeo(string origen, string destino)
        {
            this.mapeos.Add(new string[] { origen, destino });
        }


        public int ItemsPorLote
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
