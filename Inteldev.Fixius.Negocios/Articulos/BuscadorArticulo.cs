using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores
{
    public class BuscadorArticulo : BuscadorGenerico<Modelo.Articulos.Articulo>, Inteldev.Fixius.Negocios.Proveedores.Interfaces.IBuscadorArticulo
    {
        public BuscadorArticulo(string empresa) : base(empresa, "Articulo") { }

        /// <summary>
        /// Busca los articulos que corresponden a un determinado proveedor y sus correspondientes areas, sector, etc.
        /// </summary>
        /// <param name="id">id del proveedor</param>
        /// <param name="areaId"></param>
        /// <param name="sectorId"></param>
        /// <param name="subSectorId"></param>
        /// <param name="familiaId"></param>
        /// <param name="subFamiliaId"></param>
        /// <returns></returns>
        public List<Articulo> obtenerArticulosProveedor(int id, int areaId, int sectorId, int subSectorId, int familiaId, int subFamiliaId)
        {
            if (subFamiliaId != 0)
            {
                return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && art.Subfamilia.Id == subFamiliaId)
                            .ToList();
            }
            else
                if (familiaId != 0)
                    return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && art.Familia.Id == familiaId)
                            .ToList();
                else
                    if (subSectorId != 0)
                        return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && art.Subsector.Id == subSectorId)
                            .ToList();
                    else
                        if (sectorId != 0)
                            return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && art.Sector.Id == sectorId)
                            .ToList();
                        else
                            if (areaId != 0)
                                return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && art.Area.Id == areaId)
                            .ToList();
            return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id)
                            .ToList();
        }
        /// <summary>
        /// Busca todos los articulos que corresponden a un proveedor
        /// </summary>
        /// <param name="id">id del proveedor</param>
        /// <returns>lista de articulos</returns>
        public List<Articulo> obtenerArticulosProveedor(int id)
        {
            return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
                            .Where(art => art.Proveedor.Id == id && (art.Estado == EstadoArticulo.Activo || art.Estado == EstadoArticulo.Suspendido))
                            .ToList();
        }
        /// <summary>
        /// Obtengo los articulos que cumplen con los filtros especificados.
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="areaID"></param>
        /// <param name="sectorID"></param>
        /// <param name="subsectorID"></param>
        /// <param name="familiaID"></param>
        /// <param name="subfamiliaID"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        public List<Articulo> obtenerArticulos(int folder, int areaID, int sectorID, int subsectorID, int familiaID,
            int subfamiliaID, int marca)
        {
            var result = new List<Articulo>();
            //fijarse lo de no cargar nada en caso de que algo no funcione
            if (folder == 0)
            {
                var consulta = this.Contexto.Consultar<Articulo>(CargarRelaciones.CargarCollecciones);

                if (areaID != 0)
                {
                    consulta.Where(p => p.AreaId == areaID);
                    if (sectorID != 0)
                    {
                        consulta = consulta.Where(p => p.SectorId == sectorID);
                        if (subsectorID != 0)
                        {
                            consulta = consulta.Where(p => p.SubsectorId == subsectorID);
                            if (familiaID != 0)
                            {
                                consulta = consulta.Where(p => p.FamiliaId == familiaID);
                                if (subfamiliaID != 0)
                                    consulta = consulta.Where(p => p.SubFamiliaId == subfamiliaID);
                            }
                        }
                    }
                }
                if (marca != 0)
                {
                    consulta.Where(p => p.MarcaId == marca);
                }
                result = consulta.ToList<Articulo>();
            }
            else
            {
                //matate
            }
            return result;
        }


        //public List<string> ObtenerListaCodigos(long desde)
        //{
        //    string Desde = desde.ToString().PadLeft(13, '0');
        //    return this.Contexto.Consultar<Articulo>(CargarRelaciones.NoCargarNada)
        //        .Where(p => p.Codigo.CompareTo(Desde) >= 0)
        //        .OrderBy(p => p.Codigo)
        //        .Select(c => c.Codigo)
        //        .Take(1000)
        //        .ToList();
        //}
    }
}
