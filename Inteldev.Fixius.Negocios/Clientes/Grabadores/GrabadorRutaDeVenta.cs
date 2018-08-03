using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Negocios.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Inteldev.Core.Modelo.Locacion;

namespace Inteldev.Fixius.Negocios.Clientes.Grabadores
{
    public class GrabadorRutaDeVenta : GrabadorGenerico<RutaDeVenta>
    {
        public GrabadorRutaDeVenta(string entidad, string empresa, ValidadorRutaDeVenta validador)
            : base(empresa, entidad, validador)
        {

        }

        public override void Insertar(RutaDeVenta ruta, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                //ruta.DivisionId = this.SetearFk(ruta, "Division");
                ruta.RegionDeVentaId = this.SetearFk(ruta, "RegionDeVenta");
                ruta.SuplenteId = this.SetearFk(ruta, "Suplente");
                ruta.TitularId = this.SetearFk(ruta, "Titular");

                if (ruta.Clientes.Count > 0)
                {
                    foreach (var cli in ruta.Clientes)
                    {
                        if (cli.Id == 0)
                            cntxt.Entry(cli).State = System.Data.Entity.EntityState.Added;
                        else
                            cntxt.Set<Cliente>().Attach(cli);
                    }
                }
                if (ruta.Vertices.Count > 0)
                {
                    foreach (var vert in ruta.Vertices)
                    {
                        if (vert.Id == 0)
                            cntxt.Entry(vert).State = EntityState.Added;
                        else
                            cntxt.Set<Coordenada>().Attach(vert);
                    }
                }

                cntxt.Set<RutaDeVenta>().Add(ruta);
                if (Usuario != null)
                    cntxt.insertaAuditoria<RutaDeVenta>(ruta, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            });

        }

        public override void Actualizar(RutaDeVenta ruta, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            foreach (var cntxt in listaContextos)
            {
                var actualizar = cntxt.BuscarPorId<RutaDeVenta>(ruta.Id, Core.CargarRelaciones.CargarTodo);
                //var actualizar = cntxt.Consultar<RutaDeVenta>(Core.CargarRelaciones.NoCargarNada).Include("Clientes").FirstOrDefault(r => r.Id == ruta.Id);
                if (actualizar != null)
                {
                    //ruta.DivisionId = this.SetearFk(ruta, "Division");

                    ruta.RegionDeVentaId = this.SetearFk(ruta, "RegionDeVenta");

                    ruta.SuplenteId = this.SetearFk(ruta, "Suplente");

                    ruta.TitularId = this.SetearFk(ruta, "Titular");

                    Action<Cliente> setFkClientes = c =>
                    {
                        if (c.DatosOld != null)
                        {
                            //c.DatosOld.ZonaGeograficaId = this.SetearFk(c.DatosOld, "ZonaGeografica");
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

                    ActualizarColeccionMuchosAMuchos<Cliente>(actualizar.Clientes, ruta.Clientes, cntxt, setFkClientes);
                    if (ruta.Vertices != null && ruta.Vertices.Count > 0)
                        ActualizarColeccionUnoAMuchos<Coordenada>(actualizar.Vertices, ruta.Vertices, cntxt);
                    else
                        ActualizarColeccionUnoAMuchos<Coordenada>(actualizar.Vertices, actualizar.Vertices, cntxt); //no necesito actualizar las coordenadas de los vertices porque las cargo desde el kml!

                    SetearValores(ruta, actualizar, cntxt);
                    SetearValores(ruta.DatosOld, actualizar.DatosOld, cntxt);

                    if (Usuario != null)
                        cntxt.insertaAuditoria<RutaDeVenta>(actualizar, Accion.Modifica, Usuario);
                    cntxt.SaveChanges();
                }
            }
        }

        public void GrabarCoordenadas(string codigo, List<Coordenada> coordenadas)
        {
            var rutas = this.Contexto.Consultar<RutaDeVenta>(Core.CargarRelaciones.CargarTodo).Where(r => r.Codigo.Equals(codigo)).ToList();
            foreach (var ruta in rutas)
            {
                if (ruta != null)
                {
                    ruta.Vertices.Clear();
                    ruta.Vertices = coordenadas;
                    this.Actualizar(ruta, null, this.Contexto.ObtenerContextos<RutaDeVenta>());
                    coordenadas.ForEach(c => c.Id = 0);
                }
            }
        }
    }
}
