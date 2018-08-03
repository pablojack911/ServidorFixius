using Inteldev.Core.Modelo.Auditoria;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Validadores;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Articulos.Grabadores
{
    public class GrabadorArticulo : GrabadorGenerico<Articulo>
    {
        public GrabadorArticulo(string empresa, string entidad, IValidador<Articulo> validador)
            : base(empresa, "articulo", validador)
        {

        }

        public override void Insertar(Articulo articulo, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                //carga local de las propiedades FK para que no se dupliquen al momento de grabar.
                articulo.AreaId = this.SetearFk(articulo, "Area");
                articulo.SectorId = this.SetearFk(articulo, "Sector");
                articulo.SubsectorId = this.SetearFk(articulo, "Subsector");
                articulo.FamiliaId = this.SetearFk(articulo, "Familia");
                articulo.SubFamiliaId = this.SetearFk(articulo, "Subfamilia");

                articulo.CaracteristicaId = this.SetearFk(articulo, "Caracteristica");
                articulo.EmpaqueId = this.SetearFk(articulo, "Empaque");
                articulo.EnvaseId = this.SetearFk(articulo, "Envase");
                articulo.MarcaId = this.SetearFk(articulo, "Marca");
                articulo.ProveedorId = this.SetearFk(articulo, "Proveedor");
                //articulo.TasasId = this.SetearFk(articulo, "TasasDeIva");

                if (articulo.DatosOld != null)
                {
                    articulo.DatosOld.ArticuloEnvaseId = this.SetearFk(articulo.DatosOld, "ArticuloEnvase");
                    articulo.DatosOld.ClaseId = this.SetearFk(articulo.DatosOld, "Clase");
                    articulo.DatosOld.DivisionId = this.SetearFk(articulo.DatosOld, "Division");
                    articulo.DatosOld.LineaId = this.SetearFk(articulo.DatosOld, "Linea");
                    articulo.DatosOld.RubroId = this.SetearFk(articulo.DatosOld, "Rubro");
                    articulo.DatosOld.SKUId = this.SetearFk(articulo.DatosOld, "SKU");
                }
                //carga las propiedades de listas
                if (articulo.ArticulosCompuestos.Count > 0)
                {
                    foreach (var artcomp in articulo.ArticulosCompuestos)
                    {
                        artcomp.ArticuloComponenteId = this.SetearFk(artcomp, "ArticuloComponente");
                        //artcomp.ArticuloPadreId = this.SetearFk(artcomp, "ArticuloPadre");
                        if (artcomp.Id == 0)
                            cntxt.Entry<ArticuloCompuesto>(artcomp).State = EntityState.Added;
                        else
                            cntxt.Set<ArticuloCompuesto>().Attach(artcomp);
                    }
                }

                if (articulo.Grupo.Count > 0)
                {
                    foreach (var gru in articulo.Grupo)
                    {
                        if (gru.Id == 0)
                            cntxt.Entry<GrupoArticulo>(gru).State = EntityState.Added;
                        else
                            cntxt.Set<GrupoArticulo>().Attach(gru);
                    }
                }

                cntxt.Set<Articulo>().Add(articulo);
                if (Usuario != null)
                    cntxt.insertaAuditoria<Articulo>(articulo, Accion.Agrega, Usuario);
                cntxt.SaveChanges();
            }
            );
        }

        public override void Actualizar(Articulo articulo, Core.Modelo.Usuarios.Usuario Usuario, List<Core.Datos.IDbContext> listaContextos)
        {
            listaContextos.ForEach(cntxt =>
            {
                var actualizar = cntxt.BuscarPorId<Articulo>(articulo.Id, Core.CargarRelaciones.CargarTodo);
                if (actualizar != null)
                {
                    articulo.AreaId = this.SetearFk(articulo, "Area");
                    articulo.SectorId = this.SetearFk(articulo, "Sector");
                    articulo.SubsectorId = this.SetearFk(articulo, "Subsector");
                    articulo.FamiliaId = this.SetearFk(articulo, "Familia");
                    articulo.SubFamiliaId = this.SetearFk(articulo, "Subfamilia");

                    articulo.CaracteristicaId = this.SetearFk(articulo, "Caracteristica");
                    articulo.EmpaqueId = this.SetearFk(articulo, "Empaque");
                    articulo.EnvaseId = this.SetearFk(articulo, "Envase");
                    articulo.MarcaId = this.SetearFk(articulo, "Marca");
                    articulo.ProveedorId = this.SetearFk(articulo, "Proveedor");
                    //articulo.TasasId = this.SetearFk(articulo, "TasasDeIva");

                    if (articulo.DatosOld != null)
                    {
                        articulo.DatosOld.ArticuloEnvaseId = this.SetearFk(articulo.DatosOld, "ArticuloEnvase");
                        articulo.DatosOld.ClaseId = this.SetearFk(articulo.DatosOld, "Clase");
                        articulo.DatosOld.DivisionId = this.SetearFk(articulo.DatosOld, "Division");
                        articulo.DatosOld.LineaId = this.SetearFk(articulo.DatosOld, "Linea");
                        articulo.DatosOld.RubroId = this.SetearFk(articulo.DatosOld, "Rubro");
                        articulo.DatosOld.SKUId = this.SetearFk(articulo.DatosOld, "SKU");
                    }

                    Action<ArticuloCompuesto> setFkArticulosCompuestos = artCom =>
                    {
                        artCom.ArticuloComponenteId = this.SetearFk(artCom, "ArticuloComponente");
                    };

                    this.ActualizarColeccionUnoAMuchos<ArticuloCompuesto>(actualizar.ArticulosCompuestos, articulo.ArticulosCompuestos, cntxt, setFkArticulosCompuestos);

                    this.ActualizarColeccionMuchosAMuchos<GrupoArticulo>(actualizar.Grupo, articulo.Grupo, cntxt);

                    this.ActualizarColeccionUnoAMuchos<ObservacionArticulo>(actualizar.Observaciones, articulo.Observaciones, cntxt);

                    this.ActualizarColeccionUnoAMuchos<CodigoDun>(actualizar.CodigoDUN, articulo.CodigoDUN, cntxt);

                    this.ActualizarColeccionUnoAMuchos<CodigoEan>(actualizar.CodigoEAN, articulo.CodigoEAN, cntxt);

                    this.SetearValores(articulo, actualizar, cntxt);
                    this.SetearValores(articulo.DatosOld, actualizar.DatosOld, cntxt);

                    if (Usuario != null)
                        cntxt.insertaAuditoria<Articulo>(actualizar, Accion.Modifica, Usuario);
                    cntxt.SaveChanges();
                }
            });
        }
    }
}
