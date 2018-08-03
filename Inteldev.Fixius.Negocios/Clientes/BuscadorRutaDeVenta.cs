using Inteldev.Core;
using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Preventa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Inteldev.Fixius.Negocios.Clientes
{
    public class BuscadorRutaDeVenta : BuscadorGenerico<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta>, IBuscadorRutaDeVenta
    {
        public BuscadorRutaDeVenta(string empresa) :
            base(empresa, "RutaDeVenta")
        {
        }

        /// <summary>
        /// En base al preventista y el dia de la fecha pasadas por parámetro se construye
        /// la consulta que devuelve todas las rutas en las que hay ocurrencias del
        /// preventista y el dia
        /// </summary>
        /// <param name="preventistaId"></param>
        /// <param name="diaDate"></param>
        /// <returns></returns>
        public IQueryable<RutaDeVenta> CrearConsulta(int? preventistaId, DateTime diaDate)
        {
            var dia = this.ConstruirDiaDeSemana(diaDate);
            var rutasDeVenta = this.Contexto.Consultar<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta>(CargarRelaciones.CargarTodo);
            return (from r in rutasDeVenta
                    where ((r.TitularId == preventistaId || r.SuplenteId == preventistaId) &&
                    ((r.DiasDeVisita.Lunes == dia.Lunes && dia.Lunes) ||
                     (r.DiasDeVisita.Martes == dia.Martes && dia.Martes) ||
                     (r.DiasDeVisita.Miercoles == dia.Miercoles && dia.Miercoles) ||
                     (r.DiasDeVisita.Jueves == dia.Jueves && dia.Jueves) ||
                     (r.DiasDeVisita.Viernes == dia.Viernes && dia.Viernes) ||
                     (r.DiasDeVisita.Sabado == dia.Sabado && dia.Sabado)))
                    select r);
        }

        public List<Cliente> ObtenerClientes(Preventista preventista, DateTime dia)
        {
            return this.ObtenerClientes(preventista.Id, dia);
        }

        public List<Cliente> ObtenerClientes(int? preventistaId, DateTime dia)
        {
            var clientes = new List<Cliente>();
            IQueryable<RutaDeVenta> rutas;

            rutas = this.CrearConsulta(preventistaId, dia);

            foreach (var r in rutas.ToList())
            {
                clientes.AddRange(r.Clientes);
            }
            return clientes;
        }

        public override List<TMaestro> BuscarDiferencia<TMaestro>(List<string[]> codigosImportados)
        {

            var listaFiltrada = new List<RutaDeVenta>();
            var listaCodigosLocal = this.Contexto.Consultar<RutaDeVenta>(CargarRelaciones.CargarEntidades).Select(p => new { p.Id, p.Codigo, p.Empresa, Division = p.Division });
            //comparar
            foreach (var item in listaCodigosLocal)
            {
                if (!(codigosImportados.Any(p => p[0] == item.Codigo && p[1] == item.Empresa && p[2] == item.Division)))
                    listaFiltrada.Add(this.Contexto.Consultar<RutaDeVenta>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == item.Id));
            }
            //si encuentra
            //recorrer y buscarla en codigos. si no esta buscar la entidad completa y agregarla a una lista y luego devolver la lista
            return listaFiltrada as List<TMaestro>;
        }

        public override TMaestro BuscarPorCodigo<TMaestro>(object busqueda, List<Core.Modelo.ParametrosMiniBusca> parametros = null)
        {
            if (parametros != null && parametros.Count > 0)
            {
                var empresa = parametros[0].Valor.ToString();
                var division = parametros[1].Valor.ToString();

                var ruta = this.ConsultaSimple(CargarRelaciones.CargarEntidades).Where(p => p.Empresa == empresa && p.Division == division && p.Codigo == busqueda.ToString()).FirstOrDefault();
                return ruta as TMaestro;
            }
            else
                return null;
        }

        DiasDeSemana ConstruirDiaDeSemana(DateTime dia)
        {
            switch (dia.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return new DiasDeSemana() { Lunes = true };
                    break;
                case DayOfWeek.Tuesday:
                    return new DiasDeSemana() { Martes = true };
                    break;
                case DayOfWeek.Wednesday:
                    return new DiasDeSemana() { Miercoles = true };
                    break;
                case DayOfWeek.Thursday:
                    return new DiasDeSemana() { Jueves = true };
                    break;
                case DayOfWeek.Friday:
                    return new DiasDeSemana() { Viernes = true };
                    break;
                case DayOfWeek.Saturday:
                    return new DiasDeSemana() { Sabado = true };
                    break;
                case DayOfWeek.Sunday:
                default:
                    return new DiasDeSemana() { };
                    break;
            }
        }

        public ICollection<Core.Modelo.Locacion.Coordenada> ObtenerCoordenadas(string codigo, string empresa, string division)
        {
            //var coordenadas = new List<Coordenada>();
            var query = this.Contexto.Consultar<RutaDeVenta>(Core.CargarRelaciones.CargarTodo);
            var ruta = (from r in query
                        where r.Codigo.Equals(codigo) && r.Empresa.Equals(empresa) && (r.Division != null && r.Division.Equals(division))
                        select r).FirstOrDefault();
            if (ruta != null)
            {
                return ruta.Vertices;
            }
            return new List<Coordenada>();
        }


        public List<RutaDeVenta> ObtenerRutasDelDia(Preventista preventista, DateTime fecha)
        {
            return this.ObtenerRutasDelDia(preventista.Id, fecha);
        }

        public List<RutaDeVenta> ObtenerRutasDelDia(int? preventistaId, DateTime fecha)
        {
            IQueryable<RutaDeVenta> rutas;
            rutas = this.CrearConsulta(preventistaId, fecha);
            return rutas.GroupBy(x => x.Codigo).Select(y => y.FirstOrDefault()).ToList();
        }


        public List<RutaDeVenta> ObtenerRutasDelDia(string codigoPreventista, DateTime fecha)
        {
            var preventista = this.Contexto.Consultar<Preventista>(CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Codigo == codigoPreventista);
            if (preventista != null)
            {
                var preventistaId = preventista.Id; //obtener id del preventista por codigo
                return this.ObtenerRutasDelDia(preventistaId, fecha);
            }
            return new List<RutaDeVenta>();
        }


        public List<string> ObtenerClientesPorZona(string codigoZona, string empresa, string division)
        {
            var query = this.Contexto.Consultar<RutaDeVenta>(Core.CargarRelaciones.CargarTodo);
            var ruta = (from r in query
                        where r.Codigo.Equals(codigoZona) && r.Empresa.Equals(empresa) && (r.Division != null && r.Division.Equals(division))
                        select r).FirstOrDefault();
            if (ruta != null)
            {
                return ruta.Clientes.Select(c => c.Codigo).ToList();
            }
            return new List<string>();
        }
    }
}
