using Inteldev.Core.DTO.Contabilidad;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Contabilidad
{
    public class RegistroMapeoTasaConcepto : Inteldev.Fixius.Negocios.Contabilidad.IRegistroMapeoTasaConcepto
    {
        private Dictionary<EnumTasas, TipoConcepto> mapeo;

        public RegistroMapeoTasaConcepto()
        {
            this.mapeo = new Dictionary<EnumTasas, TipoConcepto>();
            this.mapeo.Add(EnumTasas.General,TipoConcepto.IvaTasaGeneral);
        }

        public TipoConcepto? ObtenerConcepto(EnumTasas tasa)
        {
            try
            {
                return mapeo.First(p => p.Key == tasa).Value;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
            
        }

        public EnumTasas? ObtenerTasa(TipoConcepto concepto)
        {
            try
            {
                return this.mapeo.First(p => p.Value == concepto).Key;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
            
        }
    }
}
