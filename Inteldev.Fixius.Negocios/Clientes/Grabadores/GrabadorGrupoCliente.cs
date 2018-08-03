using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Grabadores
{
    public class GrabadorGrupoCliente : GrabadorGenerico<GrupoCliente>
    {
        public GrabadorGrupoCliente(string empresa, string entidad, IValidador<GrupoCliente> validador)
            : base(empresa, "grupocliente", validador)
        {

        }

        public override void Insertar(GrupoCliente grupoCliente, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                if (grupoCliente.Clientes.Count > 0)
                {
                    foreach (var cli in grupoCliente.Clientes)
                    {
                        if (cli.Id == 0)
                            cntxt.Entry<Cliente>(cli).State = EntityState.Added;
                        else
                            cntxt.Set<Cliente>().Attach(cli);
                    }
                }

                cntxt.Set<GrupoCliente>().Add(grupoCliente);
                if (Usuario != null)
                    cntxt.insertaAuditoria<GrupoCliente>(grupoCliente, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            });
        }

        public override void Actualizar(GrupoCliente grupoCliente, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                var actualizar = cntxt.BuscarPorId<GrupoCliente>(grupoCliente.Id, Core.CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {

                    Action<Cliente> setFkClientes = c =>
                    {
                        if (c.DatosOld != null)
                        {
                            c.DatosOld.RutaDeVentaId = this.SetearFk(c.DatosOld, "RutaDeVenta");
                            c.DatosOld.ListaDePrecioId = this.SetearFk(c.DatosOld, "ListaDePreciosDeVenta");
                        }
                        if (c.Domicilio != null)
                        {
                            c.Domicilio.CalleId = this.SetearFk(c.Domicilio, "Calle");
                        }
                        if (c.LugarEntrega != null)
                        {
                            c.LugarEntrega.CalleId = this.SetearFk(c.LugarEntrega, "Calle");
                        }
                        c.LocalidadDeEntregaId = this.SetearFk(c, "LocalidadDeEntrega");
                        c.LocalidadId = this.SetearFk(c, "Localidad");
                        c.ProvinciaId = this.SetearFk(c, "Provincia");
                        c.RamoId = this.SetearFk(c, "Ramo");
                        c.ZonaGeograficaId = this.SetearFk(c, "ZonaGeografica");
                        c.ZonaLogisticaId = this.SetearFk(c, "ZonaLogistica");
                        foreach (var item in c.ConfiguraCreditos)
                        {
                            item.CobradorId = this.SetearFk(item, "Cobrador");
                            item.VendedorId = this.SetearFk(item, "Vendedor");
                            item.VendedorEspecialId = this.SetearFk(item, "VendedorEspecial");
                            item.CondicionDePagoId = this.SetearFk(item, "CondicionDePago");
                            item.CondicionDePago2Id = this.SetearFk(item, "CondicionDePago2");
                        }
                        foreach (var item in c.RutasDeVenta)
                        {
                            //item.DivisionId = this.SetearFk(item, "Division");
                            item.RegionDeVentaId = this.SetearFk(item, "RegionDeVenta");
                            item.SuplenteId = this.SetearFk(item, "Suplente");
                            item.TitularId = this.SetearFk(item, "Titular");
                        }
                    };

                    this.ActualizarColeccionMuchosAMuchos<Cliente>(actualizar.Clientes, grupoCliente.Clientes, cntxt, setFkClientes);

                    SetearValores(grupoCliente, actualizar, cntxt);

                    if (Usuario != null)
                        cntxt.insertaAuditoria<GrupoCliente>(actualizar, Accion.Modifica, Usuario);
                    cntxt.SaveChanges();
                }
            });
        }
    }
}
