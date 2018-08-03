using AutoMapper;
using Inteldev;
using Inteldev.Core;
using Inteldev.Core.Contratos;
using Inteldev.Core.Datos;
using Inteldev.Core.DTO;
using Inteldev.Core.Extenciones;
using Inteldev.Core.Modelo;
using Inteldev.Core.Modelo.Locacion;
using Inteldev.Core.Modelo.Organizacion;
using Inteldev.Core.Modelo.Usuarios;
using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Busquedas;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Core.Presentacion.ClienteServicios;
using Inteldev.Core.Presentacion.Controladores;
using Inteldev.Core.Servicios;
using Inteldev.Fixius;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Modelo;
using Inteldev.Fixius.Modelo.Articulos;
using Inteldev.Fixius.Modelo.Clientes;
using Inteldev.Fixius.Modelo.Proveedores;
using Inteldev.Fixius.Negocios;
using Inteldev.Fixius.Negocios.Busquedas.Bloques;
using Inteldev.Fixius.Negocios.Proveedores;
using Inteldev.Fixius.Negocios.Proveedores.Consultadores;
using Inteldev.Fixius.Servicios;
using Inteldev.Fixius.Servicios.DTO.Financiero;
using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
		static void Main(string[] args)
		{
            FabricaNegocios.Instancia.CargarRegistro(new RegistroNegocios());

            Inteldev.Fixius.Servicios.RegistroMapeos mapeos = new Inteldev.Fixius.Servicios.RegistroMapeos();

            mapeos.Configurar();

            //var contextoInicial = new ContextoInicial();

            //var empresa = new Empresa();

            //empresa.Codigo = "01";
            //empresa.Nombre = "Hola";

           // contextoInicial.Insertar<Empresa>(empresa, new Usuario());
           // contextoInicial.SaveChanges();

            //var configuracion = new RelacionEmpresaEntidad();
            
            //var relacion = new ConfiguraEmpresa();
            //relacion.Empresa = contextoInicial.Consultar<Empresa>(CargarRelaciones.CargarEntidades).FirstOrDefault(p=>p.Id==1);
            //relacion.Contexto.StringConnecion= "Inteldev.Fixius.Datos.Extra";

            ////contextoInicial.ConfiguraEmpresa.Add(relacion);
            
            //var relacion2 = new ConfiguraEmpresa();
            //relacion2.Empresa = contextoInicial.Consultar<Empresa>(CargarRelaciones.CargarEntidades).FirstOrDefault(p => p.Id == 1);
            //relacion2.Contexto.StringConnecion = "Inteldev.Fixius.Datos.ContextoGenerico";

            ////contextoInicial.ConfiguraEmpresa.Add(relacion2);

            //configuracion.Relacion = relacion;
            //configuracion.Entidad = "provincia";
            //configuracion.Grupo = 0;
            
            //contextoInicial.RelacionEmpresaEntida.Add(configuracion);

            //configuracion = new RelacionEmpresaEntidad();
            //configuracion.Relacion = relacion2;
            //configuracion.Entidad = "provincia";
            //configuracion.Grupo = 0;

            //contextoInicial.RelacionEmpresaEntida.Add(configuracion);

            //contextoInicial.SaveChanges();

            //var grabador = new Grabador<Provincia>("Provincia", "01");
            
            //var provincia = new Provincia();
            //provincia.Nombre = "Hola";


            //grabador.Insertar(provincia, new Usuario());
            //grabador.SaveChanges();

            //Console.WriteLine("Termine");
            //Console.Read();
            //ParameterOverride[] para = {new ParameterOverride("empresa","01"), new ParameterOverride("entidad","empresa")};
            //var buscadorDTO = FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Empresa, Inteldev.Core.DTO.Organizacion.Empresa>),para);

            //var contexto = new ContextoGenerico(@"Server=.\SQLEXPRESS;Initial Catalog=Inteldev.Fixius.Datos.ContextoGenerico; Integrated Security=SSPI");
            //var contexto = new Grabador<Localidad>("localidad","01");
            //var contexto2 = new Grabador<Provincia>("provincia", "01");
            //var contexto = new GrabadorGenerico<Localidad>("01", "localidad");


            //var localidad = new Localidad();
            //localidad.Nombre = "prueba grabador generico 3";
            //var prov = contexto2.BuscarPorId(1, CargarRelaciones.CargarTodo);
            //localidad.Provincia = prov;

            //contexto.Grabar(localidad,new Usuario());
            //contexto.Insertar(localidad,new Usuario());
            //contexto.SaveChanges();

            //List<string> Entidades = (from asm in AppDomain.CurrentDomain.GetAssemblies()
            //                  from type in asm.GetTypes()
            //                  where type.IsSubclassOf(typeof(EntidadBase))
            //                  select type.Name).ToList();

            //ParameterOverride[] parameters = { new ParameterOverride("empresa", "01"), new ParameterOverride("entidad", "Localidad") };
            //var grabador = (IGrabador<Localidad>)FabricaNegocios.Instancia.Resolver(typeof(IGrabador<Localidad>), parameters);

            //var numerador = new Inteldev.Core.Negocios.Numerador<Localidad>("01","Localidad");
            //numerador.TamañoMaximo = 4;
            //var codigo = numerador.ProximoCodigo();
            //Console.WriteLine("tamaño maximo: {0}",numerador.TamañoMaximo);
            //Console.WriteLine(codigo);
            //while (true)
            //{
            //    Console.WriteLine("Ingrese Numero: ");
            //    var numero = Console.ReadLine();
            //    //Console.WriteLine("Ingrese tamaño maximo: ");
            //    //var tamaño = Console.ReadLine();
            //    Console.WriteLine(getNumero(numero.ToString()));
            //}

            //IDbContext contextoInicial = new ContextoInicial();
            //var switchHelper = new Inteldev.Fixius.DataSwitch.SwitcherHelper(contextoInicial.GetType());

            //Console.WriteLine("Termine");
            //Console.ReadLine();
            //var servicio = new ServicioABM<Inteldev.Core.DTO.Locacion.Provincia, Inteldev.Core.Modelo.Locacion.Provincia>();
            //try
            //{
            //    var nuevo = servicio.Crear("01");
            //}
            //catch(System.ServiceModel.FaultException<FaultTesting> ee)
            //{
            //    Console.WriteLine(ee.Detail.Reason);
            //}
            //Console.ReadLine();

            //var rutaDeVentaDTO = new Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta();
            //Inteldev.Fixius.Modelo.Clientes.RutaDeVenta rutaDeVentaEntidad;

            //ParameterOverride[] pararu = { new ParameterOverride("empresa", "01"), new ParameterOverride("entidad", "rutadeventa") };

            //var mapeador = (IMapeadorGenerico<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>)FabricaNegocios.Instancia.Resolver(typeof(IMapeadorGenerico<Inteldev.Fixius.Modelo.Clientes.RutaDeVenta, Inteldev.Fixius.Servicios.DTO.Clientes.RutaDeVenta>), pararu);
           
            //ParameterOverride[] para = { new ParameterOverride("empresa", ""), new ParameterOverride("entidad", "empresa") };
            //var buscador = (IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>)FabricaNegocios.Instancia.Resolver(typeof(IBuscadorDTO<Inteldev.Core.Modelo.Organizacion.Empresa, Inteldev.Core.DTO.Organizacion.Empresa>), para);

            //rutaDeVentaDTO.Empresa = buscador.BuscarPorCodigo<Inteldev.Core.Modelo.Organizacion.Empresa>("01",CargarRelaciones.CargarTodo,null);
            //rutaDeVentaEntidad = mapeador.DtoToEntidad(rutaDeVentaDTO);
            //Console.WriteLine(rutaDeVentaEntidad.Empresa);
            
           

            Console.ReadLine();

		}
        public static string getNumero(string codigoUltimo)
        {
            string codigo = codigoUltimo.ToUpper();
            int tamañoMaximo = codigo.Length;
            if (codigo == null)
                codigo = "0";
            var letra = Regex.Match(codigo, @"[A-Z]{1}").Groups[0].ToString();
            int numero = 0;
            try
            {
                numero = int.Parse(Regex.Match(codigo, @"\d+").Groups[0].ToString());
            }
            catch (FormatException e)
            {
                numero = 9;
            }
            int tamaño =0;
            if (letra == "")
                tamaño++;
            else
                tamaño = tamañoMaximo -1;
            if (Regex.IsMatch(numero.ToString(), @"^[9]{" + tamaño.ToString() + "}"))
            {
                /* Son todos 9
                 * Aumentas en 1 la letra. Pones los numeros en 0
                 */
                byte[] letraNum = Encoding.ASCII.GetBytes(letra);
                if (letraNum.Count() == 0)
                {
                    letraNum = new byte[1];
                    letraNum[0] = 65;
                }
                else
                {
                    if (letraNum[0] == 90 || letraNum[0] == 122)
                    {
                        throw new IndexOutOfRangeException("Final de la capacidad de numeracion");
                    }
                    letraNum[0]++;
                }
                if (tamañoMaximo == 1)
                {
                    codigo = Encoding.ASCII.GetChars(letraNum)[0].ToString().PadRight(tamañoMaximo - 1, '0');
                }
                else
                    codigo = Encoding.ASCII.GetChars(letraNum)[0].ToString().PadRight(tamañoMaximo - 1, '0')+"1";
                
            }
            else
            {
                //no son todos 9
                numero++;
                if (letra != null && letra != "")
                    codigo = letra + numero.ToString().Trim().PadLeft(tamañoMaximo-1, '0');
                else
                    codigo = numero.ToString().Trim().PadLeft(tamañoMaximo, '0');
            }
            return codigo;
        }
    }

   
}
