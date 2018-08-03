using Inteldev.Core.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inteldev.Fixius.Modelo.Precios
{
    public class CambioDePreciosDeVenta:EntidadMaestro
    {
		public CambioDePreciosDeVenta()
		{
			this.FechaDesde = DateTime.Now;
			this.FechaHasta = DateTime.Now;
			this.ItemsCambioDePrecioDeVenta = new List<ItemCambioDePrecioDeVenta>();
		}
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public TipoCambioDePreciosDeVenta TipoDeCambio { get; set; }
        public int Folder { get; set; }
        public EstadoCambioDePreciosDeVenta Estado { get; set; }
        public ICollection<ItemCambioDePrecioDeVenta> ItemsCambioDePrecioDeVenta { get; set; }
    }
}
