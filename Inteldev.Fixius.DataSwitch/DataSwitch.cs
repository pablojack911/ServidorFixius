using EntityFramework.Extensions;
using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.DataSwitch
{
    /// <summary>
    /// Encargada de seleccionar la base de datos dependiendo de la configuración de empresa-entidad. 
    /// </summary>
    /// <typeparam name="TEntidad">Entidad, tiene que derivar de entidadbase</typeparam>
    public class DataSwitch<TEntidad> : Inteldev.Core.DataSwitch.IDataSwitch<TEntidad>
        where TEntidad : EntidadBase
    {
        private class transaccion
        {
            public IDbContext Contexto { get; set; }
            public int Id { get; set; }
            public DbContextTransaction Transaccion { get; set; }
        }

        private List<transaccion> transacciones;
        private List<IDbContext> contextos;
        private IDbContext contextoInicial;
        private bool onlyContextoInicial;
        private string NombreEntidad;
        private string EmpresaDefinida;

        #region Constructor ctor
        public DataSwitch(String entidad, String empresa)
        {
            this.NombreEntidad = entidad;
            this.EmpresaDefinida = empresa;
            this.transacciones = new List<transaccion>();
            this.contextos = new List<IDbContext>();
            this.contextoInicial = new ContextoInicial(@"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Datos.ContextoInicial;Integrated Security=SSPI");
            this.SeteaContextos(this.contextos, typeof(TEntidad));
        }
        private void SeteaContextos(List<IDbContext> cntxts, Type tipoEntidad)
        {
            if (estaEnInicial(tipoEntidad))
                cntxts.Add(this.contextoInicial);
            else
                this.CargaContextosGenericos(cntxts);
        }

        private bool estaEnInicial(Type tipoEntidad)
        {
            var tipoDbSet = typeof(DbSet<>).MakeGenericType(tipoEntidad);

            if (typeof(ContextoInicial).GetProperties().Any(p => p.PropertyType.ToString() == tipoDbSet.ToString()))
                return true;
            else
                return false;
        }

        private void CargaContextosGenericos(List<IDbContext> cntxts)
        {
            //obtenemos las relaciones para la entidad
            var empresas = this.contextoInicial.Set<RelacionEmpresaEntidad>().Where(r => r.Entidad == this.NombreEntidad).Select(r => r.Empresa);
            if (empresas != null && empresas.Any())
            {
                var contextos = this.contextoInicial.Set<ConfiguraEmpresa>().Include("Contexto").Where(c => empresas.Any(e => e.Codigo == c.Empresa.Codigo)).ToList();
                contextos.ForEach(c => cntxts.Add(InstanciaContexto(c.Contexto.StringConexion)));
            }
            else
            {
                var contexto = this.contextoInicial.Set<ConfiguraEmpresa>().Include("Contexto").FirstOrDefault(p => p.Empresa.Codigo == this.EmpresaDefinida);
                cntxts.Add(InstanciaContexto(contexto.Contexto.StringConexion));
            }
        }

        private IDbContext InstanciaContexto(string stringConexion)
        {
            return new ContextoGenerico(stringConexion);


        }

        #endregion

        #region MODIFICAR
        ////2015 MODIFICAR
        //public bool Insertar(TEntidad Entidad, Usuario Usuario)
        //{
        //    this.contextos.ForEach(contexto => contexto.Insertar<TEntidad>(Entidad, Usuario));
        //    return true; //WTF
        //}

        ////2015 MODIFICAR
        public bool BorrarTodo()
        {
            this.contextos.ForEach(c =>
            {
                ((DbContext)c).Database.CommandTimeout = 560;
                ((DbContext)c).Set<TEntidad>().Delete();
                ((DbContext)c).Database.ExecuteSqlCommand("DBCC CHECKIDENT (" + typeof(TEntidad).Name + 's' + ", RESEED,0)");
            });
            return true; //WTF
        }

        ////2015 MODIFICAR
        //public bool Actualizar(TEntidad Entidad, Usuario Usuario)
        //{
        //    this.contextos.ForEach(contexto => contexto.Actualizar<TEntidad>(Entidad, Usuario));
        //    return true; //WTF
        //}
        //public void Borrar(TEntidad entidad, Usuario usuario)
        //{
        //    this.contextos.ForEach(contexto => contexto.Borrar<TEntidad>(entidad, usuario));
        //}

        public TEntidad Crear()
        {
            return this.contextos.FirstOrDefault().Crear<TEntidad>();
        }

        //public EvaluarConcurrencia SaveChanges()
        //{
        //    List<EvaluarConcurrencia> resultados = new List<EvaluarConcurrencia>();
        //    this.contextos.ForEach(contexto => resultados.Add(contexto.SaveChanges()));

        //    var concurrencia = resultados.FirstOrDefault(p =>
        //    {
        //        if (p != null)
        //        {
        //            return p.HuboConcurrencia;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    );
        //    return concurrencia;
        //}

        #endregion MODIFICAR

        #region 2015 - ELIMINAR
        //2015 MODIFICAR - QUITAR
        //public void EmpezarTransaccion()
        //{
        //    throw new NotImplementedException("DataSwitch.EmpezarTransaccion");

        //    //if (this.onlyContextoInicial)
        //    //{
        //    //    this.transacciones.Add(new transaccion() { Id=this.contextoInicial.GetHashCode(), Transaccion=this.contextoInicial.EmpezarTransaccion() });
        //    //}
        //    //else
        //    //{
        //    //    if (this.contextos != null && this.contextos.Count != 0)
        //    //    {
        //    //        foreach (var item in this.contextos)
        //    //        {
        //    //            this.transacciones.Add(new transaccion() { Contexto = item, Id = item.GetHashCode(), Transaccion = item.EmpezarTransaccion() });
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        this.transacciones.Add(new transaccion() { Contexto= this.contextoDefault, Id=this.contextoDefault.GetHashCode(), Transaccion=this.contextoDefault.EmpezarTransaccion() });
        //    //    }
        //    //}
        //}

        ////2015 MODIFICAR - QUITAR
        //public void CommitTransaccion()
        //{
        //    throw new NotImplementedException("DataSwitch.CommitTransaccion");

        //    //try
        //    //{
        //    //    if (this.onlyContextoInicial)
        //    //    {
        //    //        this.transacciones.FirstOrDefault(p => p.Id == this.contextoInicial.GetHashCode()).Transaccion.Commit();
        //    //    }
        //    //    else
        //    //    {
        //    //        if (this.contextos != null && this.contextos.Count != 0)
        //    //        {
        //    //            foreach (var item in this.contextos)
        //    //            {
        //    //                var transaccion = this.transacciones.First(p => p.Id == item.GetHashCode());
        //    //                if (transaccion != null)
        //    //                    transaccion.Transaccion.Commit();
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            this.transacciones.FirstOrDefault(p => p.Id == this.contextoDefault.GetHashCode()).Transaccion.Commit();
        //    //        }
        //    //    }

        //    //}
        //    //catch (Exception e)
        //    //{
        //    //}
        //}
        ////2015 MODIFICAR - QUITAR
        //public void RollbackTransaccion()
        //{
        //    throw new NotImplementedException("DataSwitch.RollbakTransaccion");
        //    //try
        //    //{
        //    //    if (this.onlyContextoInicial)
        //    //    {
        //    //        this.transacciones.FirstOrDefault(p => p.Id == this.contextoInicial.GetHashCode()).Transaccion.Rollback();
        //    //    }
        //    //    else
        //    //    {
        //    //        if (this.contextos != null && this.contextos.Count != 0)
        //    //        {
        //    //            foreach (var item in this.contextos)
        //    //            {
        //    //                var transaccion = this.transacciones.First(p => p.Id == item.GetHashCode());
        //    //                if (transaccion != null)
        //    //                    transaccion.Transaccion.Rollback();
        //    //            }
        //    //        }
        //    //        else
        //    //            this.transacciones.First(p => p.Id == this.contextoDefault.GetHashCode()).Transaccion.Rollback();
        //    //    }
        //    //}
        //    //catch (Exception e) { }
        //}
        ////2015 MODIFICAR - QUITAR
        //public void DisposeTransaccion()
        //{
        //    throw new NotImplementedException("DataSwitch.DisposeTransaccion");
        //    //try
        //    //{
        //    //    if (this.onlyContextoInicial)
        //    //    {
        //    //        this.transacciones.FirstOrDefault(p=>p.Id==this.contextoInicial.GetHashCode()).Transaccion.Dispose();
        //    //    }
        //    //    else
        //    //    {
        //    //        if (this.contextos != null && this.contextos.Count != 0)
        //    //        {
        //    //            foreach (var item in this.contextos)
        //    //            {
        //    //                var transaccion = this.transacciones.First(p => p.Id == item.GetHashCode());
        //    //                if (transaccion != null)
        //    //                    transaccion.Transaccion.Dispose();
        //    //            }
        //    //        }
        //    //        else
        //    //            this.transacciones.First(p => p.Id == this.contextoDefault.GetHashCode()).Transaccion.Dispose();
        //    //    }
        //    //}
        //    //catch(Exception e){
        //    //}
        //}
        #endregion 2015 - ELIMINAR

        #region prueba de GIT
        void PruebaGit()
        {
            //Si Lees esto es por que anda el git

        }
        #endregion

        public IQueryable<TEnt> Consultar<TEnt>(CargarRelaciones cargarEntidadesRelacionadas)
            where TEnt : EntidadBase
        {
            return this.contextos.FirstOrDefault().Consultar<TEnt>(cargarEntidadesRelacionadas);
            //return this.ObtenerContextos<TEnt>().FirstOrDefault().Consultar<TEnt>(cargarEntidadesRelacionadas);
        }

        public TMaestro BuscarPorCodigo<TMaestro>(String busqueda, CargarRelaciones cargarEntidadesRelacionadas)
            where TMaestro : EntidadMaestro
        {
            //return this.contextos.FirstOrDefault().BuscarPorCodigo<TMaestro>(busqueda, cargarEntidadesRelacionadas);
            return this.ObtenerContextos<TMaestro>().FirstOrDefault().BuscarPorCodigo<TMaestro>(busqueda, cargarEntidadesRelacionadas);
        }

        public TEntidad BuscarPorId(int id, CargarRelaciones cargarEntidades)
        {
            //return this.contextos.FirstOrDefault().BuscarPorId<TEntidad>(id, cargarEntidades);
            return this.ObtenerContextos<TEntidad>().FirstOrDefault().BuscarPorId<TEntidad>(id, cargarEntidades);
        }

        #region 2015

        /// <summary>
        /// EDIT 2015 - Este método lo utilizaremos para grabar/actualizar/borrar entidades de ahora en más.
        /// </summary>
        /// <returns>Devuelve los contextos en los que pertenece la entidad con la que fue instanciado.</returns>
        public List<IDbContext> ObtenerContextos<TipoEntidad>() where TipoEntidad : EntidadBase
        {
            List<IDbContext> listaContextos = new List<IDbContext>();
            this.SeteaContextos(listaContextos, typeof(TipoEntidad));
            return listaContextos;
        }

        /// <summary>
        /// EDIT 2015 - Este método lo utilizaremos para grabar/actualizar/borrar entidades de ahora en más.
        /// </summary>
        /// <param name="TipoEntidad">Entidad que buscamos en los contextos</param>
        /// <returns>Devuelve los contextos en los que pertenece la entidad con la que fue instanciado.</returns>
        public List<IDbContext> ObtenerContextos(Type TipoEntidad)
        {
            List<IDbContext> listaContextos = new List<IDbContext>();
            this.SeteaContextos(listaContextos, TipoEntidad);
            return listaContextos;
        }

        #endregion

    }
}
