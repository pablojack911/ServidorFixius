using Inteldev.Core.Datos;
using Inteldev.Core.Modelo.Contabilidad;
using Inteldev.Core.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Organizacion
{
    public class GrabadorEmpresa : GrabadorGenerico<Core.Modelo.Organizacion.Empresa>
    {
        public GrabadorEmpresa(string empresa, string entidad, Inteldev.Core.Negocios.Validadores.IValidador<Core.Modelo.Organizacion.Empresa> validador) :base(empresa,entidad, validador) { }

        public override Core.DTO.Carriers.GrabadorCarrier GrabarNuevo(Core.Modelo.Organizacion.Empresa Entidad, Core.Modelo.Usuarios.Usuario Usuario)
        {
            var carrier = base.GrabarNuevo(Entidad, Usuario);
            var creadorReferencia = FabricaNegocios._Resolver<ICreador<Modelo.Contabilidad.ReferenciaContable>>();
            var grabadorReferencia = FabricaNegocios._Resolver<IGrabador<Modelo.Contabilidad.ReferenciaContable>>();
            foreach (var item in Enum.GetValues(typeof(Imputaciones)))
            {
                var referencia = creadorReferencia.Crear();
                referencia.Empresa = Entidad.Codigo;
                referencia.Imputacion = (Imputaciones)Enum.Parse(typeof(Imputaciones),item.ToString());
                grabadorReferencia.Grabar(referencia,Usuario);
            }
            return carrier;
        }
    }
}
