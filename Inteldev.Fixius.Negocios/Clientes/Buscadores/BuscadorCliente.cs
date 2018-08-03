using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public class BuscadorCliente : BuscadorGenerico<Cliente>
    {
        public BuscadorCliente(string empresa, string entidad)
            : base(empresa, entidad)
        {

        }

        public override List<Cliente> BuscarLista(System.Linq.Expressions.Expression<Func<Cliente, bool>> busqueda, Core.CargarRelaciones cargarEntidades)
        {
            return this.Contexto.ObtenerContextos<Cliente>().FirstOrDefault().Consultar<Cliente>(cargarEntidades)
                .Where(busqueda)
                .Select(c => new Cliente()
                    {
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                        NombreFantasia = c.NombreFantasia,
                        Cuit = c.Cuit,
                        NumeroDocumentoCliente = c.NumeroDocumentoCliente,
                        Domicilio = c.Domicilio
                    }).ToList();
        }

        public override List<Cliente> BuscarLista(System.Linq.Expressions.MethodCallExpression busqueda, Core.CargarRelaciones cargarEntidades)
        {
            if (busqueda != null)
            {
                var query = this.Contexto.Consultar<Cliente>(cargarEntidades).Provider.CreateQuery<Cliente>(busqueda)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        Apellido = c.Apellido,
                        NombreFantasia = c.NombreFantasia,
                        RazonSocial = c.RazonSocial,
                        Cuit = c.Cuit,
                        NumeroDocumentoCliente = c.NumeroDocumentoCliente,
                        Domicilio = c.Domicilio
                    });
                Debug.WriteLine(query.ToString());
                
                return query.ToList().Select(x => new Cliente()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    NombreFantasia = x.NombreFantasia,
                    RazonSocial = x.RazonSocial,
                    Cuit = x.Cuit,
                    NumeroDocumentoCliente = x.NumeroDocumentoCliente,
                    Domicilio = x.Domicilio
                }).OrderBy(f => f.RazonSocial).ToList();
            }
            else
                return null;
        }

        //public override List<Cliente> BuscarLista(System.Linq.Expressions.MethodCallExpression busqueda, Core.CargarRelaciones cargarEntidades)
        //{
        //    if (busqueda != null)
        //    {
        //        return this.Contexto.Consultar<Cliente>(cargarEntidades).Provider.CreateQuery<Cliente>(busqueda)
        //            .Select(c => new
        //            {
        //                Id = c.Id,
        //                Codigo = c.Codigo,
        //                Nombre = c.Nombre,
        //                Apellido = c.Apellido,
        //                NombreFantasia = c.NombreFantasia,
        //                RazonSocial = c.RazonSocial,
        //                Cuit = c.Cuit,
        //                NumeroDocumentoCliente = c.NumeroDocumentoCliente,
        //                Domicilio = c.Domicilio
        //            })
        //            .ToList().Select(x => new Cliente()
        //            {
        //                Id = x.Id,
        //                Codigo = x.Codigo,
        //                Nombre = x.Nombre,
        //                Apellido = x.Apellido,
        //                NombreFantasia = x.NombreFantasia,
        //                RazonSocial = x.RazonSocial,
        //                Cuit = x.Cuit,
        //                NumeroDocumentoCliente = x.NumeroDocumentoCliente,
        //                Domicilio = x.Domicilio
        //            }).OrderBy(f => f.RazonSocial).ToList();
        //    }
        //    else
        //        return null;
        //}
    }
}
