using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Proveedores.Buscadores
{
    public class BlockDeBusquedaProveedor : BlockDeBusquedaGenerico<Proveedor>
    {
        public override void AgregarPartes(List<object> listaPropiedades, List<Core.Modelo.ParametrosMiniBusca> Parametros)
        {
            foreach (PropertyInfo prop in listaPropiedades)
            {
                Type type = prop.PropertyType;
                if (type == typeof(string))
                {
                    if (prop.Name.Contains("Codigo"))
                    {
                        var busquedaPorCodigo = new BusquedaCodigo<Proveedor>();
                        busquedaPorCodigo.Cargar(Busqueda, prop.Name);
                        foreach (var item in Parametros)
                        {
                            busquedaPorCodigo.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                        }
                        this.Partes.Add(busquedaPorCodigo);
                    }
                    else
                        if (prop.Name == "Nombre" || prop.Name == "RazonSocial")
                        {
                            var busquedaPorString = new BusquedaStringStartsWith<Proveedor>();
                            busquedaPorString.Cargar(Busqueda, prop.Name);
                            foreach (var item in Parametros)
                            {
                                busquedaPorString.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                            }
                            this.Partes.Add(busquedaPorString);
                        }
                        else
                            if (prop.Name == "Cuit")
                            {
                                var busquedaPorString = new BusquedaStringEquals<Proveedor>();
                                busquedaPorString.Cargar(Busqueda, prop.Name);
                                foreach (var item in Parametros)
                                {
                                    busquedaPorString.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                                }
                                this.Partes.Add(busquedaPorString);
                            }
                }
                else
                {
                    if (type == typeof(int))
                    {
                        var busquedaPorId = new BusquedaPorInt<Proveedor>();
                        busquedaPorId.Cargar(Busqueda, prop.Name);
                        this.Partes.Add(busquedaPorId);
                    }
                }
            }
        }
    }
}
