using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Negocios;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Preventa;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Importadores
{
    public class MapeadorRutaVentasFox : MapeadorFox<RutaDeVenta>
    {

        public MapeadorRutaVentasFox(IDao con, String empresa, string entidad)
            : base("zonas", "select zonas.*,cr.pedido, cr.entrega, cr.diferido, cr.novalida from zonas INNER JOIN cron_ped as cr ON cr.zona = zonas.codigo AND cr.empresa=zonas.empresa_rel AND cr.prov=zonas.empresa where zonas.empresa$'00ALI-00BEB-00REF' GROUP BY ZONAS.codigo, ZONAS.empresa,ZONAS.empresa_rel order by codigo", "codigo", con, empresa, entidad)
        {
        }


        protected override RutaDeVenta Mapear(RutaDeVenta entidad, System.Data.DataRow registro)
        {

            entidad.Codigo = registro["codigo"].ToString().Trim();
            entidad.Nombre = registro["nombre"].ToString().Trim();
            entidad.Division = registro["empresa"].ToString().Trim();

            string empre = registro["empresa_rel"].ToString().Trim();
            Empresa emp = this.BuscarEntidadPorCodigo<Empresa>(empre);
            if (emp != null)
                entidad.Empresa = emp.Codigo;//this.BuscarEntidadPorCodigo<Empresa>(registro["empresa_rel"].ToString()).Codigo;
            //no seria redundante esta doble busqueda? POCHO
            entidad.RegionDeVenta = this.BuscarEntidadPorCodigo<RegionDeVenta>(registro["region"].ToString().Trim());
            entidad.Titular = this.BuscarEntidadPorCodigo<Preventista>(registro["operator"].ToString().Trim());
            entidad.Suplente = this.BuscarEntidadPorCodigo<Preventista>(registro["operator2"].ToString().Trim());
            entidad.Activada = ObtenerBoolDeString(registro["activada"].ToString());
            entidad.NoValidarCronograma = ObtenerBoolDeString(registro["novalida"].ToString());
            if (entidad.Vertices == null)
                entidad.Vertices = new List<Coordenada>();
            // Datos Old

            int acepta = int.Parse(registro["AceptaPed"].ToString().Trim());

            AceptaPedidos aceptaped = AceptaPedidos.DiferidosYUrgentes;
            switch (acepta)
            {
                case 1:
                    aceptaped = AceptaPedidos.DiferidosYUrgentes;
                    break;
                case 2:
                    aceptaped = AceptaPedidos.Diferidos;
                    break;
                case 3:
                    aceptaped = AceptaPedidos.DiferidosSegunCronograma;
                    break;

            }

            entidad.DatosOld.AceptaPedidos = aceptaped;
            entidad.DatosOld.RecargoPorLogistica = ObtenerBoolDeString(registro["recargo"].ToString().Trim());
            entidad.DatosOld.NoFacturar = ObtenerBoolDeString(registro["nofacturar"].ToString().Trim());

            // 

            String diasPedido = registro["pedido"].ToString().Trim();

            if (diasPedido.Contains("LU"))
            {
                entidad.DiasDeVisita.Lunes = true;
            }
            else
            {
                entidad.DiasDeVisita.Lunes = false;
            }

            if (diasPedido.Contains("MA"))
            {
                entidad.DiasDeVisita.Martes = true;
            }
            else
            {
                entidad.DiasDeVisita.Martes = false;
            }

            if (diasPedido.Contains("MI"))
            {
                entidad.DiasDeVisita.Miercoles = true;
            }
            else
            {
                entidad.DiasDeVisita.Miercoles = false;
            }

            if (diasPedido.Contains("JU"))
            {
                entidad.DiasDeVisita.Jueves = true;
            }
            else
            {
                entidad.DiasDeVisita.Jueves = false;
            }

            if (diasPedido.Contains("VI"))
            {
                entidad.DiasDeVisita.Viernes = true;
            }
            else
            {
                entidad.DiasDeVisita.Viernes = false;
            }

            if (diasPedido.Contains("SA"))
            {
                entidad.DiasDeVisita.Sabado = true;
            }
            else
            {
                entidad.DiasDeVisita.Sabado = false;
            }


            String diasDiferidos = registro["diferido"].ToString();

            if (diasDiferidos.Contains("LU"))
            {
                entidad.Diferidos.Lunes = true;
            }
            else
            {
                entidad.Diferidos.Lunes = false;
            }


            if (diasDiferidos.Contains("MA"))
            {
                entidad.Diferidos.Martes = true;
            }
            else
            {
                entidad.Diferidos.Martes = false;
            }

            if (diasDiferidos.Contains("MI"))
            {
                entidad.Diferidos.Miercoles = true;
            }
            else
            {
                entidad.Diferidos.Miercoles = false;
            }

            if (diasDiferidos.Contains("JU"))
            {
                entidad.Diferidos.Jueves = true;
            }
            else
            {
                entidad.Diferidos.Jueves = false;
            }

            if (diasDiferidos.Contains("VI"))
            {
                entidad.Diferidos.Viernes = true;
            }
            else
            {
                entidad.Diferidos.Viernes = false;
            }

            if (diasDiferidos.Contains("SA"))
            {
                entidad.Diferidos.Sabado = true;
            }
            else
            {
                entidad.Diferidos.Sabado = false;
            }

            String diasEntrega = registro["entrega"].ToString();

            if (diasEntrega.Contains("LU"))
            {
                entidad.DiasDeEntrega.Lunes = true;
            }
            else
            {
                entidad.DiasDeEntrega.Lunes = false;
            }


            if (diasEntrega.Contains("MA"))
            {
                entidad.DiasDeEntrega.Martes = true;
            }
            else
            {
                entidad.DiasDeEntrega.Martes = false;
            }

            if (diasEntrega.Contains("MI"))
            {
                entidad.DiasDeEntrega.Miercoles = true;
            }
            else
            {
                entidad.DiasDeEntrega.Miercoles = false;
            }

            if (diasEntrega.Contains("JU"))
            {
                entidad.DiasDeEntrega.Jueves = true;
            }
            else
            {
                entidad.DiasDeEntrega.Jueves = false;
            }

            if (diasEntrega.Contains("VI"))
            {
                entidad.DiasDeEntrega.Viernes = true;
            }
            else
            {
                entidad.DiasDeEntrega.Viernes = false;
            }

            if (diasEntrega.Contains("SA"))
            {
                entidad.DiasDeEntrega.Sabado = true;
            }
            else
            {
                entidad.DiasDeEntrega.Sabado = false;
            }
            //
            if (entidad.Clientes == null)
                entidad.Clientes = new List<Cliente>();


            entidad.Clientes.Clear();
            var drClientesRuta = dao.EjecutarConsulta("select Cliente from s://preventa//datos//Config_Zona where zona='" + entidad.Codigo + "' and empresa = '" + entidad.Empresa + "' and subempresa ='" + entidad.Division+ "' and baja=0");

            //var drClientesRuta = dao.EjecutarConsulta("select Cliente from s://appvfp//Hergo_release//datos//Config_Zona where zona='" + entidad.Codigo + "' and empresa = '" + entidad.Empresa + "' and subempresa ='" + entidad.Division.Codigo + "' and baja=0");

            while (drClientesRuta.Read()) //faltaria quitar las qu no estan
            {
                var codigoCliente = drClientesRuta["Cliente"].ToString();
                if (!entidad.Clientes.Any(c => c.Codigo == codigoCliente))
                {
                    Cliente cliente = BuscarEntidadPorCodigo<Cliente>(codigoCliente);
                    if (cliente != null)
                    {
                        entidad.Clientes.Add(cliente);
                    }
                    else
                        Debug.Write("El cliente con Codigo " + drClientesRuta[0].ToString() + " no está cargado en la base de datos local. (POCHO)");
                }
                else
                    Debug.Write("Ya existe en la lista.");
            }
            drClientesRuta.Close();
            drClientesRuta.Dispose();
            //dao.Desconectar();

            return entidad;
        }

        protected override RutaDeVenta ObtenerEntidad(System.Data.DataRow item)
        {
            string codigo = item["codigo"].ToString();
            string empresa = item["empresa_rel"].ToString();
            string division = item["empresa"].ToString();
            // && r.Division.Codigo == division
            var entidad = this.ObtenerEntidad(r =>
            {
                if (r.Division != null)
                    if (r.Codigo == codigo && r.Empresa == empresa && r.Division != null && r.Division == division)
                        return true;
                return false;
            });

            return entidad;
        }

        public override string[] ObtenerFiltroBorrador(Core.Modelo.EntidadMaestro entidad)
        {
            //var ent = entidad as RutaDeVenta;
            var ent = (RutaDeVenta)entidad;
            //ParameterOverride[] parameters = new ParameterOverride[2];
            //parameters[0] = new ParameterOverride("empresa", "01");
            //parameters[1] = new ParameterOverride("entidad", "DivisionComercial");


            //var buscadorDivision = FabricaNegocios.Instancia.Resolver(typeof(IBuscador<DivisionComercial>), paramers) as IBuscador<DivisionComercial>;

            //ent.Division = buscadorDivision.ConsultaSimple(Core.CargarRelaciones.NoCargarNada).FirstOrDefault(p => p.Id == ent.DivisionId);
            return new string[] { ent.Codigo, ent.Empresa, ent.Division };
        }

    }



}
