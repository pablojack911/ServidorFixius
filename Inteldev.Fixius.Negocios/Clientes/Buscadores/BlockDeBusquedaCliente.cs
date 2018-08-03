using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Fixius.Modelo.Clientes;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Clientes.Buscadores
{
    public class BlockDeBusquedaCliente : BlockDeBusquedaGenerico<Cliente>
    {
        public override void AgregarPartes(List<object> listaPropiedades, List<Core.Modelo.ParametrosMiniBusca> Parametros)
        {

            foreach (PropertyInfo prop in listaPropiedades)
            {
                Type type = prop.PropertyType;
                if (type == typeof(string))
                {
                    if (prop.Name == "Codigo")
                    {
                        var busquedaPorCodigo = new BusquedaCodigo<Cliente>();
                        busquedaPorCodigo.Cargar(Busqueda, prop.Name);
                        foreach (var item in Parametros)
                        {
                            busquedaPorCodigo.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                        }
                        this.Partes.Add(busquedaPorCodigo);
                    }
                    else
                        if (prop.Name == "Nombre" || prop.Name == "Apellido" || prop.Name == "NombreFantasia" || prop.Name == "RazonSocial")
                        {
                            var busquedaPorString = new BusquedaStringStartsWith<Cliente>();
                            busquedaPorString.Cargar(Busqueda, prop.Name);
                            foreach (var item in Parametros)
                            {
                                busquedaPorString.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                            }
                            this.Partes.Add(busquedaPorString);
                        }
                        else
                            if (prop.Name == "Cuit" || prop.Name == "NumeroDocumentoCliente")
                            {
                                var busquedaPorString = new BusquedaStringEquals<Cliente>();
                                busquedaPorString.Cargar(Busqueda, prop.Name);
                                foreach (var item in Parametros)
                                {
                                    busquedaPorString.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                                }
                                this.Partes.Add(busquedaPorString);
                            }
                            else
                            {
                                if (prop.Name == "CodigoDeTarjeta")
                                {
                                    var busquedaTarjeta = new ParteBusquedaTarjetasCliente();
                                    busquedaTarjeta.Cargar(Busqueda, prop.Name);
                                    foreach (var item in Parametros)
                                    {
                                        busquedaTarjeta.AgregaCondicionAnd(item.Nombre, item.Valor, item.TipoObjeto);
                                    }
                                    this.Partes.Add(busquedaTarjeta);
                                }
                                else
                                {
                                    //aca iria lo de domicilio... ni idea
                                }
                            }
                }
                else
                {
                    if (type == typeof(int))
                    {
                        var busquedaPorId = new BusquedaPorInt<Cliente>();
                        busquedaPorId.Cargar(Busqueda, prop.Name);
                        this.Partes.Add(busquedaPorId);
                    }
                }
            }
        }

    }
}
