using Inteldev.Core.Datos;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Servicios.DTO.Preventa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Inteldev.Fixius.Negocios.Preventa.Buscadores
{
    public class BuscadorFoxConfigZona : IBuscadorFoxConfigZona
    {
        public IDao conexion { get; set; }
        public BuscadorFoxConfigZona()
        {
            throw new Exception();
        }
        public BuscadorFoxConfigZona(IDao dao)
        {
            this.conexion = dao;
        }

        public List<CoordenadaCliente> BuscarClientes()
        {
            var lista = new List<CoordenadaCliente>();
            try
            {
                var dt = this.conexion.EjecutarConsulta("SELECT codigo, ALLTRIM(nombre)+' - '+telefono, domicilio, cz.recorrido FROM clientes INNER JOIN config_zona cz ON clientes.codigo=cz.cliente WHERE cz.baja=0 AND cz.recorrido<>0 GROUP BY clientes.codigo");
                //var dt = this.conexion.EjecutarConsulta("SELECT codigo, ALLTRIM(nombre)+' - '+telefono, domicilio, cz.recorrido FROM clientes INNER JOIN config_zona cz ON clientes.codigo=cz.cliente WHERE cz.baja=0 AND cz.recorrido<>0 AND clientes.codigo>'19219' GROUP BY clientes.codigo");
                while (dt.Read())
                {
                    var coordCli = new CoordenadaCliente()
                    {
                        Codigo = dt.GetString(0).Trim(),
                        Nombre = dt.GetString(1).Trim(),
                        Domicilio = dt.GetString(2).Trim(),
                        Orden = Convert.ToInt32(dt.GetValue(3))
                    };

                    lista.Add(coordCli);
                }
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public List<CoordenadaCliente> BuscarClientes(List<string> codigosClientes)
        {
            var consulta = this.CreaConsulta(codigosClientes);
            var lista = new List<CoordenadaCliente>();
            try
            {
                var dt = this.conexion.EjecutarConsulta("SELECT codigo, ALLTRIM(nombre)+' - '+telefono, domicilio, cz.recorrido FROM clientes INNER JOIN config_zona cz ON clientes.codigo=cz.cliente WHERE cz.baja=0 AND cz.recorrido<>0 GROUP BY clientes.codigo");
                //var dt = this.conexion.EjecutarConsulta("SELECT codigo, ALLTRIM(nombre)+' - '+telefono, domicilio, cz.recorrido FROM clientes INNER JOIN config_zona cz ON clientes.codigo=cz.cliente WHERE cz.baja=0 AND cz.recorrido<>0 AND clientes.codigo>'19219' GROUP BY clientes.codigo");
                while (dt.Read())
                {
                    var coordCli = new CoordenadaCliente()
                    {
                        Codigo = dt.GetString(0).Trim(),
                        Nombre = dt.GetString(1).Trim(),
                        Domicilio = dt.GetString(2).Trim(),
                        Orden = Convert.ToInt32(dt.GetValue(3))
                    };

                    lista.Add(coordCli);
                }
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        private string CreaConsulta(List<string> codigosClientes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT codigo, ALLTRIM(nombre)+' - '+telefono, domicilio, cz.recorrido FROM clientes INNER JOIN config_zona cz ON clientes.codigo=cz.cliente WHERE (cz.baja=0 AND cz.recorrido<>0) AND clientes.codigo='");
            foreach (var codigo in codigosClientes)
            {
                sb.Append(string.Format("{0}' or codigo='", codigo));
            }
            sb.Remove(sb.Length - 12, 12); //el ultimo ' or codigo='
            sb.Append(" GROUP BY clientes.codigo");
            return sb.ToString();
        }

    }
}
