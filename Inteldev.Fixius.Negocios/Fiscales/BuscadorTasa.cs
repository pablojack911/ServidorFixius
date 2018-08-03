using Inteldev.Core.Negocios;
using Inteldev.Fixius.Negocios.Contabilidad;
using Inteldev.Fixius.Servicios.DTO.Articulos;
using Inteldev.Fixius.Servicios.DTO.Contabilidad;
using Inteldev.Fixius.Servicios.DTO.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Negocios.Fiscales
{
    public class BuscadorTasa : Inteldev.Fixius.Negocios.Fiscales.IBuscadorTasa
    {
        private IRegistroMapeoTasaConcepto mapeo;
        private IBuscadorDTO<Modelo.Contabilidad.TasasDeIva, Servicios.DTO.Contabilidad.TasasDeIva> buscadorTasas;

        public BuscadorTasa(IRegistroMapeoTasaConcepto registro, IBuscadorDTO<Modelo.Contabilidad.TasasDeIva, Servicios.DTO.Contabilidad.TasasDeIva> buscadorTasas)
        {
            this.mapeo = registro;
            this.buscadorTasas = buscadorTasas;
        }

        public decimal ObtenerTasa(TipoConcepto tipoConcepto)
        {
            EnumTasas? tasa = this.mapeo.ObtenerTasa(tipoConcepto);
            if (tasa != null)
            {
                var tasas = this.buscadorTasas.BuscarLista(1, Core.CargarRelaciones.NoCargarNada).Where(p => p.Enum == tasa).FirstOrDefault();
                if (tasas != null)
                    return tasas.Valor;
                else
                    return 0;
            }
            else
                return 0;
        }

        public decimal ObtenerTasa(string tipoConcepto)
        {
            EnumTasas? tasa = this.mapeo.ObtenerTasa((TipoConcepto)Enum.Parse(typeof(TipoConcepto),tipoConcepto));
            if (tasa != null)
            {
                var tasas = this.buscadorTasas.BuscarLista(1, Core.CargarRelaciones.NoCargarNada).Where(p => p.Enum == tasa).FirstOrDefault();
                if (tasas != null)
                    return tasas.Valor;
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
