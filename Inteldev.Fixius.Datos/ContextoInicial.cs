using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Fixius.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Datos
{
    public class ContextoInicial : DbContextBase, IDbContext
    {

        public ContextoInicial(string connectionString)
            : base(connectionString)
        {
            //Database.SetInitializer(new CustomInitializer());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoInicial>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<PerfilUsuario> Perfiles { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ConfiguraEmpresa> ConfiguraEmpresa { get; set; }
        public DbSet<RelacionEmpresaEntidad> RelacionEmpresaEntidad { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<DetalleAuditoria> DetalleAuditoria { get; set; }
        public DbSet<Contexto> Contextos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
    }
}
