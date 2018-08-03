using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Datos;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace Inteldev.Fixius.Negocios
{
    public abstract class MapeadorFox<TEntidad> : Inteldev.Fixius.Negocios.Importadores.IMapeadorFox<TEntidad> where TEntidad : EntidadMaestro, new()
    {
        //protected IDao dao;
        public IDao dao { get; set; }

        string clave;
        string tabla;
        protected string consulta;
        List<TEntidad> entidades;
        DataSet datos;
        OleDbDataAdapter adaptador;
        int _itemsPorLote = 100;

        public int ItemsPorLote
        {
            get { return _itemsPorLote; }
            set { _itemsPorLote = value; }
        }


        public ParameterOverride[] paramers { get; set; }
        public Dictionary<object, object> Buscadores { get; set; }

        public MapeadorFox(string empresa, string entidad)
        {
            this.paramers = new ParameterOverride[2];
            this.paramers[0] = new ParameterOverride("empresa", empresa);
            this.paramers[1] = new ParameterOverride("entidad", entidad);
        }

        public MapeadorFox(string tabla, string consulta, string clave, IDao dao, string empresa, string entidad)
        {
            this.paramers = new ParameterOverride[2];
            this.paramers[0] = new ParameterOverride("empresa", empresa);
            this.paramers[1] = new ParameterOverride("entidad", entidad);
            this.Inicializador(tabla, consulta, clave, dao);
        }
        public MapeadorFox(string tabla, string clave, IDao dao, string empresa, string entidad)
        {
            this.paramers = new ParameterOverride[2];
            this.paramers[0] = new ParameterOverride("empresa", empresa);
            this.paramers[1] = new ParameterOverride("entidad", entidad);
            string consulta = string.Format("select * from {0}", tabla);

            this.Inicializador(tabla, consulta, clave, dao);
        }

        protected void Inicializador(string tabla, string consulta, string clave, IDao dao)
        {
            this.dao = dao;
            this.tabla = tabla;
            this.consulta = consulta;
            this.clave = clave;
            this.entidades = new List<TEntidad>();
            this.datos = new DataSet();
            this.adaptador = new OleDbDataAdapter(this.consulta, dao.Connection as OleDbConnection);
            this.Buscadores = new Dictionary<object, object>();
        }

        private TBuscador ObtenerBuscador<TBuscador>()
        {
            object buscador = Buscadores.FirstOrDefault(p => p.Key.Equals(typeof(TBuscador))).Value;

            if (buscador == null)
            {
                buscador = FabricaNegocios.Instancia.Resolver(typeof(TBuscador), paramers);
                this.Buscadores.Add(typeof(TBuscador), buscador);
            }

            return (TBuscador)buscador;
        }

        protected int? BuscarIdPorCodigo<TEntidadRelacionada>(string codigo) where TEntidadRelacionada : EntidadMaestro
        {
            var buscador = ObtenerBuscador<IBuscador<TEntidadRelacionada>>();
            //buscador.CargarEntidadesRelacionadas = Core.CargarRelaciones.NoCargarNada;
            var entidad = buscador.BuscarPorCodigo<TEntidadRelacionada>(codigo);
            if (entidad == null)
                return null;
            else
                return entidad.Id;
        }

        protected TEntidadRelacionada BuscarEntidadPorCodigo<TEntidadRelacionada>(string codigo) where TEntidadRelacionada : EntidadMaestro
        {
            var buscador = ObtenerBuscador<IBuscador<TEntidadRelacionada>>();
            var cacheEstado = buscador.CargarEntidadesRelacionadas;
            buscador.CargarEntidadesRelacionadas = Core.CargarRelaciones.NoCargarNada;
            Debug.WriteLine("Hash del buscador :" + buscador.GetHashCode());
            var entidad = buscador.BuscarPorCodigo<TEntidadRelacionada>(codigo);
            buscador.CargarEntidadesRelacionadas = cacheEstado;
            if (entidad == null)
                return null;
            else
                return entidad;
        }


        protected TEntidadRelacionada BuscarEntidadPorNombre<TEntidadRelacionada>(string nombre) where TEntidadRelacionada : EntidadMaestro
        {
            var buscador = ObtenerBuscador<IBuscador<TEntidadRelacionada>>();
            //buscador.CargarEntidadesRelacionadas = Core.CargarRelaciones.NoCargarNada;
            var entidad = buscador.ConsultaSimple(Core.CargarRelaciones.NoCargarNada).Where(p => p.Nombre == nombre).FirstOrDefault();
            if (entidad == null)
                return null;
            else
                return entidad;
        }

        private void CargarDatos()
        {
            this.datos = new DataSet();
            this.adaptador.Fill(this.datos, this.tabla);
        }

        protected abstract TEntidad Mapear(TEntidad entidad, DataRow registro);


        public object Procesar()
        {
            this.dao.Conectar();
            this.CargarDatos();
            this.entidades = new List<TEntidad>();
            LogManager.Instancia.AgregarMensaje("Importando " + typeof(TEntidad).ToString());
            LogManager.Instancia.AgregarMensaje(string.Format("Consulta a FOX trajo {0} registros.", this.datos.Tables[0].Rows.Count));
            LogManager.Instancia.AgregarMensaje("Comienzando la incorporacion.");

            foreach (DataRow item in this.datos.Tables[0].Rows)
            {
                var entidad = this.Mapear(this.ObtenerEntidad(item), item);
                LogManager.Instancia.AgregarMensaje(string.Format("- Recibiendo a '{0}'. ", entidad.Nombre));
                this.entidades.Add(entidad);
            }
            //LogManager.Instancia.AgregarMensaje(string.Format("Total de datos leídos de {0} = {1}.", entidades.GetType().GetGenericArguments().FirstOrDefault().ToString(), counter));
            dao.Desconectar();
            return this.entidades;
        }

        protected virtual TEntidad ObtenerEntidad(DataRow item)
        {
            var clave = item[this.clave].ToString();
            return this.ObtenerEntidad(clave);
        }
        private TEntidad ObtenerEntidad(string codigo)
        {
            var buscador = this.ObtenerBuscador<IBuscador<TEntidad>>();
            //buscador.CargarEntidadesRelacionadas = Core.CargarRelaciones.NoCargarNada; //recomentado 2015.01.28 por ruta de venta
            TEntidad entidad = buscador.BuscarPorCodigo<TEntidad>(codigo);

            buscador = null;
            if (entidad == null)
            {
                entidad = this.CrearNueva();
            }
            return entidad;
        }


        protected TEntidad ObtenerEntidad(Func<TEntidad, bool> where)
        {
            var buscador = this.ObtenerBuscador<IBuscador<TEntidad>>();

            TEntidad entidad = buscador.ConsultaSimple(Core.CargarRelaciones.CargarEntidades).FirstOrDefault(where);
            buscador = null;
            if (entidad == null)
            {
                entidad = this.CrearNueva();
            }
            return entidad;
        }

        protected TEntidad CrearNueva()
        {
            var creador = (ICreador<TEntidad>)FabricaNegocios.Instancia.Resolver(typeof(ICreador<TEntidad>), this.paramers);
            var entidad = creador.Crear();
            creador = null;
            return entidad;
        }
        public bool ObtenerBoolDeString(String valorString)
        {
            bool valorBoolean = false;
            if (valorString == "1")
            {
                valorBoolean = true;
            }

            return valorBoolean;
        }

        public virtual bool CompararParaBorrar(EntidadMaestro entidad)
        {
            return true;
        }

        public virtual string[] ObtenerFiltroBorrador(EntidadMaestro entidad)
        {
            return new string[] { entidad.Codigo };
        }
    }
}
