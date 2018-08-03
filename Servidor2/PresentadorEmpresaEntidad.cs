using Inteldev.Core.Contratos;
using Inteldev.Core.DTO.Locacion;
using Inteldev.Core.Modelo;
using Inteldev.Core.Negocios;
using Inteldev.Core.Presentacion;
using Inteldev.Core.Presentacion.Presentadores;
using Inteldev.Core.Presentacion.Presentadores.Interfaces;
using Inteldev.Core.Servicios;
using Inteldev.Fixius.Datos;
using Inteldev.Fixius.Negocios;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Servidor2
{
    public class PresentadorEmpresaEntidad : PresentadorGrillaServidor<Inteldev.Fixius.Modelo.RelacionEmpresaEntidad,Inteldev.Fixius.Servicios.DTO.RelacionEmpresaEntidad,ItemEmpresaEntidad>
    {
    //    private IServicioABM<Inteldev.Fixius.Servicios.DTO.ConfiguraEmpresa> servicioConfiguracion;

    //    public PresentadorEmpresaEntidad()
    //        : base()
    //    {
    //        this.servicioConfiguracion = new ServicioABM<Inteldev.Fixius.Servicios.DTO.ConfiguraEmpresa, Inteldev.Fixius.Modelo.ConfiguraEmpresa>();
    //        this.Entidades = (from asm in AppDomain.CurrentDomain.GetAssemblies()
    //                          from type in asm.GetTypes()
    //                          where type.IsSubclassOf(typeof(EntidadBase))
    //                          orderby type.Name
    //                          select type.Name).ToList();
    //    }

    //    public override bool AgregarItem()
    //    {
    //        return base.AgregarItem();
    //    }

    //    public override bool Aceptar()
    //    {
    //        int id;
    //        int.TryParse(this.Objeto.RelacionId.ToString(),out id);
    //        this.Objeto.Relacion = this.servicioConfiguracion.ObtenerPorId(id, Inteldev.Core.CargarRelaciones.CargarEntidades, "");
    //        //validar que los ids esten igual en ambos lados
    //        ContextoGenerico contextoExtra = (ContextoGenerico) FabricaNegocios.Instancia.Resolver(typeof(ContextoGenerico),"connectionString",this.Objeto.Relacion.Contexto.StringConnecion);
    //        var validador = new ValidadorBaseDatos(contextoExtra);
    //        Type objectType = (from asm in AppDomain.CurrentDomain.GetAssemblies()
    //                           from type in asm.GetTypes()
    //                           where type.IsClass && type.Name == this.Objeto.Entidad
    //                           select type).FirstOrDefault();
    //        bool result = (bool)validador.GetType().GetMethod("validar").MakeGenericMethod(objectType).Invoke(validador,null);
    //        if (result)
    //            return base.Aceptar();
    //        else
    //        {
    //            Mensajes.Error("No se puede agregar. Tablas no sincronizadas");
    //            return false;
    //        }
    //    }

    //    public List<string> Entidades
    //    {
    //        get { return (List<string>)GetValue(EntidadesProperty); }
    //        set { SetValue(EntidadesProperty, value); }
    //    }

    //    // Using a DependencyProperty as the backing store for Entidades.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty EntidadesProperty =
    //        DependencyProperty.Register("Entidades", typeof(List<string>), typeof(PresentadorEmpresaEntidad));



    }
}
