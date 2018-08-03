using Inteldev.Core.Negocios;
using Inteldev.Core.Negocios.Mapeador;
using Inteldev.Fixius.Contratos;
using Inteldev.Fixius.Negocios.Proveedores.Buscadores;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.ServiceModel;
using AutoMapper.QueryableExtensions;
using Inteldev.Core.DTO.Organizacion;
using Inteldev.Fixius.Negocios.Proveedores.Creadores;

namespace Inteldev.Fixius.Servicios
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServicioDocumentoDeCompra : IServicioDocumentoDeCompra
    {
        public DTO.Proveedores.DocumentoCompra BuscarOCrearDocumentoDeCompra(string empresa, string sucursal, int provId, int tipoDoc, string preNro, string nro)
        {
            try
            {
                Modelo.Proveedores.DocumentoCompra doc = null;

                ParameterOverride[] para = 
                { 
                    new ParameterOverride("empresa", empresa),
                    new ParameterOverride("entidad", "DocumentoCompra") 
                };
                var buscador = (BuscadorDocumentoDeCompra)FabricaNegocios.Instancia.Resolver(typeof(BuscadorDocumentoDeCompra), para);

                if (buscador != null)
                {
                    doc = buscador.ObtenerDocumento(empresa, sucursal, provId, tipoDoc, preNro, nro).FirstOrDefault();
                }

                if (doc == null)
                {
                    var servicioCreador = (CreadorDocumentoCompra)FabricaNegocios.Instancia.Resolver(typeof(ICreadorDTO<Modelo.Proveedores.DocumentoCompra, DTO.Proveedores.DocumentoCompra>), para);
                    var nuevoDoc = servicioCreador.Crear(new string[] { empresa, sucursal, provId.ToString(), tipoDoc.ToString(), preNro, nro });
                    if (!nuevoDoc.GetError())
                        return nuevoDoc.GetEntidad();
                }
                //doc = new Modelo.Proveedores.DocumentoCompra();
                return AutoMapper.Mapper.Map<DTO.Proveedores.DocumentoCompra>(doc);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
